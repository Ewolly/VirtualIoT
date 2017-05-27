using System;
using System.Collections;
using System.ComponentModel;
using System.Runtime.InteropServices;

namespace VirtualIoT
{
    internal static class NativeMethods
    {

        [DllImport("User32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        internal static extern bool GetKeyboardState(byte[] lpKeyState);

    }

    class KeyboardSender : EventArgs
    {
        private BitArray _keysstate = new BitArray(256);
        private BitArray _oldkeysstate = new BitArray(256);
        private System.Windows.Forms.Timer _timer;

        public event EventHandler KeyEvent;

        public int key { get; private set; }
        public bool down { get; private set; }

        public void Start(int timerInterval = 10)
        {
            _timer = new System.Windows.Forms.Timer();
            _timer.Interval = timerInterval;
            _timer.Tick += GetKeysState;
            _timer.Start();
        }

        public void Stop()
        {
            _timer.Stop();
        }

        private void GetKeysState(object sender, EventArgs e)
        {
            byte[] keys = new byte[256];

            //Remember last state
            _oldkeysstate = (BitArray)_keysstate.Clone();

            //Get pressed keys
            if (!NativeMethods.GetKeyboardState(keys))
            {
                int err = Marshal.GetLastWin32Error();
                throw new Win32Exception(err);
            }

            //Get new state
            for (int i = 0; i < 256; i++)
                _keysstate[i] = ((keys[i] & 0x80) != 0);

            //Compare states
            for (int i = 0; i < 256; i++)
            {
                if (!_oldkeysstate[i] && _keysstate[i])
                {
                    //Console.WriteLine("down {0}", i);
                    key = i;
                    down = true;
                    KeyEvent?.Invoke(this, this);
                }
                if (_oldkeysstate[i] && !_keysstate[i])
                {
                    //Console.WriteLine("up {0}", i);
                    key = i;
                    down = false;
                    KeyEvent?.Invoke(this, this);
                }
            }
        }

    }
}