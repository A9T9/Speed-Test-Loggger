#region Using
// Imported namespaces
using System;
using System.Diagnostics;
using System.Net;
#endregion
namespace SpeedTest
{
    /// <summary>Custom WebClient object that supports timing the estimated time of arrival (ETA) of the file download.</summary>
    public class CustomWebClient : WebClient
    {
        #region Members
        // Private variables
        private long p_AllBytesDownloaded;
        private long p_CurrentSpeed;
        private long p_LastBytesDownloaded;
        private Stopwatch p_Stopwatch;
        #endregion
        #region Properties
        /// <summary>Gets the total number of bytes downloaded using an asynchronous request.</summary>
        public long AllBytesDownloaded
        {
            get { return p_AllBytesDownloaded; }
        }

        /// <summary>Gets the current speed of data downloaded using an asynchronous request.</summary>
        public long CurrentSpeed
        {
            get { return p_CurrentSpeed; }
        }

        /// <summary>Gets the most recent number of bytes downloaded using an asynchronous request.</summary>
        public long LastBytesDownloaded
        {
            get { return p_LastBytesDownloaded; }
        }

        /// <summary>Gets the Stopwatch object used to calculate the estimated time of arrival (ETA).</summary>
        public Stopwatch Stopwatch
        {
            get { return p_Stopwatch; }
        }
        #endregion
        #region Constructor
        /// <summary>Initializes a new instance of the CustomWebClient class.</summary>
        public CustomWebClient() : base()
        {
            // Initialize private variables
            p_AllBytesDownloaded = 0;
            p_CurrentSpeed = 0;
            p_LastBytesDownloaded = 0;
            p_Stopwatch = new Stopwatch();
        }
        #endregion
        #region Overrides
        /// <summary>Occurs when an asynchronous data download operation completes.</summary>
        protected override void OnDownloadDataCompleted(DownloadDataCompletedEventArgs e)
        {
            // Reset the Stopwatch
            p_Stopwatch.Reset();

            // Continue processing the event as usual
            base.OnDownloadDataCompleted(e);
        }

        /// <summary>Occurs when an asynchronous download operation successfully transfers some or all of the data.</summary>
        protected override void OnDownloadProgressChanged(DownloadProgressChangedEventArgs e)
        {
            try
            {
                if (p_LastBytesDownloaded.Equals(0)) p_LastBytesDownloaded = e.BytesReceived;
                else
                {
                    long bytesChange = e.BytesReceived - p_LastBytesDownloaded;

                    // Update private variables
                    p_AllBytesDownloaded += bytesChange;
                    p_LastBytesDownloaded = e.BytesReceived;
                    p_CurrentSpeed = Convert.ToInt64(p_AllBytesDownloaded / p_Stopwatch.Elapsed.TotalSeconds);
                }
            }
            catch { }

            // Continue processing the event as usual
            base.OnDownloadProgressChanged(e);
        }

        /// <summary>Occurs when an asynchronous string download operation completes.</summary>
        protected override void OnDownloadStringCompleted(DownloadStringCompletedEventArgs e)
        {
            // Start the Stopwatch
            p_Stopwatch.Start();

            // Continue processing the event as usual
            base.OnDownloadStringCompleted(e);
        }
        #endregion
    }
}
