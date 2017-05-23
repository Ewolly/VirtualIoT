using Newtonsoft.Json;
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
    public partial class InfraredForm : Form
    {
        private ServerComm _serverComm = ServerComm.Instance;
        SslStream _sslStream;
        DeviceInfo _device;
        private Timer _timer;
        private Timer _aliveTimer;
        public InfraredForm(DeviceInfo device)
        {
            InitializeComponent();
            _device = device;
        }

        private async void Infrared_Load(object sender, EventArgs e)
        {
            _sslStream = _device.CreateSocket();
            if (_sslStream == null)
            {
                MessageBox.Show("Connection Failed");
                this.Close();
            }
            var result = await _serverComm.GetAsync(_device.device_url, "hunter3@example.com", "12345678");
            var jsonStr = await result.Item2.Content.ReadAsStringAsync();
            _device = JsonConvert.DeserializeObject<DeviceInfo>(jsonStr);
            Console.WriteLine(_device.buttons.Count);

            //start timer
            _timer = new Timer()
            {
                Interval = 200
            };
            _timer.Tick += UpdateTimer;
            _timer.Start();

            _timer = new Timer()
            {
                Interval = 2000
            };
            _timer.Tick += aliveTimer;
            _timer.Start();
        }

        private void currentHsb_Scroll(object sender, ScrollEventArgs e)
        {
            currentLbl.Text =  "Current: "+currentHsb.Value+"mA";
        }

        private void currentLbl_Click(object sender, EventArgs e)
        {

        }

        private void UpdateTimer(object sender, EventArgs e)
        {
            var old_timeout = _sslStream.ReadTimeout;
            _sslStream.ReadTimeout = 10;
            var buffer = new byte[128];
            try
            {
                int x = _sslStream.Read(buffer, 0, 128);
                ResultObject result = JsonConvert.DeserializeObject<ResultObject>(Encoding.UTF8.GetString(buffer));
                if (result == null)
                    return;
                if (result.ir_button != null)
                {
                    int id = (int)result.ir_button[0];
                    var button = _device.buttons.Find(b => b.id == id);
                    outputTb.Text = button.name;
                }
                else if (result.info != null)
                {
                    statusLbl.Text = "Info: " + result.info;
                }
                else if (result.error != null)
                {
                    statusLbl.Text = "Error: " + result.error;
                }
            }
            catch { }
            finally
            {
                _sslStream.ReadTimeout = old_timeout;
            }
        }
        private void aliveTimer(object sender, EventArgs e)
        {
            _device.SendKeepalive(_sslStream, currentHsb.Value);
        }

        private void feedback1Cb_CheckedChanged(object sender, EventArgs e)
        {
            // send boolean to dan
        }

        private void feedback2Cb_CheckedChanged(object sender, EventArgs e)
        {
            // send boolean to dan
        }

        private void feedbackCb_CheckedChanged(object sender, EventArgs e)
        {
            // send boolean to dan
        }

        private void feedback4Cb_CheckedChanged(object sender, EventArgs e)
        {
            // send boolean to dan
        }
    }
}
