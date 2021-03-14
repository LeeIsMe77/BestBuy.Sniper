﻿using System;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Windows.Forms;
using System.Xml.Linq;
using static BestBuy.Sniper.Client.BestBuyRequestManager;

namespace BestBuy.Sniper.Client {

	public partial class SniperManager
		: Form {

		#region Properties

		private BestBuyRequestManager RequestManager { get; set; }

		#endregion

		#region Constructors

		public SniperManager() {
			this.InitializeComponent();
			start.Text = this.RequestManager == null ? @"Start" : @"Stop";
		}

		#endregion

		#region Methods

		protected override void OnLoad(EventArgs e) {
			base.OnLoad(e);

			#region Load settings into the form.
			var rootPath = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
			var configurationPath = Path.Combine(rootPath, @"configuration.xml");

			static string SafeElementValue(XElement element, string elementName) {
				return element?.Element(elementName)?.Value is string returnValue && !string.IsNullOrWhiteSpace(returnValue)
					? returnValue
					: null;
			}

			if (File.Exists(configurationPath)) {
				try {
					var configuration = XElement.Load(configurationPath);
					smtpUserName.Text = SafeElementValue(configuration, @"SMTPUserName");
					smtpPassword.Text = SafeElementValue(configuration, @"SMTPPassword");
					smtpAddress.Text = SafeElementValue(configuration, @"SMTPAddress");
					smtpPort.Value = int.TryParse(SafeElementValue(configuration, @"SMTPPortNumber"), out var portNumber) ? portNumber : 0;
					var tempEnableSsl = SafeElementValue(configuration, @"SMTPEnableSsl");
					enableSsl.Checked = new[] { bool.TrueString, @"1", @"T", @"Y", @"Yes" }.Any(value => string.Equals(value, tempEnableSsl, StringComparison.OrdinalIgnoreCase));
					refreshIntervalSeconds.Value = int.TryParse(SafeElementValue(configuration, @"BestBuyRefreshInterval"), out var interval) ? interval : 15;
					apiKey.Text = SafeElementValue(configuration, @"BestBuyAPIKey");
					sku.Text = SafeElementValue(configuration, @"BestBuySku");

					failureEmails.Text = SafeElementValue(configuration, @"SMTPFailureEmailAddresses");
					successEmails.Text = SafeElementValue(configuration, @"SMTPAvailabilityEmailAddresses");
				}
				catch (Exception caught) {
					Console.WriteLine($@"Failed to read configuration file at location '{configurationPath}'");
					Console.WriteLine(caught.Message);
				}
			}
			#endregion

		}

		private void SearchExecuted(SearchResultEventArgs e) {
			try {
				if (dataGridView.InvokeRequired) {
					dataGridView.BeginInvoke(new SearchResultExecutedDelegate(this.SearchExecuted), e);
				}
				else {
					dataGridView.DataSource = e.SearchResult.Products;
				}
			}
			catch (Exception) {

			}
		}

		private void Start() {

			try {

				#region Verify fields
				var errorBuilder = new StringBuilder();
				if (string.IsNullOrWhiteSpace(smtpUserName.Text)) {
					errorBuilder.AppendLine(@"The SMTP User Name must be provided.");
				}

				if (string.IsNullOrWhiteSpace(smtpPassword.Text)) {
					errorBuilder.AppendLine(@"The SMTP Password must be provided.");
				}

				if (string.IsNullOrWhiteSpace(smtpAddress.Text)) {
					errorBuilder.AppendLine(@"The SMTP Address must be provided.");
				}

				if ((int)smtpPort.Value == 0 || (int)smtpPort.Value < -1) {
					errorBuilder.AppendLine(@"The SMTP Port must be an integer greater than 0 or equal to -1 (default port for scheme).");
				}

				if (string.IsNullOrWhiteSpace(apiKey.Text)) {
					errorBuilder.AppendLine(@"The API Key must be provided.");
				}

				if (string.IsNullOrWhiteSpace(sku.Text)) {
					errorBuilder.AppendLine(@"The Product Sku must be provided.");
				}

				if (!long.TryParse(sku.Text, NumberStyles.Integer, CultureInfo.InvariantCulture, out var skuNumber)) {
					throw new Exception($"The value '{sku.Text}' is not a valid sku number.");
				}

				static MailAddressCollection ParseMailAddress(string mailAddress) {
					if (!string.IsNullOrWhiteSpace(mailAddress) && mailAddress.Split(new[] { ';', ',' }, StringSplitOptions.RemoveEmptyEntries) is string[] messageArray && messageArray.Length > 0) {
						var emailAddresses = new MailAddressCollection();
						foreach (var emailAddress in messageArray) {
							emailAddresses.Add(emailAddress);
						}
						return emailAddresses;
					}
					return null;
				}

				MailAddressCollection failureAddresses = null;
				try {
					failureAddresses = ParseMailAddress(failureEmails.Text);
				}
				catch (Exception caught) {
					errorBuilder.AppendLine($"Failed to parse failure email addresses: {caught.Message}");
				}

				MailAddressCollection successAddresses = null;
				try {
					successAddresses = ParseMailAddress(successEmails.Text);
				}
				catch (Exception caught) {
					errorBuilder.AppendLine($"Failed to parse success email addresses: {caught.Message}");
				}

				if (errorBuilder.Length > 0) {
					throw new Exception($"Failed validating parameters: {errorBuilder}");
				}

				var refresh = Math.Max((int)refreshIntervalSeconds.Value, 15);

				#endregion

				this.RequestManager = new BestBuyRequestManager {
					APIKey = apiKey.Text,
					FailureAddresses = failureAddresses,
					RefreshIntervalSeconds = refresh,
					SkuNumber = skuNumber,
					SMTPAddress = smtpAddress.Text,
					SMTPEnableSSL = enableSsl.Checked,
					SMTPPassword = smtpPassword.Text,
					SMTPPort = (int)smtpPort.Value,
					SMTPUserName = smtpUserName.Text,
					SuccessAddresses = successAddresses
				};

				this.RequestManager.SearchResultExecuted += new SearchResultExecutedDelegate(this.SearchExecuted);
				var result = MessageBox.Show(this, @"Would you like to send a test message to the registered success email addresses?", @"Send Test Message?", MessageBoxButtons.YesNo, MessageBoxIcon.Error);
				if (result == DialogResult.Yes) {
					this.RequestManager.SendSuccessMessage(
						@"Test",
						$@"This is a test message. Monitoring for product with sku '{skuNumber}' has begun."
						);
				}

				this.RequestManager.Start();
				tableLayoutPanel.Enabled = false;

			}
			catch (Exception caught) {
				MessageBox.Show(this, caught.Message, @"Failure Starting Sniper...", MessageBoxButtons.OK, MessageBoxIcon.Error);

				this.RequestManager?.Stop();
				this.RequestManager = null;
			}
		}

		private void Stop() {
			if (this.RequestManager != null) {
				this.RequestManager.Stop();
				this.RequestManager = null;
			}
			tableLayoutPanel.Enabled = true;
		}

		#endregion

		#region Control Events

		private void start_Click(object sender, EventArgs e) {
			try {
				if (sender is Button button) {
					switch (button.Text.ToUpperInvariant()) {
						case @"START":
							this.Start();
							button.Text = @"Stop";
							break;
						default:
						case @"STOP":
							this.Stop();
							button.Text = @"Start";
							break;
					}
				}
			}
			catch (Exception caught) {
				MessageBox.Show(this, caught.Message);
			}
		}

		#endregion

	}
}