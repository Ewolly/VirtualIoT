using MessagePack;
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
using System.Collections;

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
        public AudioMsgPack _recieve;
        public AudioMsgPack _send;
        private bool _sendLock;
        private bool _recieveLock;
        private bool _micLock;
        private bool _speakerLock;
        private bool _startRecordingLock = false;
        private bool _startPlaybackLock = false;
        public AudioRead _audioRead = new AudioRead();
        private FixedSizedQueue<byte[]> SendQueue = new FixedSizedQueue<byte[]>(32);
        private FixedSizedQueue<byte[]> RecieveQueue = new FixedSizedQueue<byte[]>(32);


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
            if (_speakerLock)
            {
                _recieveLock = false;
                var buffer = new byte[512];
                _sslClient.ReadTimeout = 1;
                try
                {
                    _sslClient.Read(buffer, 0, 512);
                    outputTxtBox.AppendText(Encoding.UTF8.GetString(buffer));
                    _recieve = MessagePackSerializer.Deserialize<AudioMsgPack>(buffer);
                }
                catch
                {
                    return;
                }
                finally
                {
                    _sslClient.ReadTimeout = -1;
                }
                    
                _sendLock = _recieve.mic;  // enables sending of data if dan requests mic
                _recieveLock = _recieve.speaker; // if dan requests speaker set _recieve lock true
                if (_recieveLock && _speakerLock)    // enters here if dan requests it and speaker enabled
                {
                    RecieveQueue.Enqueue(_recieve.mp3);  // maybe make this only do this if it isnt locked?
                    if (_startPlaybackLock) // only want to start playback once for the request
                    {
                        _startPlaybackLock = false;
                        _audioRead.StartRecording(RecieveQueue);
                    }

                }
            }
        }

        private void SendData(object sender, EventArgs e)
        {
            if (_micLock && _sendLock)  //if mic is "plugged in" will allow sending
            {   
                if (_startRecordingLock) // only want to start recording once for the request
                {
                    _startRecordingLock = false;
                    _audioRead.StartRecording(SendQueue);
                }
                _send.mic = micCb.Checked;
                _send.speaker = micCb.Checked;
                byte[] mp3;
                bool success = SendQueue.TryDequeue(out mp3);
                if (success)
                {
                    _send.mp3 = mp3;
                    _sendLock = false;
                    var dataToSend = MessagePackSerializer.Serialize(_send);
                    _sslClient.Write(dataToSend, 0, dataToSend.Length);
                }

                
            }
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

            var server = new TcpListener(IPAddress.Any, 12345);
            server.Start();
            var port = ((IPEndPoint)server.LocalEndpoint).Port;
            var tcpClient = new TcpClient();
            outputTxtBox.AppendText("Waiting for new Client");
            //_device.ConvertAndSend(_sslStream, new ResponseObject
            //{
            //    response = "server_setup",
            //    kwargs = new Dictionary<string, object>
            //{
            //    { "ip" , GetLocalIPAddress() },
            //    { "port" , port }
            //}
            //});
            tcpClient = server.AcceptTcpClient();
            _sslClient = new SslStream(tcpClient.GetStream(), false);
            _sslClient.AuthenticateAsServer(_cert, false, SslProtocols.Tls, true);
            outputTxtBox.AppendText("Connected new client: " + tcpClient.Client.RemoteEndPoint);

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
            if(micCb.Checked == true)
            {
                _micLock = true;
            }
            else
            {
                _micLock = false;
            }
        }

        private void speakerCb_CheckedChanged(object sender, EventArgs e)
        {
            if (speakerCb.Checked == true)
            {
                _speakerLock = true;
            }
            else
            {
                _speakerLock = false;
            }
        }
    }
}
