﻿using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace GW2MH.Core.Input
{
    internal class GlobalHotkey
    {

        private int modifier;
        private int key;
        private IntPtr hWnd;
        public int ID { get; private set; }

        public GlobalHotkey(int modifier, Keys key, Form form)
        {
            this.modifier = modifier;
            this.key = (int)key;
            hWnd = form.Handle;
        }

        public bool Register(int id)
        {
            ID = id;
            return RegisterHotKey(hWnd, id, modifier, key);
        }

        public bool Unregister()
        {
            return UnregisterHotKey(hWnd, ID);
        }

        [DllImport("user32.dll")]
        private static extern bool RegisterHotKey(IntPtr hWnd, int id, int fsModifiers, int vk);

        [DllImport("user32.dll")]
        private static extern bool UnregisterHotKey(IntPtr hWnd, int id);
    }

    internal static class Constants
    {
        //modifiers
        public const int NOMOD = 0x0000;
        public const int ALT = 0x0001;
        public const int CTRL = 0x0002;
        public const int SHIFT = 0x0004;
        public const int WIN = 0x0008;
        //windows message id for hotkey
        public const int WM_HOTKEY_MSG_ID = 0x0312;
    }

}