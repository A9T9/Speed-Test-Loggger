#region Using
// Imported namespaces
using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Net;
using System.Net.NetworkInformation;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using SpeedTest.Properties;
using Microsoft.Win32;
#endregion
namespace SpeedTest
{
    /// <summary>The class representing the Logger Form of the application.</summary>
    public partial class FormMain : Form
    {
        #region Enums
        public enum StatusCode : int
        {
            None,
            Online,
            Offline,
            InvalidURL,
        }
        #endregion
        #region Delegates
        public delegate void TimerTickCallback(object stateObject);
        #endregion
        #region Members
        // Private variables
        private string p_CurrentIP;
        private StatusCode p_CurrentStatus;
        private int p_ElapsedSeconds;
        private bool p_StartLogging;
        private DateTime p_StartupTime;
        private System.Threading.Timer p_TimerLog;
        #endregion
        #region Constructor
        /// <summary>Initializes a new instance of the FormMain class.</summary>
        public FormMain(bool startLogging)
        {
            // This call is required by the designer
            InitializeComponent();

            // Initialize private variables
            p_CurrentIP = "-";
            p_CurrentStatus = StatusCode.None;
            p_ElapsedSeconds = 0;
            p_StartLogging = startLogging;
            p_StartupTime = DateTime.Now;
            p_TimerLog = null;

            // Initialize FormMain properties
            this.ClientSize = new Size(660, 480);
            this.Font = SystemFonts.MenuFont;

            // Initialize tray icon
            IconMain.ContextMenu = MenuMain;

            // Initialize Menu/ToolBar
            MenuShowSuccessful.Checked = Settings.Default.ShowSuccessful;
            MenuShowStatusChanges.Checked = Settings.Default.ShowStatusChanges;
            MenuShowErrors.Checked = Settings.Default.ShowErrors;
            ToolBarShowSuccessful.Pushed = MenuShowSuccessful.Checked;
            ToolBarShowStatusChanges.Pushed = MenuShowStatusChanges.Checked;
            ToolBarShowErrors.Pushed = MenuShowErrors.Checked;
        }
        #endregion
        #region Overrides
        /// <summary>Occurs before the Form is closed.</summary>
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            // Stop the logger if it is running
            if (p_TimerLog != null)
            {
                // Stop the timer
                p_TimerLog.Dispose();
                p_TimerLog = null;

                // Reset elapsed seconds
                p_ElapsedSeconds = 0;

                // Create a new ListViewItem object
                ListViewItem item = new ListViewItem(Global.ConvertTime(DateTime.Now));
                item.SubItems.Add(Global.ConvertBytes(0) + "/s");
                item.SubItems.Add(p_CurrentIP);
                item.SubItems.Add("OK");
                item.SubItems.Add("Logger Stopped");
                item.SubItems.Add("0");
                item.ImageIndex = 0;
                item.Tag = DateTime.Now;

                // Add the ListViewItem to the log
                Global.ConnectionLog.Add(item);
            }

            // Hide tray icon
            IconMain.Visible = false;

            // Save the connection log
            Global.SaveConnectionLog(Settings.Default.LogFile);

            // Update configuration settings
            Settings.Default.ShowSuccessful = MenuShowSuccessful.Checked;
            Settings.Default.ShowStatusChanges = MenuShowStatusChanges.Checked;
            Settings.Default.ShowErrors = MenuShowErrors.Checked;

            // Save configuration settings
            Settings.Default.Save();

            // Update auto-start setting
            UpdateAutoStart();

            // Continue processing the event as usual
            base.OnFormClosing(e);
        }

