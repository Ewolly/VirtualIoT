using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Security;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VirtualIoT
{
    public partial class AudioForm : Form
    {
        SslStream _sslStream;
        DeviceInfo _device;
        private Timer _timer;
        private Timer _checkRespTimer;
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
            try
            {
                int x = _sslStream.Read(buffer, 0, 128);
                outputTxtBox.AppendText(Encoding.ASCII.GetString(buffer, 0, x));
            }
            catch { }
            finally
            {
                _sslStream.ReadTimeout = old_timeout;
            }
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
