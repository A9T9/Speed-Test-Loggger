namespace SpeedTest
{
    partial class FormSettings
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormSettings));
            this.TextLogFile = new System.Windows.Forms.TextBox();
            this.ButtonLogFile = new System.Windows.Forms.Button();
            this.LabelLogFile = new System.Windows.Forms.Label();
            this.ComboCheckConnection = new System.Windows.Forms.ComboBox();
            this.LabelCheckConnection = new System.Windows.Forms.Label();
            this.GroupTimeFormat = new System.Windows.Forms.GroupBox();
            this.RadioUSFormat = new System.Windows.Forms.RadioButton();
            this.RadioEUFormat = new System.Windows.Forms.RadioButton();
            this.RadioISOFormat = new System.Windows.Forms.RadioButton();
            this.CheckAutoStart = new System.Windows.Forms.CheckBox();
            this.CheckMinimize = new System.Windows.Forms.CheckBox();
            this.ButtonOK = new System.Windows.Forms.Button();
            this.ButtonOpenLog = new System.Windows.Forms.Button();
            this.TextDownloadURL = new System.Windows.Forms.TextBox();
            this.GroupDownloadURL = new System.Windows.Forms.GroupBox();
            this.RadioCustomDownload = new System.Windows.Forms.RadioButton();
            this.RadioAutoDownload = new System.Windows.Forms.RadioButton();
            this.GroupSpeedUnits = new System.Windows.Forms.GroupBox();
            this.RadioBytesPerSecond = new System.Windows.Forms.RadioButton();
            this.RadioBitsPerSecond = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.GroupAPIURL = new System.Windows.Forms.GroupBox();
            this.TextIPDetectURL = new System.Windows.Forms.TextBox();
            this.RadioCustomIPDetect = new System.Windows.Forms.RadioButton();
            this.RadioAutoDetectIP = new System.Windows.Forms.RadioButton();
            this.GroupTimeFormat.SuspendLayout();
            this.GroupDownloadURL.SuspendLayout();
            this.GroupSpeedUnits.SuspendLayout();
            this.GroupAPIURL.SuspendLayout();
            this.SuspendLayout();
            // 
            // TextLogFile
            // 
            this.TextLogFile.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TextLogFile.BackColor = System.Drawing.SystemColors.Window;
            this.TextLogFile.Location = new System.Drawing.Point(110, 372);
            this.TextLogFile.Name = "TextLogFile";
            this.TextLogFile.ReadOnly = true;
            this.TextLogFile.Size = new System.Drawing.Size(176, 20);
            this.TextLogFile.TabIndex = 12;
            // 
            // ButtonLogFile
            // 
            this.ButtonLogFile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ButtonLogFile.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.ButtonLogFile.Location = new System.Drawing.Point(292, 370);
            this.ButtonLogFile.Name = "ButtonLogFile";
            this.ButtonLogFile.Size = new System.Drawing.Size(40, 25);
            this.ButtonLogFile.TabIndex = 13;
            this.ButtonLogFile.Text = "...";
            this.ButtonLogFile.UseVisualStyleBackColor = true;
            this.ButtonLogFile.Click += new System.EventHandler(this.ButtonLogFile_Click);
            // 
            // LabelLogFile
            // 
            this.LabelLogFile.AutoSize = true;
            this.LabelLogFile.Location = new System.Drawing.Point(10, 375);
            this.LabelLogFile.Name = "LabelLogFile";
            this.LabelLogFile.Size = new System.Drawing.Size(77, 13);
            this.LabelLogFile.TabIndex = 11;
            this.LabelLogFile.Text = "Log file (.CSV):";
            // 
            // ComboCheckConnection
            // 
            this.ComboCheckConnection.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ComboCheckConnection.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ComboCheckConnection.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.ComboCheckConnection.FormattingEnabled = true;
            this.ComboCheckConnection.Items.AddRange(new object[] {
            "10 Minutes",
            "30 Minutes",
            "1 Hour"});
            this.ComboCheckConnection.Location = new System.Drawing.Point(122, 409);
            this.ComboCheckConnection.Name = "ComboCheckConnection";
            this.ComboCheckConnection.Size = new System.Drawing.Size(82, 21);
            this.ComboCheckConnection.TabIndex = 15;
            this.ComboCheckConnection.SelectedIndexChanged += new System.EventHandler(this.ComboCheckConnection_SelectedIndexChanged);
            // 
            // LabelCheckConnection
            // 
            this.LabelCheckConnection.AutoSize = true;
            this.LabelCheckConnection.Location = new System.Drawing.Point(10, 412);
            this.LabelCheckConnection.Name = "LabelCheckConnection";
            this.LabelCheckConnection.Size = new System.Drawing.Size(102, 13);
            this.LabelCheckConnection.TabIndex = 14;
            this.LabelCheckConnection.Text = "Check speed every:";
            // 
            // GroupTimeFormat
            // 
            this.GroupTimeFormat.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.GroupTimeFormat.Controls.Add(this.RadioUSFormat);
            this.GroupTimeFormat.Controls.Add(this.RadioEUFormat);
            this.GroupTimeFormat.Controls.Add(this.RadioISOFormat);
            this.GroupTimeFormat.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.GroupTimeFormat.Location = new System.Drawing.Point(12, 180);
            this.GroupTimeFormat.Name = "GroupTimeFormat";
            this.GroupTimeFormat.Size = new System.Drawing.Size(320, 96);
            this.GroupTimeFormat.TabIndex = 4;
            this.GroupTimeFormat.TabStop = false;
            this.GroupTimeFormat.Text = "Date and Time Format";
            // 
            // RadioUSFormat
            // 
            this.RadioUSFormat.AutoSize = true;
            this.RadioUSFormat.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.RadioUSFormat.Location = new System.Drawing.Point(14, 67);
            this.RadioUSFormat.Name = "RadioUSFormat";
            this.RadioUSFormat.Size = new System.Drawing.Size(198, 18);
            this.RadioUSFormat.TabIndex = 7;
            this.RadioUSFormat.TabStop = true;
            this.RadioUSFormat.Text = "US Format - mm/dd/yyyy 12h clock";
            this.RadioUSFormat.UseVisualStyleBackColor = true;
            // 
            // RadioEUFormat
            // 
            this.RadioEUFormat.AutoSize = true;
            this.RadioEUFormat.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.RadioEUFormat.Location = new System.Drawing.Point(14, 44);
            this.RadioEUFormat.Name = "RadioEUFormat";
            this.RadioEUFormat.Size = new System.Drawing.Size(198, 18);
            this.RadioEUFormat.TabIndex = 6;
            this.RadioEUFormat.TabStop = true;
            this.RadioEUFormat.Text = "EU Format - dd/mm/yyyy 24h clock";
            this.RadioEUFormat.UseVisualStyleBackColor = true;
            // 
            // RadioISOFormat
            // 
            this.RadioISOFormat.AutoSize = true;
            this.RadioISOFormat.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.RadioISOFormat.Location = new System.Drawing.Point(14, 21);
            this.RadioISOFormat.Name = "RadioISOFormat";
            this.RadioISOFormat.Size = new System.Drawing.Size(261, 18);
            this.RadioISOFormat.TabIndex = 5;
            this.RadioISOFormat.TabStop = true;
            this.RadioISOFormat.Text = "One World (ISO Format) - yyyy/mm/dd 24h clock";
            this.RadioISOFormat.UseVisualStyleBackColor = true;
            // 
            // CheckAutoStart
            // 
            this.CheckAutoStart.AutoSize = true;
            this.CheckAutoStart.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.CheckAutoStart.Location = new System.Drawing.Point(13, 448);
            this.CheckAutoStart.Name = "CheckAutoStart";
            this.CheckAutoStart.Size = new System.Drawing.Size(143, 18);
            this.CheckAutoStart.TabIndex = 16;
            this.CheckAutoStart.Text = "Autostart with Windows";
            this.CheckAutoStart.UseVisualStyleBackColor = true;
            // 
            // CheckMinimize
            // 
            this.CheckMinimize.AutoSize = true;
            this.CheckMinimize.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.CheckMinimize.Location = new System.Drawing.Point(181, 448);
            this.CheckMinimize.Name = "CheckMinimize";
            this.CheckMinimize.Size = new System.Drawing.Size(139, 18);
            this.CheckMinimize.TabIndex = 17;
            this.CheckMinimize.Text = "Minimize to system tray";
            this.CheckMinimize.UseVisualStyleBackColor = true;
            // 
            // ButtonOK
            // 
            this.ButtonOK.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.ButtonOK.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.ButtonOK.Location = new System.Drawing.Point(12, 487);
            this.ButtonOK.Name = "ButtonOK";
            this.ButtonOK.Size = new System.Drawing.Size(157, 26);
            this.ButtonOK.TabIndex = 18;
            this.ButtonOK.Text = "&OK";
            this.ButtonOK.UseVisualStyleBackColor = true;
            this.ButtonOK.Click += new System.EventHandler(this.ButtonOK_Click);
            // 
            // ButtonOpenLog
            // 
            this.ButtonOpenLog.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.ButtonOpenLog.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.ButtonOpenLog.Location = new System.Drawing.Point(175, 487);
            this.ButtonOpenLog.Name = "ButtonOpenLog";
            this.ButtonOpenLog.Size = new System.Drawing.Size(157, 26);
            this.ButtonOpenLog.TabIndex = 19;
            this.ButtonOpenLog.Text = "&Open Log File...";
            this.ButtonOpenLog.UseVisualStyleBackColor = true;
            this.ButtonOpenLog.Click += new System.EventHandler(this.ButtonOpenLog_Click);
            // 
            // TextDownloadURL
            // 
            this.TextDownloadURL.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TextDownloadURL.Enabled = false;
            this.TextDownloadURL.Location = new System.Drawing.Point(98, 43);
            this.TextDownloadURL.Name = "TextDownloadURL";
            this.TextDownloadURL.Size = new System.Drawing.Size(210, 20);
            this.TextDownloadURL.TabIndex = 3;
            // 
            // GroupDownloadURL
            // 
            this.GroupDownloadURL.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.GroupDownloadURL.Controls.Add(this.RadioCustomDownload);
            this.GroupDownloadURL.Controls.Add(this.RadioAutoDownload);
            this.GroupDownloadURL.Controls.Add(this.TextDownloadURL);
            this.GroupDownloadURL.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.GroupDownloadURL.Location = new System.Drawing.Point(12, 12);
            this.GroupDownloadURL.Name = "GroupDownloadURL";
            this.GroupDownloadURL.Size = new System.Drawing.Size(320, 78);
            this.GroupDownloadURL.TabIndex = 0;
            this.GroupDownloadURL.TabStop = false;
            this.GroupDownloadURL.Text = "Download URL";
            // 
            // RadioCustomDownload
            // 
            this.RadioCustomDownload.AutoSize = true;
            this.RadioCustomDownload.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.RadioCustomDownload.Location = new System.Drawing.Point(14, 44);
            this.RadioCustomDownload.Name = "RadioCustomDownload";
            this.RadioCustomDownload.Size = new System.Drawing.Size(69, 18);
            this.RadioCustomDownload.TabIndex = 2;
            this.RadioCustomDownload.TabStop = true;
            this.RadioCustomDownload.Text = "Custom:";
            this.RadioCustomDownload.UseVisualStyleBackColor = true;
            // 
            // RadioAutoDownload
            // 
            this.RadioAutoDownload.AutoSize = true;
            this.RadioAutoDownload.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.RadioAutoDownload.Location = new System.Drawing.Point(14, 21);
            this.RadioAutoDownload.Name = "RadioAutoDownload";
            this.RadioAutoDownload.Size = new System.Drawing.Size(78, 18);
            this.RadioAutoDownload.TabIndex = 1;
            this.RadioAutoDownload.TabStop = true;
            this.RadioAutoDownload.Text = "Automatic";
            this.RadioAutoDownload.UseVisualStyleBackColor = true;
            this.RadioAutoDownload.CheckedChanged += new System.EventHandler(this.RadioAutoDownload_CheckedChanged);
            // 
            // GroupSpeedUnits
            // 
            this.GroupSpeedUnits.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.GroupSpeedUnits.Controls.Add(this.RadioBytesPerSecond);
            this.GroupSpeedUnits.Controls.Add(this.RadioBitsPerSecond);
            this.GroupSpeedUnits.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.GroupSpeedUnits.Location = new System.Drawing.Point(12, 286);
            this.GroupSpeedUnits.Name = "GroupSpeedUnits";
            this.GroupSpeedUnits.Size = new System.Drawing.Size(320, 74);
            this.GroupSpeedUnits.TabIndex = 8;
            this.GroupSpeedUnits.TabStop = false;
            this.GroupSpeedUnits.Text = "Speed Units";
            // 
            // RadioBytesPerSecond
            // 
            this.RadioBytesPerSecond.AutoSize = true;
            this.RadioBytesPerSecond.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.RadioBytesPerSecond.Location = new System.Drawing.Point(14, 44);
            this.RadioBytesPerSecond.Name = "RadioBytesPerSecond";
            this.RadioBytesPerSecond.Size = new System.Drawing.Size(178, 18);
            this.RadioBytesPerSecond.TabIndex = 10;
            this.RadioBytesPerSecond.TabStop = true;
            this.RadioBytesPerSecond.Text = "Bytes per-second - KB/s, MB/s";
            this.RadioBytesPerSecond.UseVisualStyleBackColor = true;
            // 
            // RadioBitsPerSecond
            // 
            this.RadioBitsPerSecond.AutoSize = true;
            this.RadioBitsPerSecond.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.RadioBitsPerSecond.Location = new System.Drawing.Point(14, 20);
            this.RadioBitsPerSecond.Name = "RadioBitsPerSecond";
            this.RadioBitsPerSecond.Size = new System.Drawing.Size(165, 18);
            this.RadioBitsPerSecond.TabIndex = 9;
            this.RadioBitsPerSecond.TabStop = true;
            this.RadioBitsPerSecond.Text = "Bits per-second - kb/s, mb/s";
            this.RadioBitsPerSecond.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.label1.Location = new System.Drawing.Point(214, 409);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(118, 26);
            this.label1.TabIndex = 20;
            this.label1.Text = "Need shorter intervalls?\r\nSee http://loggger.com\r\n";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // GroupAPIURL
            // 
            this.GroupAPIURL.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.GroupAPIURL.Controls.Add(this.TextIPDetectURL);
            this.GroupAPIURL.Controls.Add(this.RadioCustomIPDetect);
            this.GroupAPIURL.Controls.Add(this.RadioAutoDetectIP);
            this.GroupAPIURL.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.GroupAPIURL.Location = new System.Drawing.Point(12, 96);
            this.GroupAPIURL.Name = "GroupAPIURL";
            this.GroupAPIURL.Size = new System.Drawing.Size(320, 78);
            this.GroupAPIURL.TabIndex = 4;
            this.GroupAPIURL.TabStop = false;
            this.GroupAPIURL.Text = "IP Detection URL";
            // 
            // TextIPDetectURL
            // 
            this.TextIPDetectURL.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TextIPDetectURL.Enabled = false;
            this.TextIPDetectURL.Location = new System.Drawing.Point(98, 43);
            this.TextIPDetectURL.Name = "TextIPDetectURL";
            this.TextIPDetectURL.Size = new System.Drawing.Size(210, 20);
            this.TextIPDetectURL.TabIndex = 3;
            // 
            // RadioCustomIPDetect
            // 
            this.RadioCustomIPDetect.AutoSize = true;
            this.RadioCustomIPDetect.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.RadioCustomIPDetect.Location = new System.Drawing.Point(14, 44);
            this.RadioCustomIPDetect.Name = "RadioCustomIPDetect";
            this.RadioCustomIPDetect.Size = new System.Drawing.Size(69, 18);
            this.RadioCustomIPDetect.TabIndex = 2;
            this.RadioCustomIPDetect.TabStop = true;
            this.RadioCustomIPDetect.Text = "Custom:";
            this.RadioCustomIPDetect.UseVisualStyleBackColor = true;
            // 
            // RadioAutoDetectIP
            // 
            this.RadioAutoDetectIP.AutoSize = true;
            this.RadioAutoDetectIP.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.RadioAutoDetectIP.Location = new System.Drawing.Point(14, 21);
            this.RadioAutoDetectIP.Name = "RadioAutoDetectIP";
            this.RadioAutoDetectIP.Size = new System.Drawing.Size(78, 18);
            this.RadioAutoDetectIP.TabIndex = 1;
            this.RadioAutoDetectIP.TabStop = true;
            this.RadioAutoDetectIP.Text = "Automatic";
            this.RadioAutoDetectIP.UseVisualStyleBackColor = true;
            this.RadioAutoDetectIP.CheckedChanged += new System.EventHandler(this.RadioAutoDetectIP_CheckedChanged);
            // 
            // FormSettings
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(344, 529);
            this.Controls.Add(this.GroupAPIURL);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.GroupSpeedUnits);
            this.Controls.Add(this.GroupDownloadURL);
            this.Controls.Add(this.ButtonOpenLog);
            this.Controls.Add(this.ButtonOK);
            this.Controls.Add(this.CheckMinimize);
            this.Controls.Add(this.CheckAutoStart);
            this.Controls.Add(this.GroupTimeFormat);
            this.Controls.Add(this.ComboCheckConnection);
            this.Controls.Add(this.LabelCheckConnection);
            this.Controls.Add(this.ButtonLogFile);
            this.Controls.Add(this.TextLogFile);
            this.Controls.Add(this.LabelLogFile);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(860, 568);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(360, 568);
            this.Name = "FormSettings";
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Configuration Settings";
            this.GroupTimeFormat.ResumeLayout(false);
            this.GroupTimeFormat.PerformLayout();
            this.GroupDownloadURL.ResumeLayout(false);
            this.GroupDownloadURL.PerformLayout();
            this.GroupSpeedUnits.ResumeLayout(false);
            this.GroupSpeedUnits.PerformLayout();
            this.GroupAPIURL.ResumeLayout(false);
            this.GroupAPIURL.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox TextLogFile;
        private System.Windows.Forms.Button ButtonLogFile;
        private System.Windows.Forms.Label LabelLogFile;
        private System.Windows.Forms.ComboBox ComboCheckConnection;
        private System.Windows.Forms.Label LabelCheckConnection;
        private System.Windows.Forms.GroupBox GroupTimeFormat;
        private System.Windows.Forms.RadioButton RadioUSFormat;
        private System.Windows.Forms.RadioButton RadioEUFormat;
        private System.Windows.Forms.RadioButton RadioISOFormat;
        private System.Windows.Forms.CheckBox CheckAutoStart;
        private System.Windows.Forms.CheckBox CheckMinimize;
        private System.Windows.Forms.Button ButtonOK;
        private System.Windows.Forms.Button ButtonOpenLog;
        private System.Windows.Forms.TextBox TextDownloadURL;
        private System.Windows.Forms.GroupBox GroupDownloadURL;
        private System.Windows.Forms.RadioButton RadioCustomDownload;
        private System.Windows.Forms.RadioButton RadioAutoDownload;
        private System.Windows.Forms.GroupBox GroupSpeedUnits;
        private System.Windows.Forms.RadioButton RadioBytesPerSecond;
        private System.Windows.Forms.RadioButton RadioBitsPerSecond;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox GroupAPIURL;
        private System.Windows.Forms.TextBox TextIPDetectURL;
        private System.Windows.Forms.RadioButton RadioCustomIPDetect;
        private System.Windows.Forms.RadioButton RadioAutoDetectIP;
    }
}