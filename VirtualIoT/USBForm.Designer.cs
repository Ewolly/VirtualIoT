﻿namespace VirtualIoT
{
    partial class UsbForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.currentLbl = new System.Windows.Forms.Label();
            this.currentHsb = new System.Windows.Forms.HScrollBar();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.statusLbl = new System.Windows.Forms.Label();
            this.powerCb = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // currentLbl
            // 
            this.currentLbl.AutoSize = true;
            this.currentLbl.Location = new System.Drawing.Point(221, 324);
            this.currentLbl.Name = "currentLbl";
            this.currentLbl.Size = new System.Drawing.Size(72, 13);
            this.currentLbl.TabIndex = 5;
            this.currentLbl.Text = "Current Draw:";
            this.currentLbl.Click += new System.EventHandler(this.currentLbl_Click);
            // 
            // currentHsb
            // 
            this.currentHsb.Location = new System.Drawing.Point(98, 283);
            this.currentHsb.Maximum = 1009;
            this.currentHsb.Name = "currentHsb";
            this.currentHsb.Size = new System.Drawing.Size(328, 17);
            this.currentHsb.TabIndex = 4;
            this.currentHsb.Scroll += new System.Windows.Forms.ScrollEventHandler(this.currentHsb_Scroll);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(31, 53);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(472, 213);
            this.textBox1.TabIndex = 7;
            // 
            // statusLbl
            // 
            this.statusLbl.AutoSize = true;
            this.statusLbl.Location = new System.Drawing.Point(13, 335);
            this.statusLbl.Name = "statusLbl";
            this.statusLbl.Size = new System.Drawing.Size(40, 13);
            this.statusLbl.TabIndex = 8;
            this.statusLbl.Text = "Status:";
            // 
            // powerCb
            // 
            this.powerCb.AutoCheck = false;
            this.powerCb.AutoSize = true;
            this.powerCb.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.powerCb.Location = new System.Drawing.Point(431, 12);
            this.powerCb.Name = "powerCb";
            this.powerCb.Size = new System.Drawing.Size(72, 24);
            this.powerCb.TabIndex = 9;
            this.powerCb.Text = "Power";
            this.powerCb.UseVisualStyleBackColor = true;
            this.powerCb.CheckedChanged += new System.EventHandler(this.powerCb_CheckedChanged);
            // 
            // UsbForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(532, 360);
            this.Controls.Add(this.powerCb);
            this.Controls.Add(this.statusLbl);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.currentLbl);
            this.Controls.Add(this.currentHsb);
            this.Name = "UsbForm";
            this.Text = "USB";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.UsbForm_FormClosing);
            this.Load += new System.EventHandler(this.USB_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label currentLbl;
        private System.Windows.Forms.HScrollBar currentHsb;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label statusLbl;
        private System.Windows.Forms.CheckBox powerCb;
    }
}