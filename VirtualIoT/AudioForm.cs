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
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Threading;
using NAudio.Wave;
using NAudio.Lame;

namespace VirtualIoT
{
    public partial class AudioForm : Form
    {
        SslStream _sslStream;
        DeviceInfo _device;
        private System.Windows.Forms.Timer _timer;
        private System.Windows.Forms.Timer _checkRespTimer;
        private SslStream _sslClient;
        public X509Certificate2 _cert = new X509Certificate2(Resources.server, "IoTBox");
        private bool _receiving;
        private bool _sending;
        private MemoryStream _inStream = new MemoryStream();
        private MemoryStream _outStream = new MemoryStream();
        private LameMP3FileWriter _writer = null;
        private Thread _audioThread = null;

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
            _timer = new System.Windows.Forms.Timer()
            {
                Interval = 2000
            };
            _timer.Tick += UpdateTimer;
            _timer.Start();

            _checkRespTimer = new System.Windows.Forms.Timer()
            {
                Interval = 200
            };
            _checkRespTimer.Tick += UpdateResponseBox;
            _checkRespTimer.Start();

            var server = new TcpListener(IPAddress.Any, 12345);
            server.Start();
            var port = ((IPEndPoint)server.LocalEndpoint).Port;
            var tcpClient = new TcpClient();
            outputTxtBox.AppendText("Waiting for new Client" + Environment.NewLine);
            tcpClient = server.AcceptTcpClient();
            _sslClient = new SslStream(tcpClient.GetStream(), false);
            _sslClient.AuthenticateAsServer(_cert, false, SslProtocols.Tls, true);
            outputTxtBox.AppendText("Connected new client: " + tcpClient.Client.RemoteEndPoint + Environment.NewLine);

            ReceiveData();
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
                if (_sslClient == null)
                {
                    var server = new TcpListener(IPAddress.Any, 0);
                    server.Start();
                    var port = ((IPEndPoint)server.LocalEndpoint).Port;
                    var tcpClient = new TcpClient();
                    outputTxtBox.AppendText("Waiting for new Client" + Environment.NewLine);
                    _device.ConvertAndSend(_sslStream, new ResponseObject
                    {
                        response = "server_setup",
                        kwargs = new Dictionary<string, object>
                    {
                        { "ip" , GetLocalIPAddress().ToString() },
                        { "port" , port }
                    }
                    });
                    tcpClient = server.AcceptTcpClient();
                    _sslClient = new SslStream(tcpClient.GetStream(), false);
                    _sslClient.AuthenticateAsServer(_cert, false, SslProtocols.Tls, true);
                    outputTxtBox.AppendText("Connected new client: " + tcpClient.Client.RemoteEndPoint + Environment.NewLine);

                    ReceiveData();
                }
            
            else if (result.info != null)
                statusLbl.Text = "Info: " + result.info;
            else if (result.error != null)
                statusLbl.Text = "Error: " + result.error;
            else
                statusLbl.Text = Encoding.UTF8.GetString(buffer);
        }

        private async void ReceiveData()
        {
            sendChkBox.Enabled = willReceiveChkBox.Enabled = true;
            receiveChkBox.Enabled = willSendChkBox.Enabled = true;
            while (_sslClient != null)
                await ReceiveDataAsync();
            sendChkBox.Enabled = willReceiveChkBox.Enabled = false;
            receiveChkBox.Enabled = willSendChkBox.Enabled = false;
        }

        private async Task ReceiveDataAsync()
        {
            byte[] buffer = new byte[65536];
            int bytesRead = 1;
            int totalLen = 0;
            while (bytesRead > 0)
            {
                bytesRead = await _sslClient.ReadAsync(buffer,
                    totalLen, buffer.Length - totalLen);
                totalLen += bytesRead;

                if (Encoding.UTF8.GetString(buffer.Take(totalLen).ToArray()).Contains("<EOF>"))
                    break;
            }

            if (bytesRead < 0)
            {
                outputTxtBox.AppendText("Socket closed?\r\n");
                _sslClient.Dispose();
                _sslClient = null;
                return;
            }

            outputTxtBox.AppendText("Received data\r\n");

            var resp = MessagePackSerializer.Deserialize<AudioPack>(buffer.Take(totalLen).ToArray());
            willReceiveChkBox.Checked = resp.WillReceive;
            willSendChkBox.Checked = resp.WillSend;

            if (resp.Mp3Data != null)
            {
                var pos = _inStream.Position;
                _inStream.Position = _inStream.Length;
                await _inStream.WriteAsync(resp.Mp3Data, 0, resp.Mp3Data.Length);
                _inStream.Position = pos;
            }
        }

