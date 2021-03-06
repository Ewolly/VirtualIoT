﻿using Newtonsoft.Json;
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
            
            //
            // Temp Varibales Below so we dont have to clog up jamies precious database constantly
            //
            var device1 = new DeviceInfo()
            {
                device_id = 99,
                token = "334d54f9-edec-4ff0-b7f6-3f6d4c4bad14",
                FriendlyName = "Lamp -SmartPlug",
                module_type = 1
            };
            var device2 = new DeviceInfo()
            {
                device_id = 100,
                token = "750ffb05-795d-4824-a2de-158381004dc5",
                FriendlyName = "HID -USB",
                module_type = 3
            };
            var device3 = new DeviceInfo()
            {
                device_id = 101,
                token = "0ff742f8-d0a3-4299-a843-eb27f448bfe2",
                FriendlyName = "TV - Infrared",
                device_url = "https://iot.duality.co.nz/api/1/device/101/info",
                module_type = 4
            };
            var device4 = new DeviceInfo()
            {
                device_id = 102,
                token = "0bc52d55-93bd-42ab-ab8f-d54b198a634d",
                FriendlyName = "Comms - Audio",
                module_type = 7
            };
            RegisteredDevicesCb.Items.Add(device1.FriendlyName);
            _devices.Add(device1);
            RegisteredDevicesCb.Items.Add(device2.FriendlyName);
            _devices.Add(device2);
            RegisteredDevicesCb.Items.Add(device3.FriendlyName);
            _devices.Add(device3);
            RegisteredDevicesCb.Items.Add(device4.FriendlyName);
            _devices.Add(device4);
            //
            // Temp Varibales above so we dont have to clog up jamies precious database constantly
            //
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
                    new UsbForm(selectedDevice).Show();
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
