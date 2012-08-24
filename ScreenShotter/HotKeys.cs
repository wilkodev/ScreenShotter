using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace ScreenShotter
{
    /// <summary>
    /// Class is used to register this program with windows to intercept hot keys.
    /// </summary>
    class HotKeys
    {
        [DllImport("user32.dll")]
        private static extern bool RegisterHotKey(IntPtr hWnd, int id, int fsModifiers, int vk);

        [DllImport("user32.dll")]
        private static extern bool UnregisterHotKey(IntPtr hWnd, int id);

        //Modifying hot key: Win, Alt, Ctrl, Shift, or none
        private int modifier;
        //The hot key: Anything but a modifier
        private int key;
        //Windows pointer to the Form or control
        private IntPtr hWnd;
        //Unique ID for this Hot key
        private int id;

        public HotKeys(int modifier, Keys key, IntPtr handle)
        {
            this.modifier = modifier;
            this.key = (int)key;
            this.hWnd = handle;
            this.id = this.GetHashCode();
        }

        /// <summary>
        /// Build the hash code by XOR'ing the form, modifier, and key
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {
            return modifier ^ key ^ hWnd.ToInt32();
        }

        /// <summary>
        /// Register the hot key combo with windows
        /// </summary>
        /// <returns>True if successful</returns>
        public bool Register()
        {
            return RegisterHotKey(hWnd, id, modifier, key);
        }

        /// <summary>
        /// Unregister the hot key combo with windows
        /// </summary>
        /// <returns>True if successful</returns>
        public bool Unregister()
        {
            return UnregisterHotKey(hWnd, id);
        }

        /// <summary>
        /// List of allowed modifiers
        /// </summary>
        public static class Constants
        {
            //Nomod is blank (no modifier)
            public const int NOMOD = 0x0000;
            public const int ALT = 0x0001;
            public const int CTRL = 0x0002;
            public const int SHIFT = 0x0004;
            public const int WIN = 0x0008;

            //Used by windows to alert that a hot key is triggered
            public const int WM_HOTKEY_MSG_ID = 0x0312;
        }
    }
}