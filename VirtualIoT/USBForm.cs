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
    public partial class USBForm : Form
    {
        SslStream _sslStream;
        DeviceInfo _device;
        public USBForm(DeviceInfo device)
        {
            InitializeComponent();
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
    }
}
