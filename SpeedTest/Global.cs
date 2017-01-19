#region Using
// Imported namespaces
using System;
using System.Collections.Generic;
using System.Drawing.Printing;
using System.IO;
using System.Runtime.InteropServices;
using System.Net.NetworkInformation;
using System.Text;
using System.Windows.Forms;
using SpeedTest.Properties;
#endregion
namespace SpeedTest
{
    /// <summary>The main class containing global objects and the entry point of the application.</summary>
    public static class Global
    {
        #region Enums
        /// <summary>Returned by the GetThemeMargins function to define the margins of windows that have visual styles applied.</summary>
        [StructLayout(LayoutKind.Sequential)]
        public struct MARGINS
        {
            public int cxLeftWidth;
            public int cxRightWidth;
            public int cyTopHeight;
            public int cyBottomHeight;

            public MARGINS(Margins margins)
            {
                cxLeftWidth = margins.Left;
                cxRightWidth = margins.Right;
                cyTopHeight = margins.Top;
                cyBottomHeight = margins.Bottom;
            }

            public MARGINS(int left, int right, int top, int bottom)
            {
                cxLeftWidth = left;
                cxRightWidth = right;
                cyTopHeight = top;
                cyBottomHeight = bottom;
            }
        }
        #endregion
        #region Members
        // Global variables
        private static FormMain g_FormMain;
        private static List<ListViewItem> g_ConnectionLog;
        //private static WindowsMediaPlayer g_MediaPlayer;
        #endregion
        #region Properties
        /// <summary>Gets a value indicating whether Desktop Composition is enabled on the system.</summary>
        public static bool CompositionEnabled
        {
            get
            {
                if (Environment.OSVersion.Version.Major < 6) return false;

                bool result = false;

                DwmIsCompositionEnabled(ref result);

                return result;
            }
        }

        /// <summary>Gets the main Form associated with this application.</summary>
        public static FormMain FormMain
        {
            get { return g_FormMain; }
        }

        /// <summary>Gets the connection log associated with this application.</summary>
        public static List<ListViewItem> ConnectionLog
        {
            get { return g_ConnectionLog; }
        }

        /// <summary>Gets a value determining if this computer is currently connected to the network.</summary>
        public static bool IsOnline
        {
            get
            {
                try
                {
                    Ping myPing = new Ping();
                    String host = "google.com";
                    byte[] buffer = new byte[32];
                    PingOptions pingOptions = new PingOptions();
                    PingReply reply = myPing.Send(host, 1000, buffer, pingOptions);

                    return reply.Status == IPStatus.Success;
                }
                catch
                {
                    return false;
                }
            }
        }

        /// <summary>Gets a value determining if this computer is currently running Windows 8.</summary>
        public static bool IsWindows8
        {
            get
            {
                return Environment.OSVersion.Version.Major.Equals(6) && Environment.OSVersion.Version.Minor.Equals(2);
            }
        }
        #endregion
        #region Entry Point
        /// <summary>The main entry point of the application.</summary>
        [STAThread]
        static void Main(string[] args)
        {
            // Local variables
            bool startLogging = false;
            if (args.Length > 0) startLogging = true;
            
            // Enable visual styles for the application
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // Initialize global variables
            g_FormMain = new FormMain(startLogging);
            g_ConnectionLog = new List<ListViewItem>();

            // Initialize settings
            if (string.IsNullOrEmpty(Settings.Default.DownloadURL)) Settings.Default.DownloadURL = "http://loggger.com/bigfile.zip";
            if (string.IsNullOrEmpty(Settings.Default.IPDetectURL)) Settings.Default.IPDetectURL = "http://icanhazip.com";
            if (string.IsNullOrEmpty(Settings.Default.LogFile)) Settings.Default.LogFile = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + Path.DirectorySeparatorChar + "SpeedTest" + Path.DirectorySeparatorChar + "SpeedTestLog.csv";
            if (Settings.Default.LogFile.ToLower().StartsWith(Application.StartupPath.ToLower())) Settings.Default.LogFile = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + Path.DirectorySeparatorChar + "SpeedTest" + Path.DirectorySeparatorChar + "ConnectionLog.csv";

            // Create SpeedTest folder
            if (!Directory.Exists(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + Path.DirectorySeparatorChar + "SpeedTest")) Directory.CreateDirectory(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + Path.DirectorySeparatorChar + "SpeedTest");

            // Load the connection log
            LoadConnectionLog(Settings.Default.LogFile);

            // Begin running the application
            Application.Run(g_FormMain);
        }
        #endregion
        #region External Methods
        [DllImport("dwmapi.dll")]
        public static extern void DwmExtendFrameIntoClientArea(IntPtr hWnd, ref MARGINS pMargins);