        private async Task SendData(bool willReceive, bool willSend, byte[] mp3Data)
        {
            if (_sslClient == null)
                return;

            byte[] buffer = MessagePackSerializer.Serialize(new AudioPack()
            {
                WillReceive = willReceive,
                WillSend = willSend,
                Mp3Data = mp3Data
            });
            await _sslClient.WriteAsync(buffer, 0, buffer.Length);
            if (mp3Data != null)
                outputTxtBox.AppendText(String.Format("wrote {0} bytes\r\n", buffer.Length));
        }

        private static IPAddress GetLocalIPAddress()
        {
            using (Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, 0))
            {
                socket.Connect("8.8.8.8", 65530);
                IPEndPoint endPoint = socket.LocalEndPoint as IPEndPoint;
                return endPoint.Address;
            }
        }
        
        private void currentHsb_Scroll(object sender, ScrollEventArgs e)
        {
            currentLbl.Text = "Current: " + currentHsb.Value + "mA";
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

        private async void checkboxChangedAsync(object sender, EventArgs e)
        {
            _receiving = receiveChkBox.Checked && willSendChkBox.Checked;
            if (_receiving && _audioThread == null)
            {
                _audioThread = new Thread(new ThreadStart(PlayAudio));
                _audioThread.Start();
            }
            else if (_audioThread != null)
            {
                _audioThread.Abort();
                _audioThread = null;
            }

            _sending = sendChkBox.Checked && willReceiveChkBox.Checked;
            if (_sending)
            {
                StartSendingAudio();
            }
            await SendData(receiveChkBox.Checked, sendChkBox.Checked, null);
        }
        private async void StartSendingAudio()
        {
            if (_writer != null)
                return;
            var waveIn = new WasapiLoopbackCapture();

            using (_writer = new LameMP3FileWriter(_outStream, waveIn.WaveFormat, LAMEPreset.ABR_256))
            {
                waveIn.DataAvailable += OnDataAvailable;
                waveIn.StartRecording();

                while (_sslClient != null && _sending)
                {
                    while (_outStream.Length < 4196)
                        await Task.Delay(100);

                    _outStream.Position = 0;
                    byte[] mp3Data = new byte[32768];
                    int bytesRead = await _outStream.ReadAsync(mp3Data, 0, mp3Data.Length);
                    _outStream.SetLength(0);
                    _outStream.Position = 0;

                    if (bytesRead != 0)
                        await SendData(receiveChkBox.Checked, sendChkBox.Checked,
                            mp3Data.Take(bytesRead).ToArray());
                }
            }
            waveIn.StopRecording();
            waveIn.DataAvailable -= OnDataAvailable;
        }

        private void PlayAudio()
        {
            while (_receiving)
            {
                while (_inStream.Length < 4000)
                    Thread.Sleep(100);

                _inStream.Position = 0;
                using (WaveStream blockAlignedStream = new BlockAlignReductionStream(
                    WaveFormatConversionStream.CreatePcmStream(new Mp3FileReader(_inStream))))
                {
                    using (WaveOut waveOut = new WaveOut(WaveCallbackInfo.FunctionCallback()))
                    {
                        waveOut.Init(blockAlignedStream);
                        waveOut.Play();
                        while (waveOut.PlaybackState == PlaybackState.Playing)
                        {
                            Thread.Sleep(100);
                        }
                    }
                    _inStream.SetLength(0);
                    _inStream.Position = 0;
                }
            }
        }

        private void OnDataAvailable(object sender, WaveInEventArgs e)
        {
            _writer.Write(e.Buffer, 0, e.BytesRecorded);
        }
    }

    [MessagePackObject]
    public class AudioPack
    {
        [Key(0)]
        public bool WillReceive { get; set; }

        [Key(1)]
        public bool WillSend { get; set; }

        [Key(2)]
        public byte[] Mp3Data { get; set; }

        [Key(3)]
        public string EOF = "<EOF>";
    }
}
