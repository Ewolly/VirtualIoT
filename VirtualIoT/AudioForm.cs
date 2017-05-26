using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Security;
using System.Net.Sockets;
using System.Security.Authentication;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VirtualIoT.Properties;

namespace VirtualIoT
{
    public partial class AudioForm : Form
    {
        SslStream _sslStream;
        DeviceInfo _device;
        private Timer _timer;
        private Timer _checkRespTimer;
        private SslStream _sslClient;
        public X509Certificate2 _cert = new X509Certificate2(Resources.server, "IoTBox");

        public AudioForm(DeviceInfo device)
        {
            InitializeComponent();
            _device = device;

        }

        private void AudioEmulate_Load(object sender, EventArgs e)
        {
            _sslStream = _device.CreateSocket();
            if(_sslStream == null)
            {
                MessageBox.Show("Connection Failed");
                this.Close();
            }
            //start timer
            _timer = new Timer()
            {
                Interval = 2000
            };
            _timer.Tick += UpdateTimer;
            _timer.Start();

            _checkRespTimer = new Timer()
            {
                Interval = 200
            };
            _checkRespTimer.Tick += UpdateResponseBox;
            _checkRespTimer.Start();
        }

        private void UpdateResponseBox(object sender, EventArgs e)
        {
            var old_timeout = _sslStream.ReadTimeout;
            _sslStream.ReadTimeout = 10;
            var buffer = new byte[128];
            ResultObject result = null;
            try
            {
                _sslStream.Read(buffer, 0, 128);
                result = JsonConvert.DeserializeObject<ResultObject>(
                        Encoding.UTF8.GetString(buffer));
            }
            catch
            {
                return;
            }


            if (result == null)
                return;

            if (result.server != null)
            {
                Console.WriteLine(result.server);
                if (_sslClient == null)
                {
                    // put ssl tcp server start code here
                    // equivalent of start button

                    var server = new TcpListener(IPAddress.Any, 0);
                    server.Start();
                    var port = ((IPEndPoint)server.LocalEndpoint).Port;
                    var tcpClient = new TcpClient();
                    outputTxtBox.AppendText("Waiting for new Client");
                    _device.ConvertAndSend(_sslStream, new ResponseObject
                    {
                        response = "server_setup",
                        kwargs = new Dictionary<string, object>
                    {
                        { "ip" , GetLocalIPAddress() },
                        { "port" , port }
                    }
                    });
                    tcpClient = server.AcceptTcpClient();
                    _sslClient = new SslStream(tcpClient.GetStream(), false);
                    _sslClient.AuthenticateAsServer(_cert, false, SslProtocols.Tls, true);
                    outputTxtBox.AppendText("Connected new client: " + tcpClient.Client.RemoteEndPoint);
                }
            }
            else if (result.info != null)
            {
                statusLbl.Text = "Info: " + result.info;
            }
            else if (result.error != null)
            {
                statusLbl.Text = "Error: " + result.error;
            }
            else
            {
                statusLbl.Text = Encoding.UTF8.GetString(buffer);
            }
        }

        public static string GetLocalIPAddress()
        {
            var host = Dns.GetHostEntry(Dns.GetHostName());
            foreach (var ip in host.AddressList)
            {
                if (ip.AddressFamily == AddressFamily.InterNetwork)
                {
                    return ip.ToString();
                }
            }
            throw new Exception("Local IP Address Not Found!");
        }

        private void startBtn_Click(object sender, EventArgs e)
        {
           
        }

        private void stopBtn_Click(object sender, EventArgs e)
        {

        }

        private void currentHsb_Scroll(object sender, ScrollEventArgs e)
        {
            currentLbl.Text = "Current: " + currentHsb.Value + "mA";
        }

        private void currentLbl_Click(object sender, EventArgs e)
        {

        }

        private void sendCommandBtn_Click(object sender, EventArgs e)
        {
            try
            {
                _sslStream.Write(Encoding.UTF8.GetBytes(inputTxtBox.Text + "\r\n"));
            }
            catch
            {
                MessageBox.Show("server is gone");
                this.Close();
            }
        }

        private void UpdateTimer(object sender, EventArgs e)
        {
            _device.SendKeepalive(_sslStream, currentHsb.Value);
        }
    }
}