        [DllImport("dwmapi.dll")]
        public static extern void DwmIsCompositionEnabled(ref bool pfEnabled);

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern IntPtr SendMessage(IntPtr hWnd, int msg, int wParam, int lParam);

        [DllImport("UXTheme.dll", CharSet = CharSet.Unicode)]
        public static extern IntPtr SetWindowTheme(IntPtr hWnd, string textSubAppName, string textSubIdList);
        #endregion
        #region Public Methods
        /// <summary>Converts the specified bytes value into a human-readable string.</summary>
        public static string ConvertBytes(long bytes)
        {
            try
            {
                if (Settings.Default.SpeedUnits)
                {
                    double num = bytes;
                    if (num > Math.Pow(1024.0, 4.0))
                    {
                        num /= Math.Pow(1024.0, 4.0);
                        return (Math.Round(num, 2).ToString("###,###,##0.00") + " TB");
                    }
                    if ((num > Math.Pow(1024.0, 3.0)) && (num < Math.Pow(1024.0, 4.0)))
                    {
                        num /= Math.Pow(1024.0, 3.0);
                        return (Math.Round(num, 2).ToString("###,###,##0.00") + " GB");
                    }
                    if ((num > Math.Pow(1024.0, 2.0)) && (num < Math.Pow(1024.0, 3.0)))
                    {
                        num /= Math.Pow(1024.0, 2.0);
                        return (Math.Round(num, 2).ToString("###,###,##0.00") + " MB");
                    }
                    if ((num > 1024.0) && (num < Math.Pow(1024.0, 2.0)))
                    {
                        num /= 1024.0;
                        return (Math.Round(num, 2).ToString("###,###,##0.00") + " KB");
                    }
                    if (num < 1024.0)
                    {
                        return (Math.Round(num, 2).ToString("###,###,##0.00") + " B");
                    }
                }
                else
                {
                    double num = bytes * 8;
                    if (num > Math.Pow(1024.0, 4.0))
                    {
                        num /= Math.Pow(1024.0, 4.0);
                        return (Math.Round(num, 2).ToString("###,###,##0.00") + " tb");
                    }
                    if ((num > Math.Pow(1024.0, 3.0)) && (num < Math.Pow(1024.0, 4.0)))
                    {
                        num /= Math.Pow(1024.0, 3.0);
                        return (Math.Round(num, 2).ToString("###,###,##0.00") + " gb");
                    }
                    if ((num > Math.Pow(1024.0, 2.0)) && (num < Math.Pow(1024.0, 3.0)))
                    {
                        num /= Math.Pow(1024.0, 2.0);
                        return (Math.Round(num, 2).ToString("###,###,##0.00") + " mb");
                    }
                    if ((num > 1024.0) && (num < Math.Pow(1024.0, 2.0)))
                    {
                        num /= 1024.0;
                        return (Math.Round(num, 2).ToString("###,###,##0.00") + " kb");
                    }
                    if (num < 1024.0)
                    {
                        return (Math.Round(num, 2).ToString("###,###,##0.00") + " b");
                    }
                }
            }
            catch
            {
                if (Settings.Default.SpeedUnits) return "0 B";
                else return "0 b";
            }
            return null;
        }

        /// <summary>Converts the specified DateTime obejct into a human-readable string.</summary>
        public static string ConvertTime(DateTime time)
        {
            switch (Settings.Default.TimeFormat)
            {
                case 0: // ISO Format
                    return time.ToString("yyyy/MM/dd H:mm:ss");
                case 1: // EU Format
                    return time.ToString("dd/MM/yyyy H:mm:ss");
                case 2: // US Format
                    return time.ToString("MM/dd/yyyy hh:mm:ss tt");
                default:
                    return time.ToShortDateString() + " " + time.ToShortTimeString();
            }
        }

        /// <summary>Extends the window frame into the client area.</summary>
        public static void ExtendFrame(IntPtr handle, Margins margins)
        {
            MARGINS m = new MARGINS(margins);
            DwmExtendFrameIntoClientArea(handle, ref m);
        }

        /// <summary>Converts a Unix Timestamp value into a DateTime object.</summary>
        public static DateTime FromUnixTime(long time)
        {
            if (time == 0) return DateTime.Now;

            DateTime epoch = new DateTime(1970, 1, 1, 0, 0, 0, 0);
            return epoch.AddSeconds(Convert.ToDouble(time)).ToLocalTime();
        }

        /// <summary>Loads the connection log from the specified CSV file.</summary>
        public static void LoadConnectionLog(string fileName)
        {
            try
            {
                if (File.Exists(fileName))
                {
                    using (StreamReader reader = new StreamReader(fileName))
                    {
                        string line = reader.ReadLine();

                        while (!string.IsNullOrEmpty(line))
                        {
                            if (line.ToLower().StartsWith("index"))
                            {
                                line = reader.ReadLine();
                                continue;
                            }

                            string[] s = line.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);

                            if (s.Length > 5)
                            {
                                DateTime time = FromUnixTime(ToInt64(s[1]));

                                ListViewItem item = new ListViewItem(Global.ConvertTime(time)); // Time (String)
                                item.SubItems.Add(Global.ConvertBytes(ToInt64(s[3]))); // Speed (String)
                                item.SubItems.Add(s[5]); // IP
                                item.SubItems.Add(s[6]); // Message
                                item.SubItems.Add(s[7]); // Status
                                item.SubItems.Add(s[3]); // Speed (Bytes)
                                item.ImageIndex = ToInt32(s[0]); // Index
                                item.Tag = time; // Time (DateTime)

                                g_ConnectionLog.Add(item);
                            }

                            line = reader.ReadLine();
                        }
                    }
                }
            }
            catch { }
        }

        /// <summary>Calculates a percentage (0.0-max%) given the specified values.</summary>
        public static float Percent(float complete, float total, float max = 100.0f)
        {
            if (complete <= 0.0f || total <= 0.0f) return 0.0f;

            return (complete / total) * max;
        }

        /// <summary>Calculates a percentage (0-max%) given the specified values.</summary>
        public static int Percent(int complete, int total, int max = 100)
        {
            if (complete == 0 || total == 0) return 0;

            double result = Convert.ToDouble(complete) / Convert.ToDouble(total);
            result *= Convert.ToDouble(max);

            return Convert.ToInt32(result);
        }

        /// <summary>Saves the connection log in CSV file format.</summary>
        public static void SaveConnectionLog(string fileName)
        {
            try
            {
                using (StreamWriter writer = new StreamWriter(fileName))
                {
                    writer.WriteLine("Index,Time(U),Time(S),Speed(B),Speed(S),IP,Message,Status");

                    foreach (ListViewItem item in g_ConnectionLog)
                    {
                        DateTime time = (DateTime)item.Tag;

                        writer.WriteLine(item.ImageIndex.ToString() + "," + // Index
                            ToUnixTime(time).ToString() + "," + // Time (Unix Timestamp)
                            ConvertTime(time) + "," + // Time (String)
                            item.SubItems[5].Text + "," + // Speed (Bytes)
                            item.SubItems[1].Text + "," + // Speed (String)
                            item.SubItems[2].Text + "," + // IP
                            item.SubItems[3].Text + "," + // Message
                            item.SubItems[4].Text); // Status
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        /// <summary>Calculates a scalar value (0.0-1.0) given the specified values.</summary>
        public static float Scalar(float complete, float total)
        {
            if (complete <= 0.0f || total <= 0.0f) return 0.0f;

            return complete / total;
        }

        /// <summary>Converts a string value into a Int32 value.</summary>
        public static int ToInt32(string s)
        {
            int result = 0;

            if (Int32.TryParse(s, out result)) return result;
            return 0;
        }

        /// <summary>Converts a string value into a Int64 value.</summary>
        public static long ToInt64(string s)
        {
            long result = 0;

            if (Int64.TryParse(s, out result)) return result;
            return 0;
        }

        /// <summary>Converts a DateTime object into a Unix Timestamp value.</summary>
        public static long ToUnixTime(DateTime time)
        {
            return Convert.ToInt64((time - new DateTime(1970, 1, 1, 0, 0, 0, 0).ToLocalTime()).TotalSeconds);
        }
        #endregion
    }
}
