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
    public partial class USBForm : Form
    {
        SslStream _sslStream;
        DeviceInfo _device;
        private TcpListener _server;
        private byte[] _buffer;
        private IPAddress _ip = IPAddress.Parse("192.168.0.137");
        private int _port = 12345;
        private TcpClient _tcpClient = new TcpClient();
        private NetworkStream _netStream;
        private SslStream _ssl;
        public X509Certificate2 cert = new X509Certificate2(Resources.server, "IoTBox");
        private USB_Thread USB;
        private Thread USBThread;
        public USBForm(DeviceInfo device)
        {
            InitializeComponent();
            _server = new TcpListener(_ip, _port);
            _server.Start();
            _device = device;
        }

        private void USB_Load(object sender, EventArgs e)
        {
            _sslStream = _device.CreateSocket();
            if (_sslStream == null)
            {
                MessageBox.Show("Connection Failed");
                this.Close();
            }
        }

        private void currentHsb_Scroll(object sender, ScrollEventArgs e)
        {
            currentLbl.Text = "Current: " + currentHsb.Value / 100.0 + "A";

        }

        private void currentLbl_Click(object sender, EventArgs e)
        {

        }

        private void clientsBtn_Click(object sender, EventArgs e)
        {
            _tcpClient = new TcpClient();
            textBox1.AppendText("Waiting for new Client");
            //_tcpClient = _server.AcceptTcpClient(); // this is blocking, there is a non-blocking version AcceptTcpClientAsync
            //_netStream = _tcpClient.GetStream();
            //_ssl = new SslStream(_netStream, false);
            //_ssl.AuthenticateAsServer(cert, false, SslProtocols.Tls, true);
            //textBox1.AppendText("Connected new client: " + _tcpClient.Client.RemoteEndPoint);
            USB = new USB_Thread
            {
                _sslStream = _ssl,
                ipAddr = "192.168.0.137",
                port = 12345
            };
            USBThread = new Thread(new ThreadStart(USB.Main));
            USBThread.Start();
            //start new thread
        }

        private void stopBtn_Click(object sender, EventArgs e)
        {
            USBThread.Abort();
        }

        public string StatusText
        {
            set { textBox1.Text = value;}
        }
    }
}
