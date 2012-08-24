using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;

namespace ScreenShotter
{
    public partial class ScreenShotterForm : Form
    {
        private HotKeys hotKey;
        private HotKeys hotKey2;
        private ScreenShotUtil utl;

        public ScreenShotterForm()
        {
            InitializeComponent();
            utl = new ScreenShotUtil();
            
            //Create 2 hotkeys:
            //Win+PrintScreen = Active Window Screenshot
            //Ctrl+PrintScreen = Whole Primary Screen Screenshot
            hotKey = new HotKeys(HotKeys.Constants.WIN, Keys.PrintScreen, this.Handle);
            hotKey2 = new HotKeys(HotKeys.Constants.CTRL, Keys.PrintScreen, this.Handle);

            label1.Text = "Images stored in: " + utl.Directory;
        }

        /// <summary>
        /// Determine which hotkey is pressed and what to do
        /// </summary>
        /// <param name="modifier"></param>
        private void HandleHotKey(int modifier)
        {
            if(modifier == HotKeys.Constants.WIN)
                utl.CaptureWindow();
            else if(modifier == HotKeys.Constants.CTRL)
                utl.CaptureScreen();
        }

        /// <summary>
        /// Used as the alert mechanism from Windows for hot keys
        /// </summary>
        /// <param name="m"></param>
        protected override void  WndProc(ref Message m)
        {
            if (m.Msg == HotKeys.Constants.WM_HOTKEY_MSG_ID)
            {
                //Determine if its the right modifier
                int modifier = (int)m.LParam & 0xFFFF;
                if (modifier == HotKeys.Constants.WIN || modifier == HotKeys.Constants.CTRL)
                {
                    HandleHotKey(modifier);
                }
            }
 	        base.WndProc(ref m);
        }

        private void ScreenshotUtilityForm_Load(object sender, System.EventArgs e)
        {
            hotKey.Register();
            hotKey2.Register();
        }

        /// <summary>
        /// If minimzed, add tray icon, otherwise remove trayicon
        /// </summary>
        /// <param name="sender">sender</param>
        /// <param name="e">event</param>
        private void ScreenshotUtilityForm_Resize(object sender, System.EventArgs e)
        {
            notifyIcon.BalloonTipTitle = "Screentshot Util";
            notifyIcon.BalloonTipText = "Press Win+PrintScreen to take a screenshot\nCtrl+PrintScreen for full screen";

            if (this.WindowState == FormWindowState.Minimized)
            {
                notifyIcon.Visible = true;
                notifyIcon.ShowBalloonTip(500);
                this.Hide();
            }
            else if (this.WindowState == FormWindowState.Normal || this.WindowState == FormWindowState.Maximized)
            {
                notifyIcon.Visible = false;
            }
        }

        /// <summary>
        /// Restore window from tray icon
        /// </summary>
        /// <param name="sender">sender</param>
        /// <param name="e">event</param>
        private void notifyIcon_DoubleClick(object sender, System.EventArgs e)
        {
            this.Show();
            this.WindowState = FormWindowState.Normal;
        }

        private void pathLabel_DoubleClick(object sender, System.EventArgs e)
        {
            Process.Start("explorer.exe", this.utl.Directory);
        }
    }
}
