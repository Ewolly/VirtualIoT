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
        public string server { get; set; }
        public object[] ir_button { get; set; }
        public Dictionary<string, object>[] feedback { get; set; }
    }

    public class ActionObject
    {
        public string action { get; set; }
        public Dictionary<string, object> kwargs { get; set; }
    }

    public class ResponseObject
    {
        public string response { get; set; }
        public Dictionary<string, object> kwargs { get; set; }
    }

}
