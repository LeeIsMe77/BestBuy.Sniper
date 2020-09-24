namespace BestBuyListingNotifier {

	#region Directives
	using System;
	using System.Timers;
	using System.ComponentModel;
	using System.IO;
	using System.Linq;
	using System.Net;
	using System.Net.Mail;
	using System.Web;
	using Newtonsoft.Json;
	using System.Xml.Linq;
	#endregion

	public class Program {

		[STAThread]
		static void Main(string[] args) {
			Program.Start();
		}

		private static void Start() {

			const string BASE_URL = @"https://api.bestbuy.com/v1/products";
			const ConsoleColor DEFAULT_FOREGROUND_COLOR = ConsoleColor.White;


			string smtpUserName = null;
			string smtpPassword = null;
			string smtpAddress = null;
			int? smtpPortNumber = null;
			bool? smtpEnableSsl = null;
			int? refreshInterval = null;
			string apiKey = null;
			string sku = null;
			MailAddressCollection failureNotificationEmailAddresses = null;
			MailAddressCollection availabilityNotificationEmailAddressCollection = null;

			var rootPath = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
			var configurationPath = Path.Combine(rootPath, @"configuration.xml");

			static string SafeElementValue(XElement element, string elementName) {
				return element?.Element(elementName)?.Value is string returnValue && !string.IsNullOrWhiteSpace(returnValue)
					? returnValue
					: null;
			}

			MailAddressCollection ParseMailAddress(string mailAddress) {
				if (!string.IsNullOrWhiteSpace(mailAddress) && mailAddress.Split(new[] { ';', ',' }, StringSplitOptions.RemoveEmptyEntries) is string[] messageArray && messageArray.Length > 0) {
					var emailAddresses = new MailAddressCollection();
					try {
						foreach (var emailAddress in messageArray) {
							emailAddresses.Add(emailAddress);
						}
					}
					catch (Exception caught) {
						Console.WriteLine($"Failure parsing email addresses: {caught.Message}");
						return null;
					}
					return emailAddresses;
				}
				return null;
			}

			if (File.Exists(configurationPath)) {
				try {
					var configuration = XElement.Load(configurationPath);
					smtpUserName = SafeElementValue(configuration, @"SMTPUserName");
					smtpPassword = SafeElementValue(configuration, @"SMTPPassword");
					smtpAddress = SafeElementValue(configuration, @"SMTPAddress");
					smtpPortNumber = int.TryParse(SafeElementValue(configuration, @"SMTPPortNumber"), out var portNumber)
						? portNumber
						: (int?)null;
					var tempEnableSsl = SafeElementValue(configuration, @"SMTPEnableSsl");
					smtpEnableSsl = new[] { bool.TrueString, @"1", @"T", @"Y", @"Yes" }.Any(value => string.Equals(value, tempEnableSsl, StringComparison.OrdinalIgnoreCase))
						? true
						: (bool?)null;
					refreshInterval = int.TryParse(SafeElementValue(configuration, @"BestBuyRefreshInterval"), out var interval)
						? interval
						: (int?)null;
					apiKey = SafeElementValue(configuration, @"BestBuyAPIKey");
					sku = SafeElementValue(configuration, @"BestBuySku");

					failureNotificationEmailAddresses = ParseMailAddress(SafeElementValue(configuration, @"SMTPFailureEmailAddresses"));
					availabilityNotificationEmailAddressCollection = ParseMailAddress(SafeElementValue(configuration, @"SMTPAvailabilityEmailAddresses"));


				}
				catch (Exception caught) {
					Console.WriteLine($@"Failed to read configuration file at location '{configurationPath}'");
					Console.WriteLine(caught.Message);
				}
			}

			static TResponseType GetInput<TResponseType>(string message, int maxAttempts = 3, int attempt = 0) {
				try {
					Console.WriteLine(message);
					var response = Console.ReadLine()?.Trim() ?? string.Empty;
					if (typeof(TResponseType) == typeof(bool)) {
						return new[] { @"Y", @"Yes", @"T", @"1", bool.TrueString }.Any(value => string.Equals(value, response, StringComparison.OrdinalIgnoreCase))
							? (TResponseType)(object)true
							: new[] { @"F", @"No", @"N", @"0", bool.FalseString, string.Empty }.Any(value => string.Equals(value, response, StringComparison.OrdinalIgnoreCase))
								? (TResponseType)(object)false
								: throw new Exception($@"The value '{response}' is not a recognized boolean value.");
					}
					if (string.IsNullOrWhiteSpace(response)) {
						throw new ArgumentException(nameof(response));
					}
					if (typeof(TResponseType) == typeof(string)) {
						return (TResponseType)(object)response;
					}
					attempt = 0;
					return (TResponseType)TypeDescriptor.GetConverter(typeof(TResponseType)).ConvertFromString(response);
				}
				catch {
					attempt++;
					if (attempt < maxAttempts) {
						return GetInput<TResponseType>(message, maxAttempts, attempt);
					}
					throw;
				}
			}

			static MailAddressCollection GetMailAddresses(string message, int maxAttempts = 3, int attempt = 0) {
				try {
					Console.WriteLine(message);
					var response = Console.ReadLine();
					if (string.IsNullOrWhiteSpace(response)) {
						throw new ArgumentException(nameof(response));
					}

					var mailAddressArray = response.Split(new[] { ';', ',', '\t' }, StringSplitOptions.RemoveEmptyEntries);
					if (mailAddressArray.Length == 0) {
						throw new Exception(@"At least one email address must be provided.");
					}
					var notificationEmailAddressCollection = new MailAddressCollection();
					foreach (var mailAddress in mailAddressArray) {
						notificationEmailAddressCollection.Add(mailAddress);
					}
					attempt = 0;
					return notificationEmailAddressCollection;
				}
				catch (Exception caught) {
					attempt++;
					Console.WriteLine(caught.Message);
					if (attempt < maxAttempts) {
						return GetMailAddresses(message, maxAttempts, attempt);
					}
					throw;
				}
			}

			static void WriteMessage(string availableMode, bool available, DateTime lastUpdate) {
				var foreground = available ? ConsoleColor.Green : ConsoleColor.Red;
				Console.Write($@"Available {availableMode}: ");
				Console.ForegroundColor = foreground;
				Console.Write(available);
				Console.WriteLine();
				Console.ForegroundColor = DEFAULT_FOREGROUND_COLOR;
				Console.WriteLine($@"Available {availableMode} Last Update: {lastUpdate}");
			}

			static SearchResult GetSearchResult(string apiKey, string sku) {

				var queryParameters = HttpUtility.ParseQueryString(string.Empty);
				queryParameters["apiKey"] = apiKey;
				queryParameters["format"] = @"json";

				var bestBuyQueryParameters = HttpUtility.ParseQueryString(string.Empty);
				bestBuyQueryParameters["sku"] = sku;

				var uriBuilder = new UriBuilder($"{BASE_URL}({bestBuyQueryParameters})");
				uriBuilder.Query = queryParameters.ToString();

				var request = HttpWebRequest.CreateHttp(uriBuilder.Uri);
				using (var response = (HttpWebResponse)request.GetResponse())
				using (var responseStream = response.GetResponseStream())
				using (var streamReader = new StreamReader(responseStream)) {
					return JsonConvert.DeserializeObject<SearchResult>(streamReader.ReadToEnd());
				}

			}

			if (smtpUserName == null) {
				smtpUserName = GetInput<string>(@"SMTP From Email Address:");
			}

			if (smtpPassword == null) {
				smtpPassword = GetInput<string>(@"SMTP Password:");
			}

			if (smtpAddress == null) {
				smtpAddress = GetInput<string>(@"SMTP Address/Url:");
			}

			if (smtpPortNumber == null) {
				smtpPortNumber = GetInput<int>(@"SMTP Port Number:");
			}

			if (smtpEnableSsl == null) {
				smtpEnableSsl = GetInput<bool>(@"SMTP SSL Enabled (Y/N T/F 0/1):");
			}

			if (apiKey == null) {
				apiKey = GetInput<string>(@"BestBuy API Key:");
			}

			if (sku == null) {
				sku = GetInput<string>(@"Product SKU Number:");
			}

			if (refreshInterval == null) {
				refreshInterval = GetInput<int>(@"Refresh Interval (Seconds): ");
			}

			void SendMessage(string subjectText, string messageText, MailAddressCollection mailAddresses) {

				using (var client = new SmtpClient(smtpAddress, smtpPortNumber.Value))
				using (var message = new MailMessage()) {

					client.Credentials = new NetworkCredential(smtpUserName, smtpPassword);
					client.EnableSsl = smtpEnableSsl.Value;

					message.Subject = subjectText;
					message.Body = messageText;
					message.From = new MailAddress(smtpUserName);
					foreach (var mailAddress in mailAddresses) {
						message.To.Add(mailAddress);
					}

					client.Send(message);
				}
			}

			if (failureNotificationEmailAddresses == null) {
				failureNotificationEmailAddresses = GetMailAddresses(@"Semi-Colon (;) Delimited Failure Notification Email Addresses: ");
			}

			var sendTestMessage = GetInput<bool>(@"Send Test Message To Failure Emails (Y/N T/F 0/1):");
			if (sendTestMessage) {
				SendMessage(@"Test", @"This is a test message.", failureNotificationEmailAddresses);
			}
			
			if (availabilityNotificationEmailAddressCollection == null) {
				availabilityNotificationEmailAddressCollection = GetMailAddresses(@"Semi-Colon (;) Delimited Availability Notification Email Addresses: ");
			}

			var timespan = TimeSpan.FromSeconds(refreshInterval.Value);
			var timer = new Timer();

			bool productAvailable = false;
			var failureCount = 0;

			void ExecuteSearch() {
				try {
					Console.Clear();

					var result = GetSearchResult(apiKey, sku);
					var product = result.Products?.FirstOrDefault(product => string.Equals(product.Sku, sku, StringComparison.Ordinal));

					Console.ForegroundColor = ConsoleColor.Green;
					Console.WriteLine($"Last Update: {DateTime.Now}");
					Console.ForegroundColor = DEFAULT_FOREGROUND_COLOR;

					if (product != null) {

						Console.Write($@"Product Name: ");

						Console.ForegroundColor = ConsoleColor.Cyan;
						Console.Write(product.Name);
						Console.WriteLine();
						Console.ForegroundColor = DEFAULT_FOREGROUND_COLOR;

						Console.WriteLine($@"Product Sku: {product.Sku}");
						Console.WriteLine($@"Product Last Update: {product.ItemUpdateDate}");
						Console.WriteLine();
						WriteMessage(@"Online", product.OnlineAvailability, product.OnlineAvailabilityUpdateDate);
						Console.WriteLine();
						WriteMessage(@"In Store", product.InStoreAvailability, product.InStoreAvailabilityUpdateDate);
						Console.WriteLine();

						if (productAvailable != product.OnlineAvailability) {
							productAvailable = product.OnlineAvailability;
							Console.ForegroundColor = ConsoleColor.Yellow;
							Console.WriteLine(@"Product online availability has changed.");
							Console.ForegroundColor = DEFAULT_FOREGROUND_COLOR;
							if (product.OnlineAvailability) {
								Console.ForegroundColor = ConsoleColor.Green;
								Console.WriteLine($"In Stock: {DateTime.Now}");
								Console.WriteLine($@"The product '{product.Name}' is now available to purchase online! Sending text message with add-to-cart URL.");
								SendMessage($@"Preorder Link: {product.Name}", $@"Add to cart: {product.AddToCardUrl}", availabilityNotificationEmailAddressCollection);
								Console.WriteLine($"Email Sent: {DateTime.Now}");
								Console.ForegroundColor = DEFAULT_FOREGROUND_COLOR;
							}
							else {
								Console.ForegroundColor = ConsoleColor.Red;
								Console.WriteLine($"Sold Out: {DateTime.Now}");
								Console.WriteLine($@"The product '{product.Name}' is sold out.");
								SendMessage($@"Preorder Sold Out: {product.Name}", $@"Product '{product.Name}' has sold out online.'", availabilityNotificationEmailAddressCollection);
								Console.ForegroundColor = DEFAULT_FOREGROUND_COLOR;
							}
						}

					}
					else {
						throw new Exception($"Product with sku number '{sku}' cannot be located.");
					}
					failureCount = 0;

				}
				catch (Exception caught) {
					Console.ForegroundColor = ConsoleColor.Red;
					Console.WriteLine($"Failure: {DateTime.Now}");
					Console.WriteLine($@"Timer failed to execute to completion: {caught.Message}");
					failureCount++;
					if (failureCount > 5) {
						timer.Stop();
						SendMessage(@"Program Failure", caught.Message, failureNotificationEmailAddresses);
					}
					Console.ForegroundColor = DEFAULT_FOREGROUND_COLOR;
				}
				finally {
					Console.ForegroundColor = DEFAULT_FOREGROUND_COLOR;
					Console.WriteLine();
					Console.WriteLine();
					Console.WriteLine("Press the Enter key to exit anytime... ");
				}
			}

			timer.Interval = timespan.TotalMilliseconds;
			timer.Elapsed += (object sender, ElapsedEventArgs e) => {
				ExecuteSearch();
			};

			timer.AutoReset = true;
			timer.Enabled = true;
			ExecuteSearch();
			Console.ReadLine();
		}

	}

}
