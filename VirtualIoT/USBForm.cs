using MessagePack;
using Gma.System.MouseKeyHook;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Security;
using System.Net.Sockets;
using System.Security.Authentication;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Windows.Forms;
using VirtualIoT.Properties;
using Newtonsoft.Json;

namespace VirtualIoT
{
    public partial class UsbForm : Form
    {
        private IKeyboardMouseEvents _globalHook;
        SslStream _sslStream = null;
        DeviceInfo _device;
        private SslStream _sslClient = null;
        public X509Certificate2 _cert = new X509Certificate2(Resources.server, "IoTBox");
        public UsbData _usbData;
        private Timer _usbTimer;
        private bool _send;
        private Timer _aliveTimer;
        private Timer _timer;
        private KeyboardSender _kbs;

        public UsbForm(DeviceInfo device)
        {
            InitializeComponent();
            _device = device;

            _usbTimer = new Timer();
            _usbTimer.Interval = 5;
            _usbTimer.Tick += SendData;

        }

        private void kbs_KeyEvent(object sender, EventArgs e)
        {
            //Console.WriteLine("key pressed");
            _usbData.key = _kbs.key;
            _usbData.down = _kbs.down;
            _send = true;
        }

        private void SendData(object sender, EventArgs e)
        {
            if (_send)
            {
                _send = false;
                var dataToSend = MessagePackSerializer.Serialize(_usbData);
                _sslClient.Write(dataToSend, 0, dataToSend.Length);
            }
        }

        private void USB_Load(object sender, EventArgs e)
        {

            _sslStream = _device.CreateSocket();
            if (_sslStream == null)
            {
                MessageBox.Show("Connection Failed");
                this.Close();
            }

            //start timer
            _timer = new Timer()
            {
                Interval = 200
            };
            _timer.Tick += UpdateTimer;
            _timer.Start();

            // timer for the keep alive
            _aliveTimer = new Timer()
            {
                Interval = 2000
            };
            _aliveTimer.Tick += aliveTimer;
            _aliveTimer.Start();

            _globalHook = Hook.GlobalEvents();
        }

        private void currentHsb_Scroll(object sender, ScrollEventArgs e)
        {
            currentLbl.Text = "Current: " + currentHsb.Value / 100 + "mA";

        }

        private void currentLbl_Click(object sender, EventArgs e)
        {

        }

        public void SubscribeEvents()
        {
            _usbData = new UsbData()
            {
                x = 0,
                y = 0,
                mb = 0,
                scroll = 0,
                key = 0,
                down = false
            };
            _globalHook.MouseUpExt += HandleMouseUpExt;
            _globalHook.MouseDownExt += HandleMouseDownExt;
            _globalHook.MouseMoveExt += HandleMouseMove;
            //_globalHook.KeyPress += HandleKeyPress;
            _usbTimer.Start();
            _send = true;
            
            _kbs = new KeyboardSender();
            _kbs.KeyEvent += kbs_KeyEvent;
            _kbs.Start(2); //time interval (ms)
        }

        private void HandleMouseDownExt(object sender, MouseEventExtArgs e)
        {
            if (e.Button == MouseButtons.Left)
                _usbData.mb = 1;
            else if (e.Button == MouseButtons.Right)
                _usbData.mb = 3;
            else
                _usbData.mb = 0;
            _send = true;
        }

        private void HandleMouseUpExt(object sender, MouseEventExtArgs e)
        {
            if (e.Button == MouseButtons.Left)
                _usbData.mb = 2;
            else if (e.Button == MouseButtons.Right)
                _usbData.mb = 4;
            else
                _usbData.mb = 0;
            _send = true;
        }

        private void HandleMouseMove(object sender, MouseEventExtArgs e)
        {
            _usbData.x = e.X;
            _usbData.y = e.Y;
            _send = true;
        }

        private void HandleKeyPress(object sender, KeyPressEventArgs e)
        {
            Console.WriteLine("key pressed");
            _usbData.key = (byte)e.KeyChar;
            _send = true;
        }

        private void aliveTimer(object sender, EventArgs e)
        {
            _device.SendKeepalive(_sslStream, currentHsb.Value);
        }

        public static string GetLocalIPAddress()
        {
            string localIP;
            using (Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, 0))
            {
                socket.Connect("8.8.8.8", 65530);
                IPEndPoint endPoint = socket.LocalEndPoint as IPEndPoint;
                return endPoint.Address.ToString();
            }

        }

        private void UpdateTimer(object sender, EventArgs e)
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
                    textBox1.AppendText("Waiting for new Client");
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
                    textBox1.AppendText("Connected new client: " + tcpClient.Client.RemoteEndPoint);
                    SubscribeEvents();
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

    }
}
