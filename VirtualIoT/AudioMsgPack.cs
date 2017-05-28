using MessagePack;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VirtualIoT
{
    [MessagePackObject]
    public class AudioMsgPack
    {
        [Key(0)]
        public bool mic { get; set; }

        [Key(1)]
        public bool speaker { get; set; }

        [Key(2)]
        public byte[] mp3 { get; set; }
    }
}
