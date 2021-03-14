
namespace BestBuy.Sniper.Client {
	partial class SniperManager {
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing) {
			if (disposing && (components != null)) {
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent() {
			this.tableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
			this.smtpPort = new System.Windows.Forms.NumericUpDown();
			this.refreshIntervalSeconds = new System.Windows.Forms.NumericUpDown();
			this.successEmails = new System.Windows.Forms.TextBox();
			this.failureEmails = new System.Windows.Forms.TextBox();
			this.sku = new System.Windows.Forms.TextBox();
			this.apiKey = new System.Windows.Forms.TextBox();
			this.smtpAddress = new System.Windows.Forms.TextBox();
			this.smtpPassword = new System.Windows.Forms.TextBox();
			this.smtpUserNameLabel = new System.Windows.Forms.Label();
			this.smtpPasswordLabel = new System.Windows.Forms.Label();
			this.smtpAddressLabel = new System.Windows.Forms.Label();
			this.smtpPortLabel = new System.Windows.Forms.Label();
			this.smtpSslTls = new System.Windows.Forms.Label();
			this.refreshIntervalLabel = new System.Windows.Forms.Label();
			this.apiKeyLabel = new System.Windows.Forms.Label();
			this.skuLabel = new System.Windows.Forms.Label();
			this.failureAddressLabel = new System.Windows.Forms.Label();
			this.successAddressLabel = new System.Windows.Forms.Label();
			this.smtpUserName = new System.Windows.Forms.TextBox();
			this.enableSsl = new System.Windows.Forms.CheckBox();
			this.start = new System.Windows.Forms.Button();
			this.dataGridView = new System.Windows.Forms.DataGridView();
			this.tableLayoutPanel.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.smtpPort)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.refreshIntervalSeconds)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
			this.SuspendLayout();
			// 
			// tableLayoutPanel
			// 
			this.tableLayoutPanel.AutoSize = true;
			this.tableLayoutPanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.tableLayoutPanel.ColumnCount = 2;
			this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutPanel.Controls.Add(this.smtpPort, 1, 3);
			this.tableLayoutPanel.Controls.Add(this.refreshIntervalSeconds, 1, 5);
			this.tableLayoutPanel.Controls.Add(this.successEmails, 1, 9);
			this.tableLayoutPanel.Controls.Add(this.failureEmails, 1, 8);
			this.tableLayoutPanel.Controls.Add(this.sku, 1, 7);
			this.tableLayoutPanel.Controls.Add(this.apiKey, 1, 6);
			this.tableLayoutPanel.Controls.Add(this.smtpAddress, 1, 2);
			this.tableLayoutPanel.Controls.Add(this.smtpPassword, 1, 1);
			this.tableLayoutPanel.Controls.Add(this.smtpUserNameLabel, 0, 0);
			this.tableLayoutPanel.Controls.Add(this.smtpPasswordLabel, 0, 1);
			this.tableLayoutPanel.Controls.Add(this.smtpAddressLabel, 0, 2);
			this.tableLayoutPanel.Controls.Add(this.smtpPortLabel, 0, 3);
			this.tableLayoutPanel.Controls.Add(this.smtpSslTls, 0, 4);
			this.tableLayoutPanel.Controls.Add(this.refreshIntervalLabel, 0, 5);
			this.tableLayoutPanel.Controls.Add(this.apiKeyLabel, 0, 6);
			this.tableLayoutPanel.Controls.Add(this.skuLabel, 0, 7);
			this.tableLayoutPanel.Controls.Add(this.failureAddressLabel, 0, 8);
			this.tableLayoutPanel.Controls.Add(this.successAddressLabel, 0, 9);
			this.tableLayoutPanel.Controls.Add(this.smtpUserName, 1, 0);
			this.tableLayoutPanel.Controls.Add(this.enableSsl, 1, 4);
			this.tableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Top;
			this.tableLayoutPanel.GrowStyle = System.Windows.Forms.TableLayoutPanelGrowStyle.FixedSize;
			this.tableLayoutPanel.Location = new System.Drawing.Point(0, 0);
			this.tableLayoutPanel.Name = "tableLayoutPanel";
			this.tableLayoutPanel.Padding = new System.Windows.Forms.Padding(5);
			this.tableLayoutPanel.RowCount = 10;
			this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
			this.tableLayoutPanel.Size = new System.Drawing.Size(1014, 448);
			this.tableLayoutPanel.TabIndex = 1;
			// 
			// smtpPort
			// 
			this.smtpPort.Location = new System.Drawing.Point(308, 143);
			this.smtpPort.Maximum = new decimal(new int[] {
            2147483647,
            0,
            0,
            0});
			this.smtpPort.Name = "smtpPort";
			this.smtpPort.Size = new System.Drawing.Size(240, 39);
			this.smtpPort.TabIndex = 24;
			// 
			// refreshIntervalSeconds
			// 
			this.refreshIntervalSeconds.Location = new System.Drawing.Point(308, 221);
			this.refreshIntervalSeconds.Maximum = new decimal(new int[] {
            2147483647,
            0,
            0,
            0});
			this.refreshIntervalSeconds.Name = "refreshIntervalSeconds";
			this.refreshIntervalSeconds.Size = new System.Drawing.Size(240, 39);
			this.refreshIntervalSeconds.TabIndex = 23;
			// 
			// successEmails
			// 
			this.successEmails.Dock = System.Windows.Forms.DockStyle.Fill;
			this.successEmails.Location = new System.Drawing.Point(308, 401);
			this.successEmails.Name = "successEmails";
			this.successEmails.Size = new System.Drawing.Size(698, 39);
			this.successEmails.TabIndex = 20;
			// 
			// failureEmails
			// 
			this.failureEmails.Dock = System.Windows.Forms.DockStyle.Fill;
			this.failureEmails.Location = new System.Drawing.Point(308, 356);
			this.failureEmails.Name = "failureEmails";
			this.failureEmails.Size = new System.Drawing.Size(698, 39);
			this.failureEmails.TabIndex = 19;
			// 
			// sku
			// 
			this.sku.Dock = System.Windows.Forms.DockStyle.Fill;
			this.sku.Location = new System.Drawing.Point(308, 311);
			this.sku.Name = "sku";
			this.sku.Size = new System.Drawing.Size(698, 39);
			this.sku.TabIndex = 18;
			// 
			// apiKey
			// 
			this.apiKey.Dock = System.Windows.Forms.DockStyle.Fill;
			this.apiKey.Location = new System.Drawing.Point(308, 266);
			this.apiKey.Name = "apiKey";
			this.apiKey.Size = new System.Drawing.Size(698, 39);
			this.apiKey.TabIndex = 17;
			// 
			// smtpAddress
			// 
			this.smtpAddress.Dock = System.Windows.Forms.DockStyle.Fill;
			this.smtpAddress.Location = new System.Drawing.Point(308, 98);
			this.smtpAddress.Name = "smtpAddress";
			this.smtpAddress.Size = new System.Drawing.Size(698, 39);
			this.smtpAddress.TabIndex = 13;
			// 
			// smtpPassword
			// 
			this.smtpPassword.Dock = System.Windows.Forms.DockStyle.Fill;
			this.smtpPassword.Location = new System.Drawing.Point(308, 53);
			this.smtpPassword.Name = "smtpPassword";
			this.smtpPassword.Size = new System.Drawing.Size(698, 39);
			this.smtpPassword.TabIndex = 12;
			this.smtpPassword.UseSystemPasswordChar = true;
			// 
			// smtpUserNameLabel
			// 
			this.smtpUserNameLabel.AutoSize = true;
			this.smtpUserNameLabel.Location = new System.Drawing.Point(8, 5);
			this.smtpUserNameLabel.Name = "smtpUserNameLabel";
			this.smtpUserNameLabel.Size = new System.Drawing.Size(205, 32);
			this.smtpUserNameLabel.TabIndex = 0;
			this.smtpUserNameLabel.Text = "SMTP User Name:";
			this.smtpUserNameLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// smtpPasswordLabel
			// 
			this.smtpPasswordLabel.AutoSize = true;
			this.smtpPasswordLabel.Location = new System.Drawing.Point(8, 50);
			this.smtpPasswordLabel.Name = "smtpPasswordLabel";
			this.smtpPasswordLabel.Size = new System.Drawing.Size(184, 32);
			this.smtpPasswordLabel.TabIndex = 2;
			this.smtpPasswordLabel.Text = "SMTP Password:";
			this.smtpPasswordLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// smtpAddressLabel
			// 
			this.smtpAddressLabel.AutoSize = true;
			this.smtpAddressLabel.Location = new System.Drawing.Point(8, 95);
			this.smtpAddressLabel.Name = "smtpAddressLabel";
			this.smtpAddressLabel.Size = new System.Drawing.Size(171, 32);
			this.smtpAddressLabel.TabIndex = 3;
			this.smtpAddressLabel.Text = "SMTP Address:";
			this.smtpAddressLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// smtpPortLabel
			// 
			this.smtpPortLabel.AutoSize = true;
			this.smtpPortLabel.Location = new System.Drawing.Point(8, 140);
			this.smtpPortLabel.Name = "smtpPortLabel";
			this.smtpPortLabel.Size = new System.Drawing.Size(129, 32);
			this.smtpPortLabel.TabIndex = 4;
			this.smtpPortLabel.Text = "SMTP Port:";
			this.smtpPortLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// smtpSslTls
			// 
			this.smtpSslTls.AutoSize = true;
			this.smtpSslTls.Location = new System.Drawing.Point(8, 185);
			this.smtpSslTls.Name = "smtpSslTls";
			this.smtpSslTls.Size = new System.Drawing.Size(248, 32);
			this.smtpSslTls.TabIndex = 5;
			this.smtpSslTls.Text = "SMTP Enable SSL/TLS:";
			this.smtpSslTls.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// refreshIntervalLabel
			// 
			this.refreshIntervalLabel.AutoSize = true;
			this.refreshIntervalLabel.Location = new System.Drawing.Point(8, 218);
			this.refreshIntervalLabel.Name = "refreshIntervalLabel";
			this.refreshIntervalLabel.Size = new System.Drawing.Size(294, 32);
			this.refreshIntervalLabel.TabIndex = 6;
			this.refreshIntervalLabel.Text = "Refresh Interval (Seconds):";
			this.refreshIntervalLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// apiKeyLabel
			// 
			this.apiKeyLabel.AutoSize = true;
			this.apiKeyLabel.Location = new System.Drawing.Point(8, 263);
			this.apiKeyLabel.Name = "apiKeyLabel";
			this.apiKeyLabel.Size = new System.Drawing.Size(99, 32);
			this.apiKeyLabel.TabIndex = 7;
			this.apiKeyLabel.Text = "API Key:";
			this.apiKeyLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// skuLabel
			// 
			this.skuLabel.AutoSize = true;
			this.skuLabel.Location = new System.Drawing.Point(8, 308);
			this.skuLabel.Name = "skuLabel";
			this.skuLabel.Size = new System.Drawing.Size(58, 32);
			this.skuLabel.TabIndex = 8;
			this.skuLabel.Text = "Sku:";
			this.skuLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// failureAddressLabel
			// 
			this.failureAddressLabel.AutoSize = true;
			this.failureAddressLabel.Location = new System.Drawing.Point(8, 353);
			this.failureAddressLabel.Name = "failureAddressLabel";
			this.failureAddressLabel.Size = new System.Drawing.Size(177, 32);
			this.failureAddressLabel.TabIndex = 9;
			this.failureAddressLabel.Text = "Failure Email(s):";
			this.failureAddressLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// successAddressLabel
			// 
			this.successAddressLabel.AutoSize = true;
			this.successAddressLabel.Location = new System.Drawing.Point(8, 398);
			this.successAddressLabel.Name = "successAddressLabel";
			this.successAddressLabel.Size = new System.Drawing.Size(189, 32);
			this.successAddressLabel.TabIndex = 10;
			this.successAddressLabel.Text = "Success Email(s):";
			this.successAddressLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// smtpUserName
			// 
			this.smtpUserName.Dock = System.Windows.Forms.DockStyle.Fill;
			this.smtpUserName.Location = new System.Drawing.Point(308, 8);
			this.smtpUserName.Name = "smtpUserName";
			this.smtpUserName.Size = new System.Drawing.Size(698, 39);
			this.smtpUserName.TabIndex = 11;
			// 
			// enableSsl
			// 
			this.enableSsl.AutoSize = true;
			this.enableSsl.Location = new System.Drawing.Point(308, 188);
			this.enableSsl.Name = "enableSsl";
			this.enableSsl.Size = new System.Drawing.Size(28, 27);
			this.enableSsl.TabIndex = 22;
			this.enableSsl.UseVisualStyleBackColor = true;
			// 
			// start
			// 
			this.start.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.start.Location = new System.Drawing.Point(852, 556);
			this.start.Name = "start";
			this.start.Size = new System.Drawing.Size(150, 46);
			this.start.TabIndex = 1;
			this.start.Text = "Start";
			this.start.UseVisualStyleBackColor = true;
			this.start.Click += new System.EventHandler(this.start_Click);
			// 
			// dataGridView
			// 
			this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
			this.dataGridView.Location = new System.Drawing.Point(0, 448);
			this.dataGridView.Name = "dataGridView";
			this.dataGridView.ReadOnly = true;
			this.dataGridView.RowHeadersWidth = 82;
			this.dataGridView.RowTemplate.Height = 41;
			this.dataGridView.Size = new System.Drawing.Size(1014, 183);
			this.dataGridView.TabIndex = 0;
			// 
			// SniperManager
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(13F, 32F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1014, 631);
			this.Controls.Add(this.start);
			this.Controls.Add(this.dataGridView);
			this.Controls.Add(this.tableLayoutPanel);
			this.DoubleBuffered = true;
			this.Name = "SniperManager";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "BestBuy Sniper Manager";
			this.tableLayoutPanel.ResumeLayout(false);
			this.tableLayoutPanel.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.smtpPort)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.refreshIntervalSeconds)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel;
		private System.Windows.Forms.Label smtpUserNameLabel;
		private System.Windows.Forms.Label smtpPasswordLabel;
		private System.Windows.Forms.Label smtpAddressLabel;
		private System.Windows.Forms.Label smtpPortLabel;
		private System.Windows.Forms.Label smtpSslTls;
		private System.Windows.Forms.Label refreshIntervalLabel;
		private System.Windows.Forms.Label apiKeyLabel;
		private System.Windows.Forms.Label skuLabel;
		private System.Windows.Forms.Label failureAddressLabel;
		private System.Windows.Forms.Label successAddressLabel;
		private System.Windows.Forms.TextBox successEmails;
		private System.Windows.Forms.TextBox failureEmails;
		private System.Windows.Forms.TextBox sku;
		private System.Windows.Forms.TextBox apiKey;
		private System.Windows.Forms.TextBox smtpAddress;
		private System.Windows.Forms.TextBox smtpPassword;
		private System.Windows.Forms.TextBox smtpUserName;
		private System.Windows.Forms.CheckBox enableSsl;
		private System.Windows.Forms.NumericUpDown smtpPort;
		private System.Windows.Forms.NumericUpDown refreshIntervalSeconds;
		private System.Windows.Forms.DataGridView dataGridView;
		private System.Windows.Forms.Button start;
	}
}