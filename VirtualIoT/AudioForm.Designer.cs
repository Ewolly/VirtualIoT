namespace VirtualIoT
{
    partial class AudioForm
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
            this.receiveChkBox = new System.Windows.Forms.CheckBox();
            this.sendChkBox = new System.Windows.Forms.CheckBox();
            this.currentLbl = new System.Windows.Forms.Label();
            this.currentHsb = new System.Windows.Forms.HScrollBar();
            this.outputTxtBox = new System.Windows.Forms.TextBox();
            this.sendCommandBtn = new System.Windows.Forms.Button();
            this.inputTxtBox = new System.Windows.Forms.TextBox();
            this.statusLbl = new System.Windows.Forms.Label();
            this.willReceiveChkBox = new System.Windows.Forms.CheckBox();
            this.willSendChkBox = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // receiveChkBox
            // 
            this.receiveChkBox.AutoSize = true;
            this.receiveChkBox.Enabled = false;
            this.receiveChkBox.Location = new System.Drawing.Point(80, 93);
            this.receiveChkBox.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.receiveChkBox.Name = "receiveChkBox";
            this.receiveChkBox.Size = new System.Drawing.Size(156, 36);
            this.receiveChkBox.TabIndex = 0;
            this.receiveChkBox.Text = "Receive";
            this.receiveChkBox.UseVisualStyleBackColor = true;
            this.receiveChkBox.CheckedChanged += new System.EventHandler(this.checkboxChangedAsync);
            // 
            // sendChkBox
            // 
            this.sendChkBox.AutoSize = true;
            this.sendChkBox.Enabled = false;
            this.sendChkBox.Location = new System.Drawing.Point(80, 174);
            this.sendChkBox.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.sendChkBox.Name = "sendChkBox";
            this.sendChkBox.Size = new System.Drawing.Size(120, 36);
            this.sendChkBox.TabIndex = 0;
            this.sendChkBox.Text = "Send";
            this.sendChkBox.UseVisualStyleBackColor = true;
            this.sendChkBox.CheckedChanged += new System.EventHandler(this.checkboxChangedAsync);
            // 
            // currentLbl
            // 
            this.currentLbl.AutoSize = true;
            this.currentLbl.Location = new System.Drawing.Point(608, 582);
            this.currentLbl.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.currentLbl.Name = "currentLbl";
            this.currentLbl.Size = new System.Drawing.Size(189, 32);
            this.currentLbl.TabIndex = 5;
            this.currentLbl.Text = "Current Draw:";
            // 
            // currentHsb
            // 
            this.currentHsb.Location = new System.Drawing.Point(275, 496);
            this.currentHsb.Maximum = 1009;
            this.currentHsb.Name = "currentHsb";
            this.currentHsb.Size = new System.Drawing.Size(875, 17);
            this.currentHsb.TabIndex = 4;
            this.currentHsb.Scroll += new System.Windows.Forms.ScrollEventHandler(this.currentHsb_Scroll);
            // 
            // outputTxtBox
            // 
            this.outputTxtBox.Location = new System.Drawing.Point(35, 708);
            this.outputTxtBox.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.outputTxtBox.Multiline = true;
            this.outputTxtBox.Name = "outputTxtBox";
            this.outputTxtBox.ReadOnly = true;
            this.outputTxtBox.Size = new System.Drawing.Size(1359, 204);
            this.outputTxtBox.TabIndex = 6;
            // 
            // sendCommandBtn
            // 
            this.sendCommandBtn.Location = new System.Drawing.Point(1200, 641);
            this.sendCommandBtn.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.sendCommandBtn.Name = "sendCommandBtn";
            this.sendCommandBtn.Size = new System.Drawing.Size(200, 55);
            this.sendCommandBtn.TabIndex = 7;
            this.sendCommandBtn.Text = "Send";
            this.sendCommandBtn.UseVisualStyleBackColor = true;
            this.sendCommandBtn.Click += new System.EventHandler(this.sendCommandBtn_Click);
            // 
            // inputTxtBox
            // 
            this.inputTxtBox.Location = new System.Drawing.Point(35, 646);
            this.inputTxtBox.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.inputTxtBox.Name = "inputTxtBox";
            this.inputTxtBox.Size = new System.Drawing.Size(1140, 38);
            this.inputTxtBox.TabIndex = 8;
            // 
            // statusLbl
            // 
            this.statusLbl.AutoSize = true;
            this.statusLbl.Location = new System.Drawing.Point(35, 601);
            this.statusLbl.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.statusLbl.Name = "statusLbl";
            this.statusLbl.Size = new System.Drawing.Size(104, 32);
            this.statusLbl.TabIndex = 9;
            this.statusLbl.Text = "Status:";
            // 
            // willReceiveChkBox
            // 
            this.willReceiveChkBox.AutoSize = true;
            this.willReceiveChkBox.Enabled = false;
            this.willReceiveChkBox.Location = new System.Drawing.Point(778, 174);
            this.willReceiveChkBox.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.willReceiveChkBox.Name = "willReceiveChkBox";
            this.willReceiveChkBox.Size = new System.Drawing.Size(210, 36);
            this.willReceiveChkBox.TabIndex = 0;
            this.willReceiveChkBox.Text = "Will Receive";
            this.willReceiveChkBox.UseVisualStyleBackColor = true;
            this.willReceiveChkBox.CheckedChanged += new System.EventHandler(this.checkboxChangedAsync);
            // 
            // willSendChkBox
            // 
            this.willSendChkBox.AutoCheck = false;
            this.willSendChkBox.AutoSize = true;
            this.willSendChkBox.Enabled = false;
            this.willSendChkBox.Location = new System.Drawing.Point(778, 93);
            this.willSendChkBox.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.willSendChkBox.Name = "willSendChkBox";
            this.willSendChkBox.Size = new System.Drawing.Size(174, 36);
            this.willSendChkBox.TabIndex = 0;
            this.willSendChkBox.Text = "Will Send";
            this.willSendChkBox.UseVisualStyleBackColor = true;
            this.willSendChkBox.CheckedChanged += new System.EventHandler(this.checkboxChangedAsync);
            // 
            // AudioForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(16F, 31F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1432, 947);
            this.Controls.Add(this.statusLbl);
            this.Controls.Add(this.inputTxtBox);
            this.Controls.Add(this.sendCommandBtn);
            this.Controls.Add(this.outputTxtBox);
            this.Controls.Add(this.currentLbl);
            this.Controls.Add(this.currentHsb);
            this.Controls.Add(this.willSendChkBox);
            this.Controls.Add(this.willReceiveChkBox);
            this.Controls.Add(this.sendChkBox);
            this.Controls.Add(this.receiveChkBox);
            this.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.Name = "AudioForm";
            this.Text = "AudioEmulate";
            this.Load += new System.EventHandler(this.AudioEmulate_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox receiveChkBox;
        private System.Windows.Forms.CheckBox sendChkBox;
        private System.Windows.Forms.Label currentLbl;
        private System.Windows.Forms.HScrollBar currentHsb;
        private System.Windows.Forms.TextBox outputTxtBox;
        private System.Windows.Forms.Button sendCommandBtn;
        private System.Windows.Forms.TextBox inputTxtBox;
        private System.Windows.Forms.Label statusLbl;
        private System.Windows.Forms.CheckBox willReceiveChkBox;
        private System.Windows.Forms.CheckBox willSendChkBox;
    }
}