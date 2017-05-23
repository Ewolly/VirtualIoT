using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VirtualIoT
{
    public class ResultObject
    {
        public string info { get; set; }
        public string error { get; set; }
        public bool? power { get; set; }
        public object[] ir_button { get; set; }
    }
}
