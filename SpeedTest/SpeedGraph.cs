#region Using
// Imported namespaces
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.Windows.Forms;
using SpeedTest.Properties;
#endregion
namespace SpeedTest
{
    /// <summary>Custom user control that displays a graph representing download speeds.</summary>
    public partial class SpeedGraph : UserControl
    {
        #region Members
        // Private variables
        private long p_MaxBits;
        private long p_MaxBytes;
        #endregion
        #region Properties
        /// <summary>Gets the maximum number of bits downloaded according to the connection log.</summary>
        public long MaxBits
        {
            get { return p_MaxBits; }
        }

        /// <summary>Gets the maximum number of bytes downloaded according to the connection log.</summary>
        public long MaxBytes
        {
            get { return p_MaxBytes; }
        }
        #endregion
        #region Constructor
        /// <summary>Initializes a new instance of the SpeedGraph class.</summary>
        public SpeedGraph()
        {
            // This call is required by the designer
            InitializeComponent();

            // Initialize private variables
            p_MaxBits = 1024000 * 2;
            p_MaxBytes = 1024000 * 2;

            // Initialize SpeedGraph properties
            this.Font = new Font(SystemFonts.MenuFont.FontFamily, 8.0f);
            this.ResizeRedraw = true;

            // Initialize child controls
            ComboTimeScale.Font = SystemFonts.MenuFont;
            ComboTimeScale.SelectedIndex = Settings.Default.TimeScale;
        }
        #endregion
        #region Overrides
        /// <summary>Occurs when the SpeedGraph is redrawn.</summary>
        protected override void OnPaint(PaintEventArgs e)
        {
            // Local variables
            int speed = 0;
            int time = 0;

            // Adjust Graphics object properties
            e.Graphics.SmoothingMode = SmoothingMode.HighQuality;
            e.Graphics.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;

            // Draw the background
            e.Graphics.FillRectangle(SystemBrushes.Window, 40, 20, Width - 60, Height - 80);

            // Draw the border
            e.Graphics.DrawRectangle(SystemPens.ControlDark, 40, 20, Width - 60, Height - 80);

            // Create a new SolidBrush object
            using (SolidBrush b = new SolidBrush(ForeColor))
            {
                if (Height > 80)
                {
                    // Local variables
                    int totalTime = 0;
                    int counter = 0;
                    int speedCounter = 0;
                    bool flag = true;
                    bool speedFlag = true;

                    switch (Settings.Default.TimeScale)
                    {
                        case 0: // 10 Minutes
                            totalTime = 10;
                            break;
                        case 1: // 30 Minutes
                            totalTime = 30;
                            break;
                        case 2: // 1 Hour
                            totalTime = 60;
                            break;
                        case 3: // 12 Hours
                            totalTime = 12;
                            break;
                        case 4: // 24 Hours
                            totalTime = 24;
                            break;
                    }

                    // Draw the Timeline
                    for (float f = Width - 20.0f; f >= 39.0f; f -= Global.Percent(1, totalTime, Width - 60.0f))
                    {
                        if (f < Width - 20.0f && f > 41.0f) e.Graphics.DrawLine(SystemPens.Control, f, 21, f, Height - 60);
                        e.Graphics.DrawLine(SystemPens.ControlDark, f, Height - 60, f, Height - 56);
                        if (Width > 320 && flag)
                        {
                            DateTime time2 = DateTime.Now;

                            switch (Settings.Default.TimeScale)
                            {
                                case 0: // 10 Minutes
                                    time2 = DateTime.Now.Subtract(new TimeSpan(0, 0, time, 0));
                                    break;
                                case 1: // 30 Minutes
                                    time2 = DateTime.Now.Subtract(new TimeSpan(0, 0, time, 0));
                                    break;
                                case 2: // 1 Hour
                                    time2 = DateTime.Now.Subtract(new TimeSpan(0, 0, time, 0));
                                    break;
                                case 3: // 12 Hours
                                    time2 = DateTime.Now.Subtract(new TimeSpan(0, time, 0, 0));
                                    break;
                                case 4: // 24 Hours
                                    time2 = DateTime.Now.Subtract(new TimeSpan(0, time, 0, 0));
                                    break;
                            }

                            if (time.ToString().Length > 1) e.Graphics.DrawString(time2.ToString("HH:mm"), Font, b, f - 16, Height - 56);
                            else e.Graphics.DrawString(time2.ToString("HH:mm"), Font, b, f - 13, Height - 56);
                        }
                        time += 1;

                        if (Settings.Default.TimeScale == 2)
                        {
                            counter++;

                            if (counter == 4 || counter == 8)
                            {
                                //counter = 0;
                                flag = true;
                            }
                            else flag = false;

                            if (counter == 8) counter = 0;
                        }
                        else flag = !flag;
                    }

                    // Draw the speed units
                    if (Settings.Default.SpeedUnits)
                    {
                        for (float f = Height - 60.0f; f >= 19.0f; f -= Global.Percent(1024000, p_MaxBytes, Height - 80.0f))
                        {
                            if (f < Height - 60.0f && f > 21.0f) e.Graphics.DrawLine(SystemPens.Control, 41, f, Width - 21, f);
                            e.Graphics.DrawLine(SystemPens.ControlDark, 36, f, 40, f);
                            if (Height > 120 && speedFlag) e.Graphics.DrawString(speed.ToString(), Font, b, 26, f - 7);
                            speed += 1;
                            speedCounter++;

                            if (p_MaxBytes > 1024000 * 60)
                            {
                                if (speedCounter == 6)
                                {
                                    speedCounter = 0;
                                    speedFlag = true;
                                }
                                else speedFlag = false;
                            }
                            else if (p_MaxBytes > 1024000 * 40)
                            {
                                if (speedCounter == 4)
                                {
                                    speedCounter = 0;
                                    speedFlag = true;
                                }
                                else speedFlag = false;
                            }
                            else if (p_MaxBytes > 1024000 * 20)
                            {
                                if (speedCounter == 2)
                                {
                                    speedCounter = 0;
                                    speedFlag = true;
                                }
                                else speedFlag = false;
                            }
                            else if (p_MaxBytes > 1024000 * 10)
                            {
                                speedCounter = 0;
                                speedFlag = !speedFlag;
                            }
                            else
                            {
                                speedCounter = 0;
                                speedFlag = true;
                            }
                        }
                    }
                    else
                    {
                        for (float f = Height - 60.0f; f >= 19.0f; f -= Global.Percent(1024000, p_MaxBits, Height - 80.0f))
                        {
                            if (f < Height - 60.0f && f > 21.0f) e.Graphics.DrawLine(SystemPens.Control, 41, f, Width - 21, f);
                            e.Graphics.DrawLine(SystemPens.ControlDark, 36, f, 40, f);
                            if (Height > 120 && speedFlag) e.Graphics.DrawString(speed.ToString(), Font, b, 26, f - 7);
                            speed += 1;
                            speedCounter++;

                            if (p_MaxBits > 1024000 * 60)
                            {
                                if (speedCounter == 6)
                                {
                                    speedCounter = 0;
                                    speedFlag = true;
                                }
                                else speedFlag = false;
                            }
                            else if (p_MaxBits > 1024000 * 40)
                            {
                                if (speedCounter == 4)
                                {
                                    speedCounter = 0;
                                    speedFlag = true;
                                }
                                else speedFlag = false;
                            }
                            else if (p_MaxBits > 1024000 * 20)
                            {
                                if (speedCounter == 2)
                                {
                                    speedCounter = 0;
                                    speedFlag = true;
                                }
                                else speedFlag = false;
                            }
                            else if (p_MaxBits > 1024000 * 10)
                            {
                                speedCounter = 0;
                                speedFlag = !speedFlag;
                            }
                            else
                            {
                                speedCounter = 0;
                                speedFlag = true;
                            }
                        }
                    }

                    // Create a new StringFormat object
                    using (StringFormat sf = (StringFormat)StringFormat.GenericTypographic.Clone())
                    {
                        // Set vertical text direction
                        sf.FormatFlags = StringFormatFlags.DirectionVertical;

                        if (Height > 120)
                        {
                            if (Settings.Default.SpeedUnits) e.Graphics.DrawString("Speed (MB)", Font, b, new PointF(6, (Height - 94) / 2), sf);
                            else e.Graphics.DrawString("Speed (mb)", Font, b, new PointF(6, (Height - 94) / 2), sf);
                        }

                        if (Width > 320) e.Graphics.DrawString("Timeline:", SystemFonts.MenuFont, b, Width - 186, Height - 32);
                    }

                    // Draw the color keys
                    if (Height > 30)
                    {
                        e.Graphics.FillRectangle(Brushes.Orange, 6, Height - 30, 122, 14);
                        e.Graphics.DrawString("No Internet Connection", Font, b, 6, Height - 30);
                    }

                    //if (Height > 20)
                    //{
                        //e.Graphics.FillRectangle(Brushes.Yellow, 6, Height - 20, 108, 14);
                        //e.Graphics.DrawString("Logger Not Running", Font, b, 6, Height - 20);
                    //}

                    if (Global.ConnectionLog != null)
                    {
                        // Local variables
                        //bool online = false;
                        int onlineCount = 0;
                        long lastItemSpeed = 0;
                        if (Global.ConnectionLog.Count > 0) lastItemSpeed = Global.ToInt64(Global.ConnectionLog[Global.ConnectionLog.Count - 1].SubItems[5].Text);

                        // Bits instead of bytes
                        if (!Settings.Default.SpeedUnits) lastItemSpeed *= 8;
                        
                        List<PointF> points = new List<PointF>();
                        //List<PointF> loggerPoints = new List<PointF>();
                        List<PointF> offlinePoints = new List<PointF>();
                        PointF lastPoint = new PointF();
                        //PointF lastOnlinePoint = new PointF();
                        PointF firstOfflinePoint = new PointF();

                        if (Settings.Default.SpeedUnits) lastPoint = new PointF(Width - 21, (Height - 61) - Global.Percent(lastItemSpeed, p_MaxBytes, Height - 80));
                        else lastPoint = new PointF(Width - 21, (Height - 61) - Global.Percent(lastItemSpeed, p_MaxBits, Height - 80));

                        points.Add(new PointF(Width - 20, Height - 60));

                        if (Settings.Default.SpeedUnits) points.Add(new PointF(Width - 20, (Height - 61) - Global.Percent(lastItemSpeed, p_MaxBytes, Height - 80)));
                        else points.Add(new PointF(Width - 20, (Height - 61) - Global.Percent(lastItemSpeed, p_MaxBits, Height - 80)));

                        // Draw the download speed
                        for (int i = Global.ConnectionLog.Count - 1; i >= 0; i--)
                        {
                            // Local variables
                            long itemTime = Global.ToUnixTime((DateTime)Global.ConnectionLog[i].Tag);
                            long elapsedTime = 0;
                            long itemSpeed = Global.ToInt64(Global.ConnectionLog[i].SubItems[5].Text);

                            // Bits instead of bytes
                            if (!Settings.Default.SpeedUnits) itemSpeed *= 8;

                            switch (Settings.Default.TimeScale)
                            {
                                case 0: // 10 Minutes
                                    elapsedTime = Global.ToUnixTime(DateTime.Now.Subtract(new TimeSpan(0, 0, 10, 0)));
                                    break;
                                case 1: // 30 Minutes
                                    elapsedTime = Global.ToUnixTime(DateTime.Now.Subtract(new TimeSpan(0, 0, 30, 0)));
                                    break;
                                case 2: // 1 Hour
                                    elapsedTime = Global.ToUnixTime(DateTime.Now.Subtract(new TimeSpan(0, 1, 0, 0)));
                                    break;
                                case 3: // 12 Hours
                                    elapsedTime = Global.ToUnixTime(DateTime.Now.Subtract(new TimeSpan(0, 12, 0, 0)));
                                    break;
                                case 4: // 24 Hours
                                    elapsedTime = Global.ToUnixTime(DateTime.Now.Subtract(new TimeSpan(0, 24, 0, 0)));
                                    break;
                            }

                            // Local variables
                            long now = Global.ToUnixTime(DateTime.Now);
                            long complete = itemTime - elapsedTime;
                            long total = now - elapsedTime;

                            if (complete > 0)
                            {
                                float x = Global.Percent(complete, total, Width - 61) + 40;

                                // Update private variables
                                if (Settings.Default.SpeedUnits)
                                {
                                    if (itemSpeed > p_MaxBytes) p_MaxBytes = itemSpeed;
                                }
                                else
                                {
                                    if (itemSpeed > p_MaxBits) p_MaxBits = itemSpeed;
                                }

                                if (Settings.Default.SpeedUnits) e.Graphics.DrawLine(Pens.Green, lastPoint.X, lastPoint.Y, x, (Height - 61) - Global.Percent(itemSpeed, p_MaxBytes, Height - 80));
                                else e.Graphics.DrawLine(Pens.Green, lastPoint.X, lastPoint.Y, x, (Height - 61) - Global.Percent(itemSpeed, p_MaxBits, Height - 80));

                                //if (Global.ConnectionLog[i].SubItems[4].Text.Equals("Logger Started"))
                                //{
                                    //loggerPoints.Add(new PointF(x, 20));
                                    //loggerPoints.Add(new PointF(x, Height - 60));

                                    //e.Graphics.DrawLine(Pens.Yellow, x, 21, x, Height - 60);
                                //}
                                //else if (Global.ConnectionLog[i].SubItems[4].Text.Equals("Logger Stopped"))
                                //{
                                    //loggerPoints.Add(new PointF(x, Height - 60));
                                    //loggerPoints.Add(new PointF(x, 20));

                                    //using (SolidBrush b2 = new SolidBrush(Color.FromArgb(100, Color.Yellow)))
                                    //{
                                        //e.Graphics.FillPolygon(b2, loggerPoints.ToArray());
                                    //}
                                    //loggerPoints.Clear();

                                    //e.Graphics.DrawLine(Pens.Yellow, x, 21, x, Height - 60);
                                //}
                                if (Global.ConnectionLog[i].SubItems[4].Text.Equals("Online"))
                                {
                                    if (offlinePoints.Count == 0)
                                    {
                                        offlinePoints.Add(new PointF(x, 20));
                                        offlinePoints.Add(new PointF(x, Height - 60));
                                    }
                                    else
                                    {
                                        offlinePoints.Clear();
                                    }

                                    //e.Graphics.DrawLine(Pens.Orange, x, 21, x, Height - 60);

                                    //lastOnlinePoint = new PointF(x, Height - 60);
                                    //online = true;
                                    onlineCount++;
                                }
                                else if (Global.ConnectionLog[i].SubItems[4].Text.Equals("Offline"))
                                {
                                    if (offlinePoints.Count == 2)
                                    {
                                        offlinePoints.Add(new PointF(x, Height - 60));
                                        offlinePoints.Add(new PointF(x, 20));

                                        using (SolidBrush b2 = new SolidBrush(Color.FromArgb(100, Color.Orange)))
                                        {
                                            e.Graphics.FillPolygon(b2, offlinePoints.ToArray());
                                        }
                                        offlinePoints.Clear();
                                    }

                                    //e.Graphics.DrawLine(Pens.Orange, x, 21, x, Height - 60);

                                    if (onlineCount == 0) firstOfflinePoint = new PointF(x, Height - 60);
                                    //if (firstOfflinePoint.X.Equals(0) && firstOfflinePoint.Y.Equals(0) && !online) firstOfflinePoint = new PointF(x, Height - 60);
                                    //online = false;
                                }


                                if (Settings.Default.SpeedUnits) lastPoint = new PointF(x, (Height - 61) - Global.Percent(itemSpeed, p_MaxBytes, Height - 80));
                                else lastPoint = new PointF(x, (Height - 61) - Global.Percent(itemSpeed, p_MaxBits, Height - 80));

                                points.Add(lastPoint);
                            }
                        }

                        //if (online)
                        //{
                            //offlinePoints.Clear();
                            //offlinePoints.Add(new PointF(40, 20));
                            //offlinePoints.Add(new PointF(lastOnlinePoint.X, 20));
                            //offlinePoints.Add(new PointF(lastOnlinePoint.X, Height - 60));
                            //offlinePoints.Add(new PointF(40, Height - 60));

                            //using (SolidBrush b2 = new SolidBrush(Color.FromArgb(100, Color.Orange)))
                            //{
                                //e.Graphics.FillPolygon(b2, offlinePoints.ToArray());
                            //}

                            //e.Graphics.DrawLine(Pens.Orange, lastOnlinePoint.X, 21, lastOnlinePoint.X, Height - 60);
                        //}

                        if (!firstOfflinePoint.X.Equals(0) && !firstOfflinePoint.Y.Equals(0))
                        {
                            offlinePoints.Clear();
                            offlinePoints.Add(new PointF(firstOfflinePoint.X, 20));
                            offlinePoints.Add(new PointF(Width - 20, 20));
                            offlinePoints.Add(new PointF(Width - 20, Height - 60));
                            offlinePoints.Add(new PointF(firstOfflinePoint.X, Height - 60));

                            using (SolidBrush b2 = new SolidBrush(Color.FromArgb(100, Color.Orange)))
                            {
                                e.Graphics.FillPolygon(b2, offlinePoints.ToArray());
                            }

                            //e.Graphics.DrawLine(Pens.Green, firstOfflinePoint.X, 21, firstOfflinePoint.X, Height - 60);
                        }

                        e.Graphics.DrawLine(Pens.Green, 40, lastPoint.Y, lastPoint.X, lastPoint.Y);

                        points.Add(new PointF(40, lastPoint.Y));
                        points.Add(new PointF(40, Height - 60));

                        // Fill in the download speed
                        using (SolidBrush b2 = new SolidBrush(Color.FromArgb(100, Color.Green)))
                        {
                            e.Graphics.FillPolygon(b2, points.ToArray());
                        }
                    }
                }
            }

            // Continue processing the event as usual
            base.OnPaint(e);
        }

        /// <summary>Occurs whe the SpeedGraph is resized.</summary>
        protected override void OnResize(EventArgs e)
        {
            // Set the Timeline combo box visibility
            ComboTimeScale.Visible = Width > 260 && Height > 80;

            // continue processing the event as usual
            base.OnResize(e);
        }
        #endregion
        #region Event Handlers
        /// <summary>Occurs when the selected index changes in the Timeline combo box.</summary>
        private void ComboTimeScale_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Update configuration settings
            Settings.Default.TimeScale = ComboTimeScale.SelectedIndex;

            // Re-draw the control
            Invalidate();
        }
        #endregion
    }
}
