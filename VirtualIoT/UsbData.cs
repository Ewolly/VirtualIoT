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
    [MessagePackObject]
    public class UsbData
    {
        [Key(0)]
        public int x { get; set; }

        [Key(1)]
        public int y { get; set; }

        [Key(2)]
        public int mb { get; set; }
        //1 = lmbdn, 2 = lmbup, 3 = rmbdn, 4 = rmbup

        [Key(3)]
        public int scroll { get; set; }

        [Key(4)]
        public byte key { get; set; }

        [Key(5)]
        public bool down { get; set; }
        
        [Key(6)]
        public string eof = "<EOF>";
    }
}
