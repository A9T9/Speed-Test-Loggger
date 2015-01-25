namespace SpeedTest
{
    partial class FormMain
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            this.ContainerMain = new System.Windows.Forms.SplitContainer();
            this.GraphMain = new SpeedTest.SpeedGraph();
            this.ListLog = new System.Windows.Forms.ListView();
            this.ColumnTime = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ColumnSpeed = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ColumnIP = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ColumnMessage = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ColumnStatus = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ImageListLog = new System.Windows.Forms.ImageList(this.components);
            this.StatusMain = new System.Windows.Forms.StatusBar();
            this.IconMain = new System.Windows.Forms.NotifyIcon(this.components);
            this.ToolBarMain = new System.Windows.Forms.ToolBar();
            this.ToolBarStartLogging = new System.Windows.Forms.ToolBarButton();
            this.ToolBarStopLogging = new System.Windows.Forms.ToolBarButton();
            this.ToolBarTest = new System.Windows.Forms.ToolBarButton();
            this.ToolBarSeparator1 = new System.Windows.Forms.ToolBarButton();
            this.ToolBarShowSuccessful = new System.Windows.Forms.ToolBarButton();
            this.ToolBarShowStatusChanges = new System.Windows.Forms.ToolBarButton();
            this.ToolBarShowErrors = new System.Windows.Forms.ToolBarButton();
            this.ToolBarSeparator2 = new System.Windows.Forms.ToolBarButton();
            this.ToolBarSettings = new System.Windows.Forms.ToolBarButton();
            this.ToolBarHelp = new System.Windows.Forms.ToolBarButton();
            this.ToolBarAbout = new System.Windows.Forms.ToolBarButton();
            this.ImageListMain = new System.Windows.Forms.ImageList(this.components);
            this.MenuMain = new System.Windows.Forms.ContextMenu();
            this.MenuStartLogging = new System.Windows.Forms.MenuItem();
            this.MenuStopLogging = new System.Windows.Forms.MenuItem();
            this.MenuTest = new System.Windows.Forms.MenuItem();
            this.MenuSeparator1 = new System.Windows.Forms.MenuItem();
            this.MenuShowSuccessful = new System.Windows.Forms.MenuItem();
            this.MenuShowStatusChanges = new System.Windows.Forms.MenuItem();
            this.MenuShowErrors = new System.Windows.Forms.MenuItem();
            this.MenuSeparator2 = new System.Windows.Forms.MenuItem();
            this.MenuSettings = new System.Windows.Forms.MenuItem();
            this.MenuHelp = new System.Windows.Forms.MenuItem();
            this.MenuAbout = new System.Windows.Forms.MenuItem();
            this.MenuSeparator3 = new System.Windows.Forms.MenuItem();
            this.MenuExit = new System.Windows.Forms.MenuItem();
            this.TimerGraph = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.ContainerMain)).BeginInit();
            this.ContainerMain.Panel1.SuspendLayout();
            this.ContainerMain.Panel2.SuspendLayout();
            this.ContainerMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // ContainerMain
            // 
            this.ContainerMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ContainerMain.Location = new System.Drawing.Point(0, 72);
            this.ContainerMain.Name = "ContainerMain";
            this.ContainerMain.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // ContainerMain.Panel1
            // 
            this.ContainerMain.Panel1.Controls.Add(this.GraphMain);
            this.ContainerMain.Panel1MinSize = 0;
            // 
            // ContainerMain.Panel2
            // 
            this.ContainerMain.Panel2.Controls.Add(this.ListLog);
            this.ContainerMain.Panel2MinSize = 0;
            this.ContainerMain.Size = new System.Drawing.Size(644, 348);
            this.ContainerMain.SplitterDistance = 171;
            this.ContainerMain.TabIndex = 0;
            // 
            // GraphMain
            // 
            this.GraphMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GraphMain.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.GraphMain.Location = new System.Drawing.Point(0, 0);
            this.GraphMain.Name = "GraphMain";
            this.GraphMain.Size = new System.Drawing.Size(644, 171);
            this.GraphMain.TabIndex = 2;
            // 
            // ListLog
            // 
            this.ListLog.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.ListLog.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.ColumnTime,
            this.ColumnSpeed,
            this.ColumnIP,
            this.ColumnMessage,
            this.ColumnStatus});
            this.ListLog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ListLog.FullRowSelect = true;
            this.ListLog.HideSelection = false;
            this.ListLog.Location = new System.Drawing.Point(0, 0);
            this.ListLog.Name = "ListLog";
            this.ListLog.Size = new System.Drawing.Size(644, 173);
            this.ListLog.SmallImageList = this.ImageListLog;
            this.ListLog.TabIndex = 2;
            this.ListLog.UseCompatibleStateImageBehavior = false;
            this.ListLog.View = System.Windows.Forms.View.Details;
            // 
            // ColumnTime
            // 
            this.ColumnTime.Text = "Time";
            this.ColumnTime.Width = 150;
            // 
            // ColumnSpeed
            // 
            this.ColumnSpeed.Text = "Speed";
            this.ColumnSpeed.Width = 120;
            // 
            // ColumnIP
            // 
            this.ColumnIP.Text = "IP";
            this.ColumnIP.Width = 120;
            // 
            // ColumnMessage
            // 
            this.ColumnMessage.Text = "Message";
            this.ColumnMessage.Width = 110;
            // 
            // ColumnStatus
            // 
            this.ColumnStatus.Text = "Status";
            this.ColumnStatus.Width = 110;
            // 
            // ImageListLog
            // 
            this.ImageListLog.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("ImageListLog.ImageStream")));
            this.ImageListLog.TransparentColor = System.Drawing.Color.Transparent;
            this.ImageListLog.Images.SetKeyName(0, "navigate_check.png");
            this.ImageListLog.Images.SetKeyName(1, "earth_network.png");
            this.ImageListLog.Images.SetKeyName(2, "delete2.png");
            // 
            // StatusMain
            // 
            this.StatusMain.Location = new System.Drawing.Point(0, 420);
            this.StatusMain.Name = "StatusMain";
            this.StatusMain.Size = new System.Drawing.Size(644, 22);
            this.StatusMain.TabIndex = 1;
            this.StatusMain.Text = "Ready";
            // 
            // IconMain
            // 
            this.IconMain.Icon = ((System.Drawing.Icon)(resources.GetObject("IconMain.Icon")));
            this.IconMain.Text = "Speed Test Loggger";
            this.IconMain.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.IconMain_MouseDoubleClick);
            // 
            // ToolBarMain
            // 
            this.ToolBarMain.Appearance = System.Windows.Forms.ToolBarAppearance.Flat;
            this.ToolBarMain.Buttons.AddRange(new System.Windows.Forms.ToolBarButton[] {
            this.ToolBarStartLogging,
            this.ToolBarStopLogging,
            this.ToolBarTest,
            this.ToolBarSeparator1,
            this.ToolBarShowSuccessful,
            this.ToolBarShowStatusChanges,
            this.ToolBarShowErrors,
            this.ToolBarSeparator2,
            this.ToolBarSettings,
            this.ToolBarHelp,
            this.ToolBarAbout});
            this.ToolBarMain.Divider = false;
            this.ToolBarMain.DropDownArrows = true;
            this.ToolBarMain.ImageList = this.ImageListMain;
            this.ToolBarMain.Location = new System.Drawing.Point(0, 0);
            this.ToolBarMain.Name = "ToolBarMain";
            this.ToolBarMain.ShowToolTips = true;
            this.ToolBarMain.Size = new System.Drawing.Size(644, 72);
            this.ToolBarMain.TabIndex = 2;
            this.ToolBarMain.Wrappable = false;
            this.ToolBarMain.ButtonClick += new System.Windows.Forms.ToolBarButtonClickEventHandler(this.ToolBarMain_ButtonClick);
            // 
            // ToolBarStartLogging
            // 
            this.ToolBarStartLogging.ImageIndex = 0;
            this.ToolBarStartLogging.Name = "ToolBarStartLogging";
            this.ToolBarStartLogging.Text = "Start";
            this.ToolBarStartLogging.ToolTipText = "Start Logging";
            // 
            // ToolBarStopLogging
            // 
            this.ToolBarStopLogging.Enabled = false;
            this.ToolBarStopLogging.ImageIndex = 1;
            this.ToolBarStopLogging.Name = "ToolBarStopLogging";
            this.ToolBarStopLogging.Text = "Stop";
            this.ToolBarStopLogging.ToolTipText = "Stop Logging";
            // 
            // ToolBarTest
            // 
            this.ToolBarTest.Enabled = false;
            this.ToolBarTest.ImageIndex = 2;
            this.ToolBarTest.Name = "ToolBarTest";
            this.ToolBarTest.Text = "Test Now";
            this.ToolBarTest.ToolTipText = "Test Connection Now";
            // 
            // ToolBarSeparator1
            // 
            this.ToolBarSeparator1.Name = "ToolBarSeparator1";
            this.ToolBarSeparator1.Style = System.Windows.Forms.ToolBarButtonStyle.Separator;
            // 
            // ToolBarShowSuccessful
            // 
            this.ToolBarShowSuccessful.ImageIndex = 3;
            this.ToolBarShowSuccessful.Name = "ToolBarShowSuccessful";
            this.ToolBarShowSuccessful.Pushed = true;
            this.ToolBarShowSuccessful.Style = System.Windows.Forms.ToolBarButtonStyle.ToggleButton;
            this.ToolBarShowSuccessful.Text = "Successful Tests";
            this.ToolBarShowSuccessful.ToolTipText = "Show Successful Tests";
            // 
            // ToolBarShowStatusChanges
            // 
            this.ToolBarShowStatusChanges.ImageIndex = 4;
            this.ToolBarShowStatusChanges.Name = "ToolBarShowStatusChanges";
            this.ToolBarShowStatusChanges.Pushed = true;
            this.ToolBarShowStatusChanges.Style = System.Windows.Forms.ToolBarButtonStyle.ToggleButton;
            this.ToolBarShowStatusChanges.Text = "Status Changes";
            this.ToolBarShowStatusChanges.ToolTipText = "Show Status Changes";
            // 
            // ToolBarShowErrors
            // 
            this.ToolBarShowErrors.ImageIndex = 5;
            this.ToolBarShowErrors.Name = "ToolBarShowErrors";
            this.ToolBarShowErrors.Pushed = true;
            this.ToolBarShowErrors.Style = System.Windows.Forms.ToolBarButtonStyle.ToggleButton;
            this.ToolBarShowErrors.Text = "Error Messages";
            this.ToolBarShowErrors.ToolTipText = "Show Error Messages";
            // 
            // ToolBarSeparator2
            // 
            this.ToolBarSeparator2.Name = "ToolBarSeparator2";
            this.ToolBarSeparator2.Style = System.Windows.Forms.ToolBarButtonStyle.Separator;
            // 
            // ToolBarSettings
            // 
            this.ToolBarSettings.ImageIndex = 6;
            this.ToolBarSettings.Name = "ToolBarSettings";
            this.ToolBarSettings.Text = "Settings...";
            this.ToolBarSettings.ToolTipText = "Configuration Settings...";
            // 
            // ToolBarHelp
            // 
            this.ToolBarHelp.ImageIndex = 7;
            this.ToolBarHelp.Name = "ToolBarHelp";
            this.ToolBarHelp.Text = "Help...";
            this.ToolBarHelp.ToolTipText = "Get Help Online...";
            // 
            // ToolBarAbout
            // 
            this.ToolBarAbout.ImageIndex = 8;
            this.ToolBarAbout.Name = "ToolBarAbout";
            this.ToolBarAbout.Text = "About...";
            this.ToolBarAbout.ToolTipText = "About Speed Test Loggger...";
            // 
            // ImageListMain
            // 
            this.ImageListMain.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("ImageListMain.ImageStream")));
            this.ImageListMain.TransparentColor = System.Drawing.Color.Transparent;
            this.ImageListMain.Images.SetKeyName(0, "AppImage.png");
            this.ImageListMain.Images.SetKeyName(1, "stop_red.png");
            this.ImageListMain.Images.SetKeyName(2, "arrow_down_green.png");
            this.ImageListMain.Images.SetKeyName(3, "navigate_check.png");
            this.ImageListMain.Images.SetKeyName(4, "earth_network.png");
            this.ImageListMain.Images.SetKeyName(5, "delete2.png");
            this.ImageListMain.Images.SetKeyName(6, "wrench.png");
            this.ImageListMain.Images.SetKeyName(7, "help_earth.png");
            this.ImageListMain.Images.SetKeyName(8, "about.png");
            // 
            // MenuMain
            // 
            this.MenuMain.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.MenuStartLogging,
            this.MenuStopLogging,
            this.MenuTest,
            this.MenuSeparator1,
            this.MenuShowSuccessful,
            this.MenuShowStatusChanges,
            this.MenuShowErrors,
            this.MenuSeparator2,
            this.MenuSettings,
            this.MenuHelp,
            this.MenuAbout,
            this.MenuSeparator3,
            this.MenuExit});
            // 
            // MenuStartLogging
            // 
            this.MenuStartLogging.Index = 0;
            this.MenuStartLogging.Text = "Start Logging";
            this.MenuStartLogging.Click += new System.EventHandler(this.MenuStartLogging_Click);
            // 
            // MenuStopLogging
            // 
            this.MenuStopLogging.Enabled = false;
            this.MenuStopLogging.Index = 1;
            this.MenuStopLogging.Text = "Stop Logging";
            this.MenuStopLogging.Click += new System.EventHandler(this.MenuStopLogging_Click);
            // 
            // MenuTest
            // 
            this.MenuTest.Enabled = false;
            this.MenuTest.Index = 2;
            this.MenuTest.Text = "Test Now";
            this.MenuTest.Click += new System.EventHandler(this.MenuTest_Click);
            // 
            // MenuSeparator1
            // 
            this.MenuSeparator1.Index = 3;
            this.MenuSeparator1.Text = "-";
            // 
            // MenuShowSuccessful
            // 
            this.MenuShowSuccessful.Checked = true;
            this.MenuShowSuccessful.Index = 4;
            this.MenuShowSuccessful.Text = "Show Successful Tests";
            this.MenuShowSuccessful.Click += new System.EventHandler(this.MenuShowSuccessful_Click);
            // 
            // MenuShowStatusChanges
            // 
            this.MenuShowStatusChanges.Checked = true;
            this.MenuShowStatusChanges.Index = 5;
            this.MenuShowStatusChanges.Text = "Show Status Changes";
            this.MenuShowStatusChanges.Click += new System.EventHandler(this.MenuShowStatusChanges_Click);
            // 
            // MenuShowErrors
            // 
            this.MenuShowErrors.Checked = true;
            this.MenuShowErrors.Index = 6;
            this.MenuShowErrors.Text = "Show Error Messages";
            this.MenuShowErrors.Click += new System.EventHandler(this.MenuShowErrors_Click);
            // 
            // MenuSeparator2
            // 
            this.MenuSeparator2.Index = 7;
            this.MenuSeparator2.Text = "-";
            // 
            // MenuSettings
            // 
            this.MenuSettings.Index = 8;
            this.MenuSettings.Text = "Configuration Settings...";
            this.MenuSettings.Click += new System.EventHandler(this.MenuSettings_Click);
            // 
            // MenuHelp
            // 
            this.MenuHelp.Index = 9;
            this.MenuHelp.Text = "Get Help Online...";
            this.MenuHelp.Click += new System.EventHandler(this.MenuHelp_Click);
            // 
            // MenuAbout
            // 
            this.MenuAbout.Index = 10;
            this.MenuAbout.Text = "About Speed Test Loggger...";
            this.MenuAbout.Click += new System.EventHandler(this.MenuAbout_Click);
            // 
            // MenuSeparator3
            // 
            this.MenuSeparator3.Index = 11;
            this.MenuSeparator3.Text = "-";
            // 
            // MenuExit
            // 
            this.MenuExit.Index = 12;
            this.MenuExit.Text = "Exit";
            this.MenuExit.Click += new System.EventHandler(this.MenuExit_Click);
            // 
            // TimerGraph
            // 
            this.TimerGraph.Enabled = true;
            this.TimerGraph.Interval = 1000;
            this.TimerGraph.Tick += new System.EventHandler(this.TimerGraph_Tick);
            // 
            // FormMain
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(644, 442);
            this.Controls.Add(this.ContainerMain);
            this.Controls.Add(this.StatusMain);
            this.Controls.Add(this.ToolBarMain);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Speed Test Loggger for Windows - http://loggger.com";
            this.ContainerMain.Panel1.ResumeLayout(false);
            this.ContainerMain.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ContainerMain)).EndInit();
            this.ContainerMain.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.SplitContainer ContainerMain;
        private System.Windows.Forms.ColumnHeader ColumnTime;
        private System.Windows.Forms.ColumnHeader ColumnSpeed;
        private System.Windows.Forms.ColumnHeader ColumnIP;
        private System.Windows.Forms.ColumnHeader ColumnMessage;
        private System.Windows.Forms.ColumnHeader ColumnStatus;
        private System.Windows.Forms.ImageList ImageListLog;
        private System.Windows.Forms.NotifyIcon IconMain;
        private System.Windows.Forms.ImageList ImageListMain;
        private System.Windows.Forms.ContextMenu MenuMain;
        private System.Windows.Forms.MenuItem MenuStartLogging;
        private System.Windows.Forms.MenuItem MenuStopLogging;
        private System.Windows.Forms.MenuItem MenuTest;
        private System.Windows.Forms.MenuItem MenuSeparator1;
        private System.Windows.Forms.MenuItem MenuShowSuccessful;
        private System.Windows.Forms.MenuItem MenuShowStatusChanges;
        private System.Windows.Forms.MenuItem MenuShowErrors;
        private System.Windows.Forms.MenuItem MenuSeparator2;
        private System.Windows.Forms.MenuItem MenuSettings;
        private System.Windows.Forms.MenuItem MenuHelp;
        private System.Windows.Forms.MenuItem MenuAbout;
        private System.Windows.Forms.MenuItem MenuSeparator3;
        private System.Windows.Forms.MenuItem MenuExit;
        private System.Windows.Forms.ToolBarButton ToolBarStartLogging;
        private System.Windows.Forms.ToolBarButton ToolBarStopLogging;
        private System.Windows.Forms.ToolBarButton ToolBarTest;
        private System.Windows.Forms.ToolBarButton ToolBarSeparator1;
        private System.Windows.Forms.ToolBarButton ToolBarShowSuccessful;
        private System.Windows.Forms.ToolBarButton ToolBarShowStatusChanges;
        private System.Windows.Forms.ToolBarButton ToolBarShowErrors;
        private System.Windows.Forms.ToolBarButton ToolBarSeparator2;
        private System.Windows.Forms.ToolBarButton ToolBarSettings;
        private System.Windows.Forms.ToolBarButton ToolBarHelp;
        private System.Windows.Forms.ToolBarButton ToolBarAbout;
        private System.Windows.Forms.StatusBar StatusMain;
        private SpeedGraph GraphMain;
        private System.Windows.Forms.ListView ListLog;
        private System.Windows.Forms.ToolBar ToolBarMain;
        private System.Windows.Forms.Timer TimerGraph;

    }
}