        /// <summary>Occurs whenever the Form is first displayed.</summary>
        protected override void OnShown(EventArgs e)
        {
            // Explorer themed ListView
            Global.SetWindowTheme(ListLog.Handle, "Explorer", null);
            Global.SendMessage(ListLog.Handle, 0x1000 + 54, 0x00010000, 0x00010000); // LVS_EX_DOUBLEBUFFERED

            // Extend frame if Desktop Composition (Aero) is enabled
            if (Global.CompositionEnabled && !Global.IsWindows8)
            {
                BackColor = Color.Black;
                ContainerMain.BackColor = SystemColors.Control;
                
                Global.ExtendFrame(this.Handle, new System.Drawing.Printing.Margins(0, 0, ToolBarMain.Height, 0));

                //if (Global.IsWindows8) Global.SetWindowTheme(ToolBarMain.Handle, "TrayNotifyComposited", null);
                Global.SetWindowTheme(ToolBarMain.Handle, "Media", null);
            }

            // Start logging
            if (p_StartLogging) MenuStartLogging_Click(this, EventArgs.Empty);

            // Continue processing the event as usual
            base.OnShown(e);
        }

        /// <summary>Procedure used to process Windows messages.</summary>
        protected override void WndProc(ref Message m)
        {
            if (m.Msg == 0x0112) // WM_SYSCOMMAND
            {
                if (m.WParam.ToInt32() == 0xf020) // SC_MINIMIZE
                {
                    if (Settings.Default.Minimize)
                    {
                        m.Result = IntPtr.Zero;
                        Visible = false;
                        IconMain.Visible = true;
                        return;
                    }
                }
            }

            // Continue processing the event as usual
            base.WndProc(ref m);
        }
        #endregion
        #region Event Handlers
        /// <summary>Occurs when the Start Logging menu item is clicked.</summary>
        private void MenuStartLogging_Click(object sender, EventArgs e)
        {
            // Update the GUI
            ToolBarStartLogging.Enabled = false;
            ToolBarStopLogging.Enabled = true;
            ToolBarTest.Enabled = true;
            MenuStartLogging.Enabled = ToolBarStartLogging.Enabled;
            MenuStopLogging.Enabled = ToolBarStopLogging.Enabled;
            MenuTest.Enabled = ToolBarTest.Enabled;
            StatusMain.Text = "Started logging at: " + Global.ConvertTime(DateTime.Now);

            // Create a new ListViewItem object
            ListViewItem item = new ListViewItem(Global.ConvertTime(DateTime.Now));
            item.SubItems.Add(Global.ConvertBytes(0) + "/s");
            item.SubItems.Add(p_CurrentIP);
            item.SubItems.Add("OK");
            item.SubItems.Add("Logger Started");
            item.SubItems.Add("0");
            item.ImageIndex = 1;
            item.Tag = DateTime.Now;

            // Add the ListViewItem to the log
            Global.ConnectionLog.Add(item);

            if (ToolBarShowStatusChanges.Pushed)
            {
                ListLog.Items.Insert(0, item);
                item.EnsureVisible();
            }

            // Start the Timer
            p_TimerLog = new System.Threading.Timer(new System.Threading.TimerCallback(p_TimerLog_Tick), null, 1000, 1000);
            GetRemoteIP();
        }

        /// <summary>Occurs when the Stop Logging menu item is clicked.</summary>
        private void MenuStopLogging_Click(object sender, EventArgs e)
        {
            // Stop the Timer
            p_TimerLog.Dispose();
            p_TimerLog = null;

            p_ElapsedSeconds = 0;

            // Update the GUI
            ToolBarStartLogging.Enabled = true;
            ToolBarStopLogging.Enabled = false;
            ToolBarTest.Enabled = false;
            MenuStartLogging.Enabled = ToolBarStartLogging.Enabled;
            MenuStopLogging.Enabled = ToolBarStopLogging.Enabled;
            MenuTest.Enabled = ToolBarTest.Enabled;
            StatusMain.Text = "Stopped logging at: " + Global.ConvertTime(DateTime.Now);

            // Create a new ListViewItem object
            ListViewItem item = new ListViewItem(Global.ConvertTime(DateTime.Now));
            item.SubItems.Add(Global.ConvertBytes(0) + "/s");
            item.SubItems.Add(p_CurrentIP);
            item.SubItems.Add("OK");
            item.SubItems.Add("Logger Stopped");
            item.SubItems.Add("0");
            item.ImageIndex = 1;
            item.Tag = DateTime.Now;

            // Add the ListViewItem to the log
            Global.ConnectionLog.Add(item);

            if (ToolBarShowStatusChanges.Pushed)
            {
                ListLog.Items.Insert(0, item);
                item.EnsureVisible();
            }
        }

        /// <summary>Occurs when the Test Now menu item is clicked.</summary>
        private void MenuTest_Click(object sender, EventArgs e)
        {
            GetRemoteIP();
        }

        /// <summary>Occurs when the Show Successful Logs menu item is clicked.</summary>
        private void MenuShowSuccessful_Click(object sender, EventArgs e)
        {
            MenuShowSuccessful.Checked = !MenuShowSuccessful.Checked;
            ToolBarShowSuccessful.Pushed = MenuShowSuccessful.Checked;

            UpdateLog();
        }

        /// <summary>Occurs when the Show Status Changes item is clicked.</summary>
        private void MenuShowStatusChanges_Click(object sender, EventArgs e)
        {
            MenuShowStatusChanges.Checked = !MenuShowStatusChanges.Checked;
            ToolBarShowStatusChanges.Pushed = MenuShowStatusChanges.Checked;

            UpdateLog();
        }

        /// <summary>Occurs when the Show Error Messages menu item is clicked.</summary>
        private void MenuShowErrors_Click(object sender, EventArgs e)
        {
            MenuShowErrors.Checked = !MenuShowErrors.Checked;
            ToolBarShowErrors.Pushed = MenuShowErrors.Checked;

            UpdateLog();
        }

        /// <summary>Occurs when the Configuration Settings menu item is clicked.</summary>
        private void MenuSettings_Click(object sender, EventArgs e)
        {
            // Create a new FormSettings dialog and display it to the user
            using (FormSettings fs = new FormSettings())
            {
                fs.ShowDialog(this);
            }
        }

        /// <summary>Occurs when the Get Help Online menu item is clicked.</summary>
        private void MenuHelp_Click(object sender, EventArgs e)
        {
            // Navigate to online help URL
            Process.Start("http://loggger.com/");
        }

        /// <summary>Occurs when the About Logger menu item is clicked.</summary>
        private void MenuAbout_Click(object sender, EventArgs e)
        {
            // Display an About dialog to the user
            MessageBox.Show(this, "Speed Test Loggger for Windows V1.02" + Environment.NewLine + "Open-Source - Get it at Loggger.com" + Environment.NewLine + "Copyright © Loggger.com 2015", Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        /// <summary>Occurs when the Exit menu item is clicked.</summary>
        private void MenuExit_Click(object sender, EventArgs e)
        {
            // Exit the application
            Application.Exit();
        }

        /// <summary>Occurs when a ToolBarButton on the ToolBar is clicked.</summary>
        private void ToolBarMain_ButtonClick(object sender, ToolBarButtonClickEventArgs e)
        {
            switch (e.Button.ImageIndex)
            {
                case 0: // Start Logging
                    MenuStartLogging_Click(this, EventArgs.Empty);
                    break;
                case 1: // Stop Logging
                    MenuStopLogging_Click(this, EventArgs.Empty);
                    break;
                case 2: // Test Now
                    MenuTest_Click(this, EventArgs.Empty);
                    break;
                case 3: // Show Successful Logs
                    MenuShowSuccessful_Click(this, EventArgs.Empty);
                    break;
                case 4: // Show Status Changes
                    MenuShowStatusChanges_Click(this, EventArgs.Empty);
                    break;
                case 5: // Show Error Messages
                    MenuShowErrors_Click(this, EventArgs.Empty);
                    break;
                case 6: // Configuration Settings
                    MenuSettings_Click(this, EventArgs.Empty);
                    break;
                case 7: // Get Help Online
                    MenuHelp_Click(this, EventArgs.Empty);
                    break;
                case 8: // About Logger
                    MenuAbout_Click(this, EventArgs.Empty);
                    break;
            }
        }

        /// <summary>Occurs when the NotifyIcon is double-clicked.</summary>
        private void IconMain_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            Visible = true;
            IconMain.Visible = false;
        }

        /// <summary>Occurs each time the Timer ticks (Once per-second).</summary>
        private void p_TimerLog_Tick(object stateObject)
        {
            if (p_TimerLog == null) return;

            if (InvokeRequired) Invoke(new TimerTickCallback(p_TimerLog_Tick), new object[] { stateObject });
            else
            {
                // Increment elapsed seconds
                p_ElapsedSeconds++;

                // Create a new TimeSpan object
                TimeSpan ts = new TimeSpan(0, 0, 0, p_ElapsedSeconds);

                switch (Settings.Default.CheckConnection)
                {
                    case 0: // 30 Seconds
                        if (ts.TotalMinutes >= 10) GetRemoteIP();
                        break;
                    case 1: // 1 Minute
                        if (ts.TotalMinutes >= 30) GetRemoteIP();
                        break;
                    case 2: // 5 Minutes
                        if (ts.TotalMinutes >= 60) GetRemoteIP();
                        break;
   /*                 case 3: // 10 Minutes
                        if (ts.TotalMinutes >= 10) GetRemoteIP();
                        break;
                    case 4: // 30 Minutes
                        if (ts.TotalMinutes >= 30) GetRemoteIP();
                        break;
                    case 5: // 1 Hour
                        if (ts.TotalMinutes >= 60) GetRemoteIP();
                        break;
    * */
                }
            }
        }

        /// <summary>Occurs each time the Timer ticks (Once per-second).</summary>
        private void TimerGraph_Tick(object sender, EventArgs e)
        {
            // Update the GUI
            GraphMain.Invalidate();
        }

        private void webClient_DownloadDataCompleted(object sender, DownloadDataCompletedEventArgs e)
        {
            // Retrieve the CustomWebClient object
            CustomWebClient webClient = sender as CustomWebClient;
            if (webClient == null) return;

            if (p_TimerLog == null) return;

            // Retrieve the IP address
            string ip = (string)e.UserState;

            // Local variables
            string status = "-";
            StatusCode newStatus = StatusCode.Online;
            int imageIndex = 0;
            ListViewItem item = null;

            if (e.Error == null) // Data downloaded successfully
            {
                // Update the StatusBar
                StatusMain.Text = "Connection logged, size: " + Global.ConvertBytes(webClient.AllBytesDownloaded) + " speed: " + Global.ConvertBytes(webClient.CurrentSpeed) + "/s";

                if (!p_CurrentIP.Equals(ip))
                {
                    status = "IP Changed";
                    imageIndex = 1;
                    p_CurrentIP = ip;
                }

                if (!p_CurrentStatus.Equals(newStatus))
                {
                    status = "Online";
                    imageIndex = 1;
                    p_CurrentStatus = newStatus;
                }

                // Create a new ListViewItem object
                item = new ListViewItem(Global.ConvertTime(DateTime.Now));
                item.SubItems.Add(Global.ConvertBytes(webClient.CurrentSpeed) + "/s");
                item.SubItems.Add(p_CurrentIP);
                item.SubItems.Add("OK");
                item.SubItems.Add(status);
                item.SubItems.Add(webClient.CurrentSpeed.ToString());
                item.ImageIndex = imageIndex;
                item.Tag = DateTime.Now;
            }
            else // An error occured downloading the data
            {
                // Update the StatusBar
                StatusMain.Text = "Unable to test speed: " + Global.ConvertTime(DateTime.Now);

                // Set status to Offline
                newStatus = StatusCode.InvalidURL;
                imageIndex = 2;
                //ip = "-";

                if (!p_CurrentIP.Equals(ip))
                {
                    status = "IP Changed";
                    imageIndex = 1;
                    p_CurrentIP = ip;
                }

                if (!p_CurrentStatus.Equals(newStatus))
                {
                    status = "Invalid URL";
                    imageIndex = 2;
                    p_CurrentStatus = newStatus;
                }

                // Create a new ListViewItem object
                item = new ListViewItem(Global.ConvertTime(DateTime.Now));
                item.SubItems.Add(Global.ConvertBytes(0) + "/s");
                item.SubItems.Add(p_CurrentIP);
                item.SubItems.Add("Error");
                item.SubItems.Add(status);
                item.SubItems.Add("0");
                item.ImageIndex = imageIndex;
                item.Tag = DateTime.Now;
            }

            if (item != null)
            {
                // Add the ListViewItem to the log
                Global.ConnectionLog.Add(item);

                switch (imageIndex)
                {
                    case 0: // Successful
                        if (ToolBarShowSuccessful.Pushed)
                        {
                            ListLog.Items.Insert(0, item);
                            item.EnsureVisible();
                        }
                        break;
                    case 1: // Status Changed
                        if (ToolBarShowStatusChanges.Pushed)
                        {
                            ListLog.Items.Insert(0, item);
                            item.EnsureVisible();
                        }
                        break;
                    case 2: // Error
                        if (ToolBarShowErrors.Pushed)
                        {
                            ListLog.Items.Insert(0, item);
                            item.EnsureVisible();
                        }
                        break;
                }
            }

            // Dispose the CustomWebClient object
            webClient.Dispose();

            // Save the speed log
            Global.SaveConnectionLog(Settings.Default.LogFile);
        }

        private void webClient_DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            // Retrieve the CustomWebClient object
            CustomWebClient webClient = sender as CustomWebClient;
            if (webClient == null) return;

            if (p_TimerLog == null) return;

            StatusMain.Text = "Calculating speed: " + Global.ConvertBytes(webClient.CurrentSpeed) + "/s...";
        }

