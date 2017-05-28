using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Security;
using Newtonsoft.Json;

namespace VirtualIoT
{
    public partial class SmartPlugForm : Form
    {
        SslStream _sslStream;
        DeviceInfo _device;
        private Timer _aliveTimer;
        private Timer _timer;

        public SmartPlugForm(DeviceInfo device)
        {
            InitializeComponent();
            _device = device;

        }

        private void SmartPlug_Load(object sender, EventArgs e)
        {
            _sslStream = _device.CreateSocket();
            if (_sslStream == null)
            {
                MessageBox.Show("Connection Failed");
                this.Close();
            }

            // timer for the keep alive
            _aliveTimer = new Timer()
            {
                Interval = 2000
            };
            _aliveTimer.Tick += aliveTimer;
            _aliveTimer.Start();

            _timer = new Timer()
            {
                Interval = 200
            };
            _timer.Tick += UpdateTimer;
            _timer.Start();

            _device.ConvertAndSend(_sslStream, new ResponseObject
            {
                response = "power_state",
            });

        }

        private void aliveTimer(object sender, EventArgs e)
        {
            try
            {
                if (powerCb.Checked == false)
                {
                    currentHsb.Value = 0;
                    currentLbl.Text = "Current: " + currentHsb.Value + "mA";
                }
                _device.SendKeepalive(_sslStream, currentHsb.Value);
            }
            catch
            {
                MessageBox.Show("Connection lost");
                _sslStream.Close();
                _sslStream.Dispose();
                this.Close();
            }
        }

        private void UpdateTimer(object sender, EventArgs e)
        {
            var old_timeout = _sslStream.ReadTimeout;
            _sslStream.ReadTimeout = 10;
            var buffer = new byte[128];
            try
            {
                _sslStream.Read(buffer, 0, 128);
                ResultObject result = JsonConvert.DeserializeObject<ResultObject>(
                    Encoding.UTF8.GetString(buffer));

                if (result == null)
                    return;

                if (result.info != null)
                {
                    statusLbl.Text = "Info: " + result.info;
                }
                else if (result.error != null)
                {
                    statusLbl.Text = "Error: " + result.error;
                }
                else if (result.power != null)
                {
                    powerCb.Checked = result.power.Value;
                }
            }
            catch { }
            finally
            {
                _sslStream.ReadTimeout = old_timeout;
            }
        }

        private void currentHsb_Scroll(object sender, ScrollEventArgs e)
        {
            currentLbl.Text = "Current: " + currentHsb.Value + "mA";

        }

        private void currentLbl_Click(object sender, EventArgs e)
        {

        }
    }
}
