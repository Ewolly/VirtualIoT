using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VirtualIoT
{
    public partial class MainForm : Form
    {
        private ServerComm _serverComm = ServerComm.Instance;
        private List<DeviceInfo> _devices = new List<DeviceInfo>();
        public MainForm()
        {
            InitializeComponent();
        }


        private async void confirmBtn_ClickAsync(object sender, EventArgs e)
        {
            string info = JsonConvert.SerializeObject(new SetupInfo()
            {
                email = emailTb.Text,
                module_type = deviceCb.SelectedIndex,
                setup_time = (int)(DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1))).TotalSeconds,
                friendly_name = friendlyTb.Text
            });
            var result = await _serverComm.PutAsync(_serverComm.Root + "/device/register", 
                new StringContent(info), "application/json");
            if (result.Item1 != ServerResponse.Connected)
            {
                // should be handled better
                MessageBox.Show("Server disconnected during intialisation.");
                this.Close();
            }
            var jsonStr = await result.Item2.Content.ReadAsStringAsync();
            DeviceInfo deviceObj = JsonConvert.DeserializeObject<DeviceInfo>(jsonStr);
            Console.WriteLine(deviceObj.token);
            deviceObj.module_type = deviceCb.SelectedIndex;
            deviceObj.FriendlyName = friendlyTb.Text;
            _devices.Add(deviceObj);
            RegisteredDevicesCb.Items.Clear();
            foreach (var dev in _devices)
            {
                RegisteredDevicesCb.Items.Add(dev.FriendlyName);
            }
            // add here a list of all registered devices on that list link the recieved object 
            //to the list object so that each item has its correct token etc
            //user can then select from the list and click emulate to load new form.

        }

        private async void MainForm_LoadAsync(object sender, EventArgs e)
        {
            var result = await _serverComm.GetAsync(_serverComm.Root + "/device/types");
            if (result.Item1 != ServerResponse.Connected)
            {
                // should be handled better
                MessageBox.Show("Server disconnected during intialisation.");
                this.Close();
            }
            var jsonStr = await result.Item2.Content.ReadAsStringAsync();
            deviceCb.Items.AddRange(JsonConvert.DeserializeObject<string[]>(jsonStr));
        }

        private void deviceCb_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (emailTb.Text == "" || deviceCb.SelectedIndex <= 0 || friendlyTb.Text == "")
            {
                registerBtn.Enabled = false;
                emailStatusLbl.Text = emailTb.Text == "" ? "Enter an email please" : "";
            }
            else
            {
                registerBtn.Enabled = true;
                emailStatusLbl.Text = "";
            }
        }

        private void emailTb_TextChanged(object sender, EventArgs e)
        {
            if(emailTb.Text == "" || deviceCb.SelectedIndex <= 0 || friendlyTb.Text == "")
            {
                registerBtn.Enabled = false;
                emailStatusLbl.Text = emailTb.Text == "" ? "Enter an email please" : "";
            }
            else
            {
                registerBtn.Enabled = true;
                emailStatusLbl.Text = "";
            }
        }

        private void emailStatusLbl_Click(object sender, EventArgs e)
        {

        }

        private void powerBtn_Click(object sender, EventArgs e)
        {
            var selectedDevice = _devices[RegisteredDevicesCb.SelectedIndex];
            switch (selectedDevice.module_type)
            {
                case 1:
                    new SmartPlugForm(selectedDevice).Show();
                    break;
                case 3:
                    new USBForm(selectedDevice).Show();
                    break;
                case 4:
                    new InfraredForm(selectedDevice).Show();
                    break;
                case 7:
                    new AudioForm(selectedDevice).Show();
                    break;
            }
        }
    }
}
