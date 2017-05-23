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
        public List<IRButton> buttons { get; set; }

        public DeviceInfo()
        {
        }

        public SslStream CreateSocket()
        {
            TcpClient tcpClient = new TcpClient("iot.duality.co.nz", 7777);
            SslStream sslStream = new SslStream(tcpClient.GetStream());

            sslStream.AuthenticateAsClient("iot.duality.co.nz");
            byte[] action = Encoding.UTF8.GetBytes(
                JsonConvert.SerializeObject(
                    new Dictionary<string, object>
                    {
                        {"id", device_id },
                        {"token", token }
                    }) + "\r\n");
            sslStream.Write(action, 0, action.Length);

            byte[] buffer = new byte[128];
            sslStream.Read(buffer, 0, buffer.Length);
            var response = JsonConvert.DeserializeObject<Dictionary<string, string>>(
                Encoding.UTF8.GetString(buffer));
            if(response.ContainsKey("info")) 
                return sslStream;
            return null;
        }

        public void SendKeepalive(SslStream sslStream, int curr)
        {
            var currentCommand = new Dictionary<string, object>
            {
                {"action", "keepalive" },
                {"kwargs", new Dictionary<string, int>
                    {
                        { "current_consumption", curr }
                    }
                }
            };
            ConvertAndSend(sslStream, currentCommand);
        }

        public void SendIRFeedback(SslStream sslStream, bool[] feedback)
        {
            var feedbackResponse = new Dictionary<string, object>
            {
                {"response", "infrared" },
                {"kwargs", new Dictionary<string, bool[]>
                    {
                        { "feedbacks", feedback }
                    }
                }
            };
            ConvertAndSend(sslStream, feedbackResponse);
        }

        public void ConvertAndSend(SslStream sslStream, object message)
        {
            byte[] action = Encoding.UTF8.GetBytes(
                JsonConvert.SerializeObject(message) + "\r\n");
            sslStream.Write(action, 0, action.Length);
        }
        public class IRButton
        {
            public int? id { get; set; }
            public string name { get; set; }
            public bool? continuous { get; set; }
            public int? num_pulses { get; set; }
            public IRButton()
            {
            }

        }
    }
}
