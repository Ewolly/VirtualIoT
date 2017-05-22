using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;
using System.Net.Security;
using Newtonsoft.Json;

namespace VirtualIoT
{
    public class DeviceInfo
    {
        public int module_type { get; set; }
        public int device_id { get; set; }
        public string device_url { get; set; }
        public string token { get; set; }
        public string FriendlyName { get; set; }
        TcpClient _tcpClient;
        SslStream _sslStream;
        public DeviceInfo()
        {
            
        }

        public SslStream CreateSocket()
        {
            _tcpClient = new TcpClient("iot.duality.co.nz", 7777);
            _sslStream = new SslStream(_tcpClient.GetStream());

            _sslStream.AuthenticateAsClient("iot.duality.co.nz");
            byte[] action = Encoding.UTF8.GetBytes(
                JsonConvert.SerializeObject(
                    new Dictionary<string, object>
                    {
                        {"id", device_id },
                        {"token", token }
                    }) + "\r\n");
            _sslStream.Write(action, 0, action.Length);

            byte[] buffer = new byte[128];
            _sslStream.Read(buffer, 0, buffer.Length);
            var response = JsonConvert.DeserializeObject<Dictionary<string, string>>(Encoding.UTF8.GetString(buffer));
            if(response.ContainsKey("info")) 
                return _sslStream;
            return null;
        }

        public void sendCurrent(int current)
        {
            { "action": "keepalive",
              "args": {
                    "current_consumption": current
                }
            }
        }
    }
}
