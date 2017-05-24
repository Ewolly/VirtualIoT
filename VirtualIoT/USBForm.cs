using MessagePack;
using Gma.System.MouseKeyHook;
using MessagePack;
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
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using VirtualIoT.Properties;

namespace VirtualIoT
{
    public partial class UsbForm : Form
    {
        private IKeyboardMouseEvents _globalHook;
        SslStream _sslStream;
        DeviceInfo _device;
        private TcpListener _server;
        private byte[] _buffer;
        private IPAddress _ip = IPAddress.Parse("192.168.0.137");
        private int _port = 12345;
        private TcpClient _tcpClient = new TcpClient();
        private NetworkStream _netStream;
        private SslStream _sslClient;
        public X509Certificate2 _cert = new X509Certificate2(Resources.server, "IoTBox");
        public UsbData _usbData;
        public bool _lock;

        public UsbForm(DeviceInfo device)
        {
            InitializeComponent();
            _server = new TcpListener(_ip, _port);
            _server.Start();
            _device = device;
        }

        private void USB_Load(object sender, EventArgs e)
        {
            _globalHook = Hook.GlobalEvents();
            _sslStream = _device.CreateSocket();
            if (_sslStream == null)
            {
                MessageBox.Show("Connection Failed");
                this.Close();
            }
        }

        private void currentHsb_Scroll(object sender, ScrollEventArgs e)
        {
            currentLbl.Text = "Current: " + currentHsb.Value / 100 + "mA";

        }

        private void currentLbl_Click(object sender, EventArgs e)
        {

        }

        private void clientsBtn_Click(object sender, EventArgs e)
        {
            _tcpClient = new TcpClient();
            textBox1.AppendText("Waiting for new Client");
            _tcpClient = _server.AcceptTcpClient();
            _sslClient = new SslStream(_tcpClient.GetStream(), false);
            _sslClient.AuthenticateAsServer(_cert, false, SslProtocols.Tls, true);
            textBox1.AppendText("Connected new client: " + _tcpClient.Client.RemoteEndPoint);
            SubscribeEvents();
        }

        private async void SendData()
        {
            if (_lock)
                return;
            _lock = true;
            var dataToSend = MessagePackSerializer.Serialize(_usbData);
            await _sslClient.WriteAsync(dataToSend, 0, dataToSend.Length);
            _lock = false;
        }

        public void SubscribeEvents()
        {
            _usbData = new UsbData()
            {
                x = 750,
                y = 500,
                mb = 0,
                scroll = 0,
                keys = ""
            };
            _globalHook.MouseClick += HandleMouseClick;
            _globalHook.MouseMoveExt += HandleMouseMove;
            _globalHook.KeyPress += HandleKeyPress;
        }

        private void HandleMouseMove(object sender, MouseEventExtArgs e)
        {
            _usbData.x = e.X;
            _usbData.y = e.Y;
            SendData();
        }

        private void HandleKeyPress(object sender, KeyPressEventArgs e)
        {
            _usbData.keys = e.KeyChar.ToString();
            SendData();
        }

        private void HandleMouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
                _usbData.mb = 1;
            else if (e.Button == MouseButtons.Right)
                _usbData.mb = 2;
            else if (e.Button == MouseButtons.Middle)
                _usbData.mb = 3;
            else
                _usbData.mb = 0;
            SendData();
           _usbData.mb = 0;
        }
    }
}