        /// <summary>Occurs when an asynchronous download operation completes.</summary>
        private void webClient_DownloadStringCompleted(object sender, DownloadStringCompletedEventArgs e)
        {
            // Retrieve the CustomWebClient object
            CustomWebClient webClient = sender as CustomWebClient;
            if (webClient == null) return;

            // Local variables
            string ip = "-";
            string status = "-";
            StatusCode newStatus = StatusCode.Online;
            int imageIndex = 0;
            // Regex to match IP address
            Regex regex = new Regex(@"(?:[0-9]{1,3}\.){3}[0-9]{1,3}");

            if (e.Error == null && regex.IsMatch(e.Result)) // String downloaded successfully and contains IP address
            {
                // Get the first instance of an IP in the result using regex
                Match match = regex.Match(e.Result);

                // Remove line breaks from the IP address
                ip = match.Value;

                StatusMain.Text = "Testing speed at: " + Global.ConvertTime(DateTime.Now);

                // Begin downloading the data, passing the IP to the DownloadDataCompleted event
                if (Settings.Default.AutoDownload)
                {
                    string url = string.Empty;
                    long maximumSpeed = 0;

                    foreach (ListViewItem item in Global.ConnectionLog)
                    {
                        long speed = Global.ToInt64(item.SubItems[5].Text);

                        if (speed > maximumSpeed) maximumSpeed = speed;
                    }

                    // Auto-select URL based on maximum download speed
                    if (maximumSpeed < 1024000)
                    {
                        // Download 3 MB file
                        url = "http://onlyforusebyspeedtest.loggger.com/~3mbfile.zip";
                    }
                    else if (maximumSpeed < 1024000 * 5)
                    {
                        // Download 6 MB file
                        url = "http://onlyforusebyspeedtest.loggger.com/~6mbfile.zip";
                    }
                    else
                    {
                        // Download 12 MB file
                        url = "http://onlyforusebyspeedtest.loggger.com/~12mbfile.zip";
                    }

                    webClient.DownloadDataAsync(new Uri(url), ip);
                }
                else webClient.DownloadDataAsync(new Uri(Settings.Default.DownloadURL), ip);
            }
            else // An error occured downloading the string
            {
                StatusMain.Text = "Unable to test speed: " + Global.ConvertTime(DateTime.Now);

                // Set status to Offline
                newStatus = StatusCode.Offline;
                imageIndex = 2;
                ip = "-";

                if (!p_CurrentIP.Equals(ip))
                {
                    status = "IP Changed";
                    imageIndex = 1;
                    p_CurrentIP = ip;
                }

                if (!p_CurrentStatus.Equals(newStatus))
                {
                    status = "Offline";
                    imageIndex = 2;
                    p_CurrentStatus = newStatus;
                }

                // Create a new ListViewItem object
                ListViewItem item = new ListViewItem(Global.ConvertTime(DateTime.Now));
                item.SubItems.Add(Global.ConvertBytes(0) + "/s");
                item.SubItems.Add(p_CurrentIP);
                item.SubItems.Add("Offline");
                item.SubItems.Add(status);
                item.SubItems.Add("0");
                item.ImageIndex = imageIndex;
                item.Tag = DateTime.Now;

                // Add the ListViewItem to the log
                Global.ConnectionLog.Add(item);

                switch (imageIndex)
                {
                    case 0: // Successful
                        if (ToolBarShowSuccessful.Pushed)
                        {
                            ListLog.Items.Insert(0, item);
                            item.EnsureVisible();
                        }
                        break;
                    case 1: // Status Changed
                        if (ToolBarShowStatusChanges.Pushed)
                        {
                            ListLog.Items.Insert(0, item);
                            item.EnsureVisible();
                        }
                        break;
                    case 2: // Error
                        if (ToolBarShowErrors.Pushed)
                        {
                            ListLog.Items.Insert(0, item);
                            item.EnsureVisible();
                        }
                        break;
                }

                // Dispose the CustomWebClient object
                webClient.Dispose();
            }
        }
        #endregion
        #region Public Methods
        /// <summary>Retrieves the remote IPv4 address for this system from icanhazip.com.</summary>
        public void GetRemoteIP()
        {
            // Reset elapsed seconds
            p_ElapsedSeconds = 0;

            if (Global.IsOnline)
            {
                string api = string.Empty;
                if (Settings.Default.AutoIPDetect)
                {
                    api = "http://icanhazip.com";
                }
                else
                {
                    api = Settings.Default.IPDetectURL;
                }
                // Create a new WebClient object and download the string
                CustomWebClient webClient = new CustomWebClient();
                webClient.DownloadDataCompleted += webClient_DownloadDataCompleted;
                webClient.DownloadProgressChanged += webClient_DownloadProgressChanged;
                webClient.DownloadStringCompleted += webClient_DownloadStringCompleted;
                webClient.DownloadStringAsync(new Uri(api));
            }
            else
            {
                // Local variables
                StatusCode newStatus = StatusCode.Offline;
                int imageIndex = 2;
                string ip = "-";
                string status = "-";

                // Set status to Offline
                StatusMain.Text = "Unable to test speed: " + Global.ConvertTime(DateTime.Now);

                if (!p_CurrentIP.Equals(ip))
                {
                    status = "IP Changed";
                    imageIndex = 1;
                    p_CurrentIP = ip;
                }

                if (!p_CurrentStatus.Equals(newStatus))
                {
                    status = "Offline";
                    imageIndex = 1;
                    p_CurrentStatus = newStatus;
                }

                // Create a new ListViewItem object
                ListViewItem item = new ListViewItem(Global.ConvertTime(DateTime.Now));
                item.SubItems.Add(Global.ConvertBytes(0) + "/s");
                item.SubItems.Add(p_CurrentIP);
                item.SubItems.Add("Offline");
                item.SubItems.Add(status);
                item.SubItems.Add("0");
                item.ImageIndex = imageIndex;
                item.Tag = DateTime.Now;

                // Add the ListViewItem to the log
                Global.ConnectionLog.Add(item);

                switch (imageIndex)
                {
                    case 0: // Successful
                        if (ToolBarShowSuccessful.Pushed)
                        {
                            ListLog.Items.Insert(0, item);
                            item.EnsureVisible();
                        }
                        break;
                    case 1: // Status Changed
                        if (ToolBarShowStatusChanges.Pushed)
                        {
                            ListLog.Items.Insert(0, item);
                            item.EnsureVisible();
                        }
                        break;
                    case 2: // Error
                        if (ToolBarShowErrors.Pushed)
                        {
                            ListLog.Items.Insert(0, item);
                            item.EnsureVisible();
                        }
                        break;
                }
            }
        }

