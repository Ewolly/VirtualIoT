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
                setup_time = (int)(DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1))).TotalSeconds
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
            if (emailTb.Text == "" || deviceCb.SelectedIndex <= 0)
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
            if(emailTb.Text == "" || deviceCb.SelectedIndex <= 0)
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
    }
}
