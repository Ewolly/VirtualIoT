using MessagePack;
using Newtonsoft.Json;
using System;
using System.Linq;
using System.Net;
using System.Net.Security;
using System.Net.Sockets;
using System.Security.Authentication;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Windows.Forms;
using VirtualIoT.Properties;
using System.IO;

namespace VirtualIoT
{
    public partial class AudioForm : Form
    {
        SslStream _sslStream;
        DeviceInfo _device;
        private Timer _timer;
        private Timer _checkRespTimer;
        private Timer _audioTimer;
        private SslStream _sslClient;
        public X509Certificate2 _cert = new X509Certificate2(Resources.server, "IoTBox");
        public AudioMsgPack _receive;
        public AudioMsgPack _send;
        public AudioRead _audioRead = new AudioRead();
        public AudioWrite _audioWrite = new AudioWrite();
        private MemoryStream _inStream = null;

        public AudioForm(DeviceInfo device)
        {
            InitializeComponent();
            _device = device;

            _audioTimer = new Timer();
            _audioTimer.Interval = 5;
            _audioTimer.Tick += SendData;
            _audioTimer.Tick += RecieveData;

            _audioTimer.Start();

        }

        private void RecieveData(object sender, EventArgs e)
        {
            int readLen = 0;
            byte[] readBytes = new byte[65536];
            do
            {
                readLen += _sslClient.Read(readBytes, readLen, readBytes.Length - readLen);
                if (Encoding.UTF8.GetString(readBytes.Take(readLen).ToArray()).Contains("<EOF>"))
                    break;
            } while (readLen > 0);
            
            if (readLen <= 0)
            {
                Console.WriteLine("dont know how we got here tbh");
                return;
            }

            _receive = MessagePackSerializer.Deserialize<AudioMsgPack>(readBytes.Take(readLen).ToArray());
            SpeakConCb.Checked = _receive.speaker;
            MicConCb.Checked = _receive.mic;

            if (SpeakConCb.Checked && speakerCb.Checked)
            {
                if (_inStream == null) // only want to start playback once for the request
                {
                    _inStream = _audioWrite.StartPlayback();
                    outputTxtBox.AppendText("started playback");
                }

                if (_receive.mp3 != null)
                {
                    var pos = _inStream.Position;
                    _inStream.Position = _inStream.Length;
                    _inStream.Write(_receive.mp3, 0, _receive.mp3.Length);
                    _inStream.Position = pos;
                }
            }
        }

        private void SendData(object sender, EventArgs e)
        {
            //if (_micLock && _sendLock)  //if mic is "plugged in" will allow sending
            //{   
            //    if (_startRecordingLock) // only want to start recording once for the request
            //    {
            //        _startRecordingLock = false;
            //        _audioRead.StartRecording(SendQueue);
            //    }
            //    _send.mic = micCb.Checked;
            //    _send.speaker = micCb.Checked;
            //    byte[] mp3;
            //    bool success = SendQueue.TryDequeue(out mp3);
            //    if (success)
            //    {
            //        _send.mp3 = mp3;
            //        _sendLock = false;
            //        var dataToSend = MessagePackSerializer.Serialize(_send);
            //        _sslClient.Write(dataToSend, 0, dataToSend.Length);
            //    }
            //}
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

            /* delete htis */
            var server = new TcpListener(IPAddress.Any, 12345);
            server.Start();
            var port = ((IPEndPoint)server.LocalEndpoint).Port;
            var tcpClient = new TcpClient();
            outputTxtBox.AppendText("Waiting for new Client");
            tcpClient = server.AcceptTcpClient();
            _sslClient = new SslStream(tcpClient.GetStream(), false);
            _sslClient.AuthenticateAsServer(_cert, false, SslProtocols.Tls, true);
            outputTxtBox.AppendText("Connected new client: " + tcpClient.Client.RemoteEndPoint);
            /* delete htis */
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
                if (_sslClient == null)
                {
                    // put ssl tcp server start code here
                    // equivalent of start button

                    //var server = new TcpListener(IPAddress.Any, 12345);
                    //server.Start();
                    //var port = ((IPEndPoint)server.LocalEndpoint).Port;
                    //var tcpClient = new TcpClient();
                    //outputTxtBox.AppendText("Waiting for new Client");
                    ////_device.ConvertAndSend(_sslStream, new ResponseObject
                    ////{
                    ////    response = "server_setup",
                    ////    kwargs = new Dictionary<string, object>
                    ////{
                    ////    { "ip" , GetLocalIPAddress() },
                    ////    { "port" , port }
                    ////}
                    ////});
                    //tcpClient = server.AcceptTcpClient();
                    //_sslClient = new SslStream(tcpClient.GetStream(), false);
                    //_sslClient.AuthenticateAsServer(_cert, false, SslProtocols.Tls, true);
                    //outputTxtBox.AppendText("Connected new client: " + tcpClient.Client.RemoteEndPoint);
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

        private void micCb_CheckedChanged(object sender, EventArgs e)
        {
        }

        private void speakerCb_CheckedChanged(object sender, EventArgs e)
        {
        }
    }
}
