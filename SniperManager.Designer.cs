
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
			this.smtpEnableSslLabel = new System.Windows.Forms.Label();
			this.refreshIntervalLabel = new System.Windows.Forms.Label();
			this.apiKeyLabel = new System.Windows.Forms.Label();
			this.skuLabel = new System.Windows.Forms.Label();
			this.failureAddressLabel = new System.Windows.Forms.Label();
			this.successAddressLabel = new System.Windows.Forms.Label();
			this.smtpUserName = new System.Windows.Forms.TextBox();
			this.smtpEnableSsl = new System.Windows.Forms.CheckBox();
			this.start = new System.Windows.Forms.Button();
			this.dataGridView = new System.Windows.Forms.DataGridView();
			this.menuStrip = new System.Windows.Forms.MenuStrip();
			this.fileMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.saveConfigurationButton = new System.Windows.Forms.ToolStripMenuItem();
			this.tableLayoutPanel.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.smtpPort)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.refreshIntervalSeconds)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
			this.menuStrip.SuspendLayout();
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
			this.tableLayoutPanel.Controls.Add(this.smtpEnableSslLabel, 0, 4);
			this.tableLayoutPanel.Controls.Add(this.refreshIntervalLabel, 0, 5);
			this.tableLayoutPanel.Controls.Add(this.apiKeyLabel, 0, 6);
			this.tableLayoutPanel.Controls.Add(this.skuLabel, 0, 7);
			this.tableLayoutPanel.Controls.Add(this.failureAddressLabel, 0, 8);
			this.tableLayoutPanel.Controls.Add(this.successAddressLabel, 0, 9);
			this.tableLayoutPanel.Controls.Add(this.smtpUserName, 1, 0);
			this.tableLayoutPanel.Controls.Add(this.smtpEnableSsl, 1, 4);
			this.tableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Top;
			this.tableLayoutPanel.GrowStyle = System.Windows.Forms.TableLayoutPanelGrowStyle.FixedSize;
			this.tableLayoutPanel.Location = new System.Drawing.Point(0, 45);
			this.tableLayoutPanel.Name = "tableLayoutPanel";
			this.tableLayoutPanel.Padding = new System.Windows.Forms.Padding(6);
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
			this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 23F));
			this.tableLayoutPanel.Size = new System.Drawing.Size(1170, 490);
			this.tableLayoutPanel.TabIndex = 1;
			// 
			// smtpPort
			// 
			this.smtpPort.Location = new System.Drawing.Point(340, 156);
			this.smtpPort.Maximum = new decimal(new int[] {
            2147483647,
            0,
            0,
            0});
			this.smtpPort.Name = "smtpPort";
			this.smtpPort.Size = new System.Drawing.Size(277, 43);
			this.smtpPort.TabIndex = 24;
			// 
			// refreshIntervalSeconds
			// 
			this.refreshIntervalSeconds.Location = new System.Drawing.Point(340, 242);
			this.refreshIntervalSeconds.Maximum = new decimal(new int[] {
            2147483647,
            0,
            0,
            0});
			this.refreshIntervalSeconds.Name = "refreshIntervalSeconds";
			this.refreshIntervalSeconds.Size = new System.Drawing.Size(277, 43);
			this.refreshIntervalSeconds.TabIndex = 23;
			// 
			// successEmails
			// 
			this.successEmails.Dock = System.Windows.Forms.DockStyle.Fill;
			this.successEmails.Location = new System.Drawing.Point(340, 438);
			this.successEmails.Name = "successEmails";
			this.successEmails.Size = new System.Drawing.Size(821, 43);
			this.successEmails.TabIndex = 20;
			// 
			// failureEmails
			// 
			this.failureEmails.Dock = System.Windows.Forms.DockStyle.Fill;
			this.failureEmails.Location = new System.Drawing.Point(340, 389);
			this.failureEmails.Name = "failureEmails";
			this.failureEmails.Size = new System.Drawing.Size(821, 43);
			this.failureEmails.TabIndex = 19;
			// 
			// sku
			// 
			this.sku.Dock = System.Windows.Forms.DockStyle.Fill;
			this.sku.Location = new System.Drawing.Point(340, 340);
			this.sku.Name = "sku";
			this.sku.Size = new System.Drawing.Size(821, 43);
			this.sku.TabIndex = 18;
			// 
			// apiKey
			// 
			this.apiKey.Dock = System.Windows.Forms.DockStyle.Fill;
			this.apiKey.Location = new System.Drawing.Point(340, 291);
			this.apiKey.Name = "apiKey";
			this.apiKey.Size = new System.Drawing.Size(821, 43);
			this.apiKey.TabIndex = 17;
			// 
			// smtpAddress
			// 
			this.smtpAddress.Dock = System.Windows.Forms.DockStyle.Fill;
			this.smtpAddress.Location = new System.Drawing.Point(340, 107);
			this.smtpAddress.Name = "smtpAddress";
			this.smtpAddress.Size = new System.Drawing.Size(821, 43);
			this.smtpAddress.TabIndex = 13;
			// 
			// smtpPassword
			// 
			this.smtpPassword.Dock = System.Windows.Forms.DockStyle.Fill;
			this.smtpPassword.Location = new System.Drawing.Point(340, 58);
			this.smtpPassword.Name = "smtpPassword";
			this.smtpPassword.Size = new System.Drawing.Size(821, 43);
			this.smtpPassword.TabIndex = 12;
			this.smtpPassword.UseSystemPasswordChar = true;
			// 
			// smtpUserNameLabel
			// 
			this.smtpUserNameLabel.AutoSize = true;
			this.smtpUserNameLabel.Location = new System.Drawing.Point(9, 6);
			this.smtpUserNameLabel.Name = "smtpUserNameLabel";
			this.smtpUserNameLabel.Size = new System.Drawing.Size(228, 37);
			this.smtpUserNameLabel.TabIndex = 0;
			this.smtpUserNameLabel.Text = "SMTP User Name:";
			this.smtpUserNameLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// smtpPasswordLabel
			// 
			this.smtpPasswordLabel.AutoSize = true;
			this.smtpPasswordLabel.Location = new System.Drawing.Point(9, 55);
			this.smtpPasswordLabel.Name = "smtpPasswordLabel";
			this.smtpPasswordLabel.Size = new System.Drawing.Size(208, 37);
			this.smtpPasswordLabel.TabIndex = 2;
			this.smtpPasswordLabel.Text = "SMTP Password:";
			this.smtpPasswordLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// smtpAddressLabel
			// 
			this.smtpAddressLabel.AutoSize = true;
			this.smtpAddressLabel.Location = new System.Drawing.Point(9, 104);
			this.smtpAddressLabel.Name = "smtpAddressLabel";
			this.smtpAddressLabel.Size = new System.Drawing.Size(191, 37);
			this.smtpAddressLabel.TabIndex = 3;
			this.smtpAddressLabel.Text = "SMTP Address:";
			this.smtpAddressLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// smtpPortLabel
			// 
			this.smtpPortLabel.AutoSize = true;
			this.smtpPortLabel.Location = new System.Drawing.Point(9, 153);
			this.smtpPortLabel.Name = "smtpPortLabel";
			this.smtpPortLabel.Size = new System.Drawing.Size(145, 37);
			this.smtpPortLabel.TabIndex = 4;
			this.smtpPortLabel.Text = "SMTP Port:";
			this.smtpPortLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// smtpEnableSslLabel
			// 
			this.smtpEnableSslLabel.AutoSize = true;
			this.smtpEnableSslLabel.Location = new System.Drawing.Point(9, 202);
			this.smtpEnableSslLabel.Name = "smtpEnableSslLabel";
			this.smtpEnableSslLabel.Size = new System.Drawing.Size(277, 37);
			this.smtpEnableSslLabel.TabIndex = 5;
			this.smtpEnableSslLabel.Text = "SMTP Enable SSL/TLS:";
			this.smtpEnableSslLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// refreshIntervalLabel
			// 
			this.refreshIntervalLabel.AutoSize = true;
			this.refreshIntervalLabel.Location = new System.Drawing.Point(9, 239);
			this.refreshIntervalLabel.Name = "refreshIntervalLabel";
			this.refreshIntervalLabel.Size = new System.Drawing.Size(325, 37);
			this.refreshIntervalLabel.TabIndex = 6;
			this.refreshIntervalLabel.Text = "Refresh Interval (Seconds):";
			this.refreshIntervalLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// apiKeyLabel
			// 
			this.apiKeyLabel.AutoSize = true;
			this.apiKeyLabel.Location = new System.Drawing.Point(9, 288);
			this.apiKeyLabel.Name = "apiKeyLabel";
			this.apiKeyLabel.Size = new System.Drawing.Size(112, 37);
			this.apiKeyLabel.TabIndex = 7;
			this.apiKeyLabel.Text = "API Key:";
			this.apiKeyLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// skuLabel
			// 
			this.skuLabel.AutoSize = true;
			this.skuLabel.Location = new System.Drawing.Point(9, 337);
			this.skuLabel.Name = "skuLabel";
			this.skuLabel.Size = new System.Drawing.Size(65, 37);
			this.skuLabel.TabIndex = 8;
			this.skuLabel.Text = "Sku:";
			this.skuLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// failureAddressLabel
			// 
			this.failureAddressLabel.AutoSize = true;
			this.failureAddressLabel.Location = new System.Drawing.Point(9, 386);
			this.failureAddressLabel.Name = "failureAddressLabel";
			this.failureAddressLabel.Size = new System.Drawing.Size(200, 37);
			this.failureAddressLabel.TabIndex = 9;
			this.failureAddressLabel.Text = "Failure Email(s):";
			this.failureAddressLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// successAddressLabel
			// 
			this.successAddressLabel.AutoSize = true;
			this.successAddressLabel.Location = new System.Drawing.Point(9, 435);
			this.successAddressLabel.Name = "successAddressLabel";
			this.successAddressLabel.Size = new System.Drawing.Size(211, 37);
			this.successAddressLabel.TabIndex = 10;
			this.successAddressLabel.Text = "Success Email(s):";
			this.successAddressLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// smtpUserName
			// 
			this.smtpUserName.Dock = System.Windows.Forms.DockStyle.Fill;
			this.smtpUserName.Location = new System.Drawing.Point(340, 9);
			this.smtpUserName.Name = "smtpUserName";
			this.smtpUserName.Size = new System.Drawing.Size(821, 43);
			this.smtpUserName.TabIndex = 11;
			// 
			// smtpEnableSsl
			// 
			this.smtpEnableSsl.AutoSize = true;
			this.smtpEnableSsl.Location = new System.Drawing.Point(340, 205);
			this.smtpEnableSsl.Name = "smtpEnableSsl";
			this.smtpEnableSsl.Size = new System.Drawing.Size(28, 27);
			this.smtpEnableSsl.TabIndex = 22;
			this.smtpEnableSsl.UseVisualStyleBackColor = true;
			// 
			// start
			// 
			this.start.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.start.Location = new System.Drawing.Point(0, 677);
			this.start.Name = "start";
			this.start.Size = new System.Drawing.Size(1170, 53);
			this.start.TabIndex = 1;
			this.start.Text = "&Start Searching";
			this.start.UseVisualStyleBackColor = true;
			this.start.Click += new System.EventHandler(this.start_Click);
			// 
			// dataGridView
			// 
			this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
			this.dataGridView.Location = new System.Drawing.Point(0, 535);
			this.dataGridView.Name = "dataGridView";
			this.dataGridView.ReadOnly = true;
			this.dataGridView.RowHeadersWidth = 82;
			this.dataGridView.RowTemplate.Height = 41;
			this.dataGridView.Size = new System.Drawing.Size(1170, 195);
			this.dataGridView.TabIndex = 0;
			// 
			// menuStrip
			// 
			this.menuStrip.ImageScalingSize = new System.Drawing.Size(36, 36);
			this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileMenuItem});
			this.menuStrip.Location = new System.Drawing.Point(0, 0);
			this.menuStrip.Name = "menuStrip";
			this.menuStrip.Size = new System.Drawing.Size(1170, 45);
			this.menuStrip.TabIndex = 2;
			// 
			// fileMenuItem
			// 
			this.fileMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.saveConfigurationButton});
			this.fileMenuItem.Name = "fileMenuItem";
			this.fileMenuItem.Size = new System.Drawing.Size(98, 41);
			this.fileMenuItem.Text = "File...";
			// 
			// saveConfigurationButton
			// 
			this.saveConfigurationButton.Name = "saveConfigurationButton";
			this.saveConfigurationButton.Size = new System.Drawing.Size(393, 48);
			this.saveConfigurationButton.Text = "&Save Configuration";
			this.saveConfigurationButton.ToolTipText = "Save the current values to the configuration file.";
			// 
			// SniperManager
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(15F, 37F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1170, 730);
			this.Controls.Add(this.start);
			this.Controls.Add(this.dataGridView);
			this.Controls.Add(this.tableLayoutPanel);
			this.Controls.Add(this.menuStrip);
			this.DoubleBuffered = true;
			this.Name = "SniperManager";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "BestBuy Sniper Manager";
			this.tableLayoutPanel.ResumeLayout(false);
			this.tableLayoutPanel.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.smtpPort)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.refreshIntervalSeconds)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
			this.menuStrip.ResumeLayout(false);
			this.menuStrip.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel;
		private System.Windows.Forms.Label smtpUserNameLabel;
		private System.Windows.Forms.Label smtpPasswordLabel;
		private System.Windows.Forms.Label smtpAddressLabel;
		private System.Windows.Forms.Label smtpPortLabel;
		private System.Windows.Forms.Label smtpEnableSslLabel;
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
		private System.Windows.Forms.CheckBox smtpEnableSsl;
		private System.Windows.Forms.NumericUpDown smtpPort;
		private System.Windows.Forms.NumericUpDown refreshIntervalSeconds;
		private System.Windows.Forms.DataGridView dataGridView;
		private System.Windows.Forms.Button start;
		private System.Windows.Forms.MenuStrip menuStrip;
		private System.Windows.Forms.ToolStripMenuItem fileMenuItem;
		private System.Windows.Forms.ToolStripMenuItem saveConfigurationButton;
	}
}