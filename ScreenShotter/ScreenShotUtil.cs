using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Drawing.Imaging;

namespace ScreenShotter
{
    /// <summary>
    /// The utility to take a screenshot
    /// </summary>
    class ScreenShotUtil
    {
        /// <summary>
        /// The image is stored
        /// </summary>
        private Image img;
        /// <summary>
        /// The graphical context used
        /// </summary>
        private Graphics gfx;
        /// <summary>
        /// The directory where everything images are getting stored
        /// </summary>
        private string directory;

        /// <summary>
        /// The directory where everything images are getting stored
        /// </summary>
        public string Directory
        {
            get
            {
                return directory;
            }
        }

        /// <summary>
        /// Structure REQUIRED by Windows
        /// </summary>
        [StructLayout(LayoutKind.Sequential)]
        public struct RECT
        {
            public int Left;
            public int Top;
            public int Right;
            public int Bottom;
        }

        [DllImport("user32.dll")]
        static extern IntPtr GetForegroundWindow();

        [DllImport("user32.dll")]
        static extern int GetWindowRect(IntPtr hWnd, out RECT rect);

        public ScreenShotUtil()
        {
            //Use the home directory as the location to store files
            directory = @"%USERPROFILE%\";
            directory = Environment.ExpandEnvironmentVariables(directory);
        }

        /// <summary>
        /// Capture the whole primary screen
        /// </summary>
        public void CaptureScreen()
        {
            //Capture area of the whole primary screen
            CaptureArea(Screen.GetBounds(new Point(0, 0)).Width,
                        Screen.GetBounds(new Point(0, 0)).Height,
                        0,
                        0);
        }

        /// <summary>
        /// Capture the currently active window
        /// </summary>
        public void CaptureWindow()
        {
            //Call windows API to figure out where the active screen is
            RECT rect;
            IntPtr window = GetForegroundWindow();
            GetWindowRect(window, out rect);

            CaptureArea(rect.Right - rect.Left,
                        rect.Bottom - rect.Top,
                        rect.Left,
                        rect.Top);
        }

        /// <summary>
        /// Capture the specified area of the screen
        /// </summary>
        /// <param name="Width">Width of area to capture</param>
        /// <param name="Height">Height of area to capture</param>
        /// <param name="xOffset">X-coordinate of screen offset</param>
        /// <param name="yOffset">Y-coordinate of screen offset</param>
        private void CaptureArea(int Width, int Height, int xOffset, int yOffset)
        {
            img = new Bitmap(Width, Height);
            gfx = Graphics.FromImage(img);
            gfx.CopyFromScreen(xOffset, yOffset, 0, 0, new Size(Width, Height), CopyPixelOperation.SourceCopy);

            SaveImage();
        }

        /// <summary>
        /// Save the screenshot as an image to the disk
        /// </summary>
        private void SaveImage()
        {
            try
            {
                String path = Directory + "Screenshot-" + DateTime.Now.Ticks + ".png";

                img.Save(path, ImageFormat.Png);

                //Cleanup...not sure if needed, but helps reduce footprint
                img.Dispose();
                gfx.Dispose();
            }
            catch (Exception ex)
            { }
        }
    }
}
