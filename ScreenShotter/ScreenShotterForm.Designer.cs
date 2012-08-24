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
            this.label1 = new System.Windows.Forms.Label();

            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "label1";
            this.label1.DoubleClick += new System.EventHandler(this.pathLabel_DoubleClick);
            // 
            // ScreenShotterForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(280, 30);
            this.Controls.Add(this.label1);
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

        private System.Windows.Forms.Label label1;

        private NotifyIcon notifyIcon;
    }
}

