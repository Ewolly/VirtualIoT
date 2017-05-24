using Gma.System.MouseKeyHook;
using MessagePack;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Net.Security;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Input;
namespace VirtualIoT
{
    public class USB_Thread
    {
        private IKeyboardMouseEvents _globalHook;
        public Point mousePos { get; set; }
        public string keyboard { get; set; }
        public SslStream _sslStream {get; set; }
        public string ipAddr { get; set; }
        public int port { get; set; }
        private USBData data { get; set; }

        [MessagePackObject]
        public class USBData
        {
            [Key(0)]
            public int x { get; set; }

            [Key(1)]
            public int y { get; set; }

            [Key(2)]
            public int mb { get; set; }
            //1 = lmb, 2 = rmb, 3 = mmb

            [Key(3)]
            public int scroll { get; set; }

            [Key(4)]
            public string keys { get; set; }

            [Key(5)]
            public string eof = "<EOF>";
        }

        public void Main()
        {
            _globalHook = Hook.GlobalEvents();

            _globalHook.MouseClick += HandleMouseClick;
            _globalHook.KeyPress += HandleKeyPress;

            data = new USBData
            {
                x = 750,
                y = 500,
                mb = 0,
                scroll = 0,
                keys = ""
            };
            while (true)
            {
                
                data.x = Cursor.Position.X;
                data.y = Cursor.Position.Y;
                //update data
                byte[] sendData;
                sendData = MessagePackSerializer.Serialize(data);
                //_sslStream.Write(sendData); 
            }
        }

        private void HandleKeyPress(object sender, KeyPressEventArgs e)
        {
            Console.WriteLine("key press");
            data.keys = "{" + e.KeyChar + "}";
        }

        private void HandleMouseClick(object sender, MouseEventArgs e)
        {
            Console.WriteLine("clicked");
            if(e.Button == MouseButtons.Left)
            {
                data.mb = 1;
            }
            else if(e.Button == MouseButtons.Right)
            {
                data.mb = 2;
            }
            else if(e.Button == MouseButtons.Middle)
            {
                data.mb = 3;
            }
            else
            {
                data.mb = 0;
            }
        }
    }


}
