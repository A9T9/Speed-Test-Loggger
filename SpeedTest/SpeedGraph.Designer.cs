namespace SpeedTest
{
    partial class SpeedGraph
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.ComboTimeScale = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // ComboTimeScale
            // 
            this.ComboTimeScale.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.ComboTimeScale.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ComboTimeScale.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.ComboTimeScale.FormattingEnabled = true;
            this.ComboTimeScale.Items.AddRange(new object[] {
            "10 Minutes",
            "30 Minutes",
            "1 Hour",
            "12 Hours",
            "24 Hours"});
            this.ComboTimeScale.Location = new System.Drawing.Point(30, 116);
            this.ComboTimeScale.Name = "ComboTimeScale";
            this.ComboTimeScale.Size = new System.Drawing.Size(107, 21);
            this.ComboTimeScale.TabIndex = 0;
            this.ComboTimeScale.SelectedIndexChanged += new System.EventHandler(this.ComboTimeScale_SelectedIndexChanged);
            // 
            // SpeedGraph
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.Controls.Add(this.ComboTimeScale);
            this.DoubleBuffered = true;
            this.Name = "SpeedGraph";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox ComboTimeScale;
    }
}