        /// <summary>Adds or removes the aapplication from the Windows Startup folder.</summary>
        public void UpdateAutoStart()
        {
            try
            {
                string batchPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + Path.DirectorySeparatorChar + "SpeedTest" + Path.DirectorySeparatorChar + "SpeedTest.bat";
                string shortcutPath = Environment.GetFolderPath(Environment.SpecialFolder.Startup) + Path.DirectorySeparatorChar + "SpeedTest.url";
                //RegistryKey key = Registry.LocalMachine.OpenSubKey("Software\\Microsoft\\Windows\\CurrentVersion\\Run", true);

                if (Settings.Default.AutoStart)
                {
                    // Create a batch file in the AppData folder
                    using (StreamWriter writer = new StreamWriter(batchPath))
                    {
                        writer.WriteLine("@ECHO OFF");
                        writer.WriteLine("start /d \"" + Application.StartupPath + "\" SpeedTestLoggger.exe \"/start\"");
                    }

                    // Create a shortcut in the Windows Startup folder
                    using (StreamWriter writer = new StreamWriter(shortcutPath))
                    {
                        string appPath = Application.StartupPath + Path.DirectorySeparatorChar + "SpeedTest.exe";
                        
                        writer.WriteLine("[InternetShortcut]");
                        writer.WriteLine("URL=file:///" + batchPath);
                        writer.WriteLine("IconIndex=0");
                        writer.WriteLine("IconFile=" + appPath.Replace(Path.DirectorySeparatorChar, '/'));
                    }

                    //key.SetValue("SpeedTest", "\"" + Application.ExecutablePath + "\" /start");
                    //key.Close();
                }
                else
                {
                    if (File.Exists(batchPath)) File.Delete(batchPath);
                    if (File.Exists(shortcutPath)) File.Delete(shortcutPath);

                    //key.DeleteValue("SpeedTest");
                }
            }
            catch { }
        }

        /// <summary>Updates the ListView when the user shows or hides log messages.</summary>
        public void UpdateLog()
        {
            // Clear the ListView
            ListLog.Items.Clear();

            if (Global.ConnectionLog != null)
            {
                foreach (ListViewItem item in Global.ConnectionLog)
                {
                    DateTime time = (DateTime)item.Tag;

                    if (time > p_StartupTime)
                    {
                        switch (item.ImageIndex)
                        {
                            case 0: // Successful
                                if (ToolBarShowSuccessful.Pushed)
                                {
                                    ListLog.Items.Insert(0, item);
                                    item.EnsureVisible();
                                }
                                break;
                            case 1: // Status Changed
                                if (ToolBarShowStatusChanges.Pushed)
                                {
                                    ListLog.Items.Insert(0, item);
                                    item.EnsureVisible();
                                }
                                break;
                            case 2: // Error
                                if (ToolBarShowErrors.Pushed)
                                {
                                    ListLog.Items.Insert(0, item);
                                    item.EnsureVisible();
                                }
                                break;
                        }
                    }
                }
            }
        }
        #endregion
    }
}
