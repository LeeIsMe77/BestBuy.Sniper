using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Mail;
using System.Timers;
using System.Web;
using BestBuy.Sniper.Client.DataContracts;

namespace BestBuy.Sniper.Client {

	// TODO: Implement IDispoable and clean up the timer.

	public sealed class BestBuyRequestManager {

		#region Events
		public delegate void SearchResultExecutedDelegate(SearchResultEventArgs e);
		public event SearchResultExecutedDelegate SearchResultExecuted;
		#endregion

		#region Properties

		#region APIKey

		public string APIKey { get; set; }

		#endregion

		#region SMTPAddress

		public string SMTPAddress { get; set; }

		#endregion

		#region SMTPEnableSSL

		public bool SMTPEnableSSL { get; set; }

		#endregion

		#region SMTPPassword

		public string SMTPPassword { get; set; }

		#endregion

		#region SMTPPort

		public int SMTPPort { get; set; }

		#endregion

		#region SMTPUserName

		public string SMTPUserName { get; set; }

		#endregion

		#region FailureAddresses

		public MailAddressCollection FailureAddresses { get; set; }

		#endregion

		#region SuccessAddresses

		public MailAddressCollection SuccessAddresses { get; set; }

		#endregion

		#region SkuNumber

		public long SkuNumber { get; set; }

		#endregion

		#region RefreshIntervalSeconds

		public int RefreshIntervalSeconds { get; set; }

		#endregion

		#region Timer

		private Timer _timer;

		private Timer Timer {
			get {
				if (_timer == null) {
					_timer = new Timer {
						AutoReset = true,
						Interval = TimeSpan.FromSeconds(this.RefreshIntervalSeconds).TotalMilliseconds
					};
					_timer.Elapsed += (object sender, ElapsedEventArgs e) => {
						this.Search();
					};
				}
				return _timer;
			}
		}

		#endregion


		#region ProductAvailable

		private readonly object _isProductCurrentlyAvaialbleLockObject = new object();
		private bool _isProductCurrentlyAvaialble = false;

		private bool IsProductCurrentlyAvailable {
			get {
				lock (_isProductCurrentlyAvaialbleLockObject) {
					return _isProductCurrentlyAvaialble;
				}
			}
			set {
				lock (_isProductCurrentlyAvaialbleLockObject) {
					_isProductCurrentlyAvaialble = value;
				}
			}
		}

		#endregion

		#region NumberConcurrentOfFailues

		private readonly object _numberOfConcurrentFailuresLockObject = new ();
		private int _numberOfConcurrentFailures = 0;

		private int NumberConcurrentOfFailues {
			get {
				lock (_numberOfConcurrentFailuresLockObject) {
					return _numberOfConcurrentFailures;
				}
			}
			set {
				lock (_numberOfConcurrentFailuresLockObject) {
					_numberOfConcurrentFailures = value;
				}
			}
		}

		#endregion

		#endregion

		#region Methods

		/// <summary>
		/// Executes a search using the configured API settings and returns the deserialized search results.
		/// </summary>
		/// <returns>The deserialized search results.</returns>
		public SearchResult GetSearchResult() {

			const string BASE_URL = @"https://api.bestbuy.com/v1/products";

			var queryParameters = HttpUtility.ParseQueryString(string.Empty);
			queryParameters["apiKey"] = this.APIKey;
			queryParameters["format"] = @"json";

			var bestBuyQueryParameters = HttpUtility.ParseQueryString(string.Empty);
			bestBuyQueryParameters["sku"] = this.SkuNumber.ToString();

			var uriBuilder = new UriBuilder($"{BASE_URL}({bestBuyQueryParameters})") { Query = queryParameters.ToString() };
			var httpRequestMethod = new HttpRequestMessage(HttpMethod.Get, uriBuilder.Uri);

			using var httpClient = new HttpClient();
			var response = httpClient.SendAsync(httpRequestMethod);
			response.Wait();
			response.Result.EnsureSuccessStatusCode();
			if (response.Result.Content != null) {
				var contentResponse = response.Result.Content.ReadAsStringAsync();
				contentResponse.Wait();
				return System.Text.Json.JsonSerializer.Deserialize<SearchResult>(contentResponse.Result);
			}
			return null;
		}

