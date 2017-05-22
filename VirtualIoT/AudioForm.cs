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
        }

        private void startBtn_Click(object sender, EventArgs e)
        {
           
        }

        private void stopBtn_Click(object sender, EventArgs e)
        {

        }

        private void currentHsb_Scroll(object sender, ScrollEventArgs e)
        {
            currentLbl.Text = "Current: " + currentHsb.Value / 100.0 + "A";
            _device.SendKeepalive(_sslStream, currentHsb.Value);
        }

        private void currentLbl_Click(object sender, EventArgs e)
        {

        }

        private void sendCommandBtn_Click(object sender, EventArgs e)
        {
            _sslStream.Write(Encoding.UTF8.GetBytes(inputTxtBox.Text + "\r\n"));
            //byte[] buffer = new byte[128];
            //_sslStream.Read(buffer, 0, 128);
            //outputTxtBox.AppendText(Encoding.UTF8.GetString(buffer));
        }
    }
}
