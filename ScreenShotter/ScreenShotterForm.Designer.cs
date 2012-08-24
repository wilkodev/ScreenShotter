using System.Windows.Forms;

namespace ScreenShotter
{
    partial class ScreenShotterForm
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
                hotKey.Unregister();
                hotKey2.Unregister();
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
            this.directoryLabel = new System.Windows.Forms.Label();

            this.SuspendLayout();
            // 
            // directoryLabel
            // 
            this.directoryLabel.AutoSize = true;
            this.directoryLabel.Location = new System.Drawing.Point(12, 9);
            this.directoryLabel.Name = "directoryLabel";
            this.directoryLabel.Size = new System.Drawing.Size(35, 13);
            this.directoryLabel.TabIndex = 0;
            this.directoryLabel.Text = "directoryLabel";
            this.directoryLabel.DoubleClick += new System.EventHandler(this.directoryLabel_DoubleClick);
            // 
            // ScreenShotterForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(280, 30);
            this.Controls.Add(this.directoryLabel);
            this.Name = "ScreenShotterForm";
            this.Text = "ScreenShotter";
            this.ResumeLayout(false);
            this.PerformLayout();

            // 
            // notifyIcon
            // 
            this.notifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.notifyIcon.Icon = global::ScreenShotter.Properties.Resources.NotifyIcon;
            this.notifyIcon.DoubleClick += new System.EventHandler(this.notifyIcon_DoubleClick);
            this.components.Add(notifyIcon);

            this.Load += new System.EventHandler(this.ScreenshotUtilityForm_Load);
            this.Resize += new System.EventHandler(this.ScreenshotUtilityForm_Resize);
        }

        #endregion

        private System.Windows.Forms.Label directoryLabel;

        private NotifyIcon notifyIcon;
    }
}