		/// <summary>
		/// Executes a search against the BestBuy web services for the configured product and sends email notifications to the configured addresses if the product availability has recently changed.
		/// </summary>
		private void Search() {
			try {
				var result = this.GetSearchResult();
				this.SearchResultExecuted?.Invoke(new SearchResultEventArgs(result));
				var product = result.Products?.FirstOrDefault(product => product.Sku == this.SkuNumber);
				if (product != null) {

					if (this.IsProductCurrentlyAvailable != product.OnlineAvailability) {
						this.IsProductCurrentlyAvailable = product.OnlineAvailability;
						if (product.OnlineAvailability) {
							this.SendSuccessMessage(subjectText: $@"Order Link: {product.Name}", $@"Add to cart: {product.AddToCardUrl}");
						}
						else {
							this.SendSuccessMessage($@"Order Sold Out: {product.Name}", $@"Product '{product.Name}' has sold out online.'");
						}
					}

				}
				else {
					throw new Exception($"Product with sku number '{this.SkuNumber}' cannot be located.");
				}
				this.NumberConcurrentOfFailues = 0;

			}
			catch (Exception caught) {
				this.NumberConcurrentOfFailues++;
				if (this.NumberConcurrentOfFailues > 5) {
					this.Timer.Stop();
					this.SendFailureMessage(@"Program Failure", caught.Message);
				}
			}
		}

		/// <summary>
		/// Sends an email message using the configured SMTP email settings.
		/// </summary>
		/// <param name="subjectText"></param>
		/// <param name="messageText"></param>
		/// <param name="mailAddresses"></param>
		private void SendMessage(string subjectText, string messageText, MailAddressCollection mailAddresses) {
			if (mailAddresses?.Count > 0) {
				
				using var client = new SmtpClient(this.SMTPAddress, this.SMTPPort);
				using var message = new MailMessage();
				
				client.Credentials = new NetworkCredential(this.SMTPUserName, this.SMTPPassword);
				client.EnableSsl = this.SMTPEnableSSL;

				message.Subject = subjectText;
				message.Body = messageText;
				message.From = new MailAddress(this.SMTPUserName);
				foreach (var mailAddress in mailAddresses) {
					message.To.Add(mailAddress);
				}

				client.Send(message);
			}
		}

		/// <summary>
		/// Sends an email message to all registered success email addresses using the configured SMTP email settings.
		/// </summary>
		/// <param name="subjectText"></param>
		/// <param name="messageText"></param>
		/// <param name="mailAddresses"></param>
		public void SendSuccessMessage(string subjectText, string messageText) {
			this.SendMessage(subjectText, messageText, this.SuccessAddresses);
		}

		/// <summary>
		/// Sends an email message to all registered failure email addresses using the configured SMTP email settings.
		/// </summary>
		/// <param name="subjectText"></param>
		/// <param name="messageText"></param>
		/// <param name="mailAddresses"></param>
		public void SendFailureMessage(string subjectText, string messageText) {
			this.SendMessage(subjectText, messageText, this.FailureAddresses);
		}

		/// <summary>
		/// Construct a new <seealso cref="Timer"/> and begin querying the BestBuy web services for the specified product SKU.
		/// </summary>
		public void Start() {
			// Make sure the timer is stopped and reset before starting a new one.
			this.Stop();
			this.Timer.Start();
			this.Search();
		}

		/// <summary>
		/// Disable and dispose of the timer, if exists.
		/// </summary>
		public void Stop() {
			if (_timer != null) {
				if (_timer.Enabled) {
					_timer.Stop();
				}
				_timer.Dispose();
				_timer = null;
			}
		}

		#endregion

	}

}
