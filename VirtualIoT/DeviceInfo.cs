using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VirtualIoT
{
    public class DeviceInfo
    {
        public int module_type { get; set; }
        public string device_id { get; set; }
        public string device_url { get; set; }
        public string token { get; set; }
        public string FriendlyName { get; set; }
        public DeviceInfo()
        {
        }
    }
}
