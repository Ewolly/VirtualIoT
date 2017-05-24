﻿using Gma.System.MouseKeyHook;
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
    [MessagePackObject]
    public class UsbData
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


        //public void Main()
        //{
        //    data = new USBData
        //    {
        //        x = 750,
        //        y = 500,
        //        mb = 0,
        //        scroll = 0,
        //        keys = ""
        //    };
        //    while (true)
        //    {

        //        data.x = Cursor.Position.X;
        //        data.y = Cursor.Position.Y;
        //        //update data
        //        byte[] sendData;
        //        sendData = MessagePackSerializer.Serialize(data);
        //        //_sslStream.Write(sendData); 
        //    }
        //}
    }
}