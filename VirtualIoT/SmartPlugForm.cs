﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VirtualIoT
{
    public partial class SmartPlugForm : Form
    {
        public SmartPlugForm(DeviceInfo device)
        {
            InitializeComponent();
        }

        private void SmartPlug_Load(object sender, EventArgs e)
        {

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
