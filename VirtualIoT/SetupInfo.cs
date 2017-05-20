using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VirtualIoT
{
    class SetupInfo
    {
        public string email { get; set; }
        public int module_type { get; set; }
        public int setup_time { get; set; }
        public string friendly_name { get; set; }
        public SetupInfo()
        {
        } 
    }
}
