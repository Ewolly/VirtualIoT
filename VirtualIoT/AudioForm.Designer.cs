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
            this.micCb = new System.Windows.Forms.CheckBox();
            this.speakerCb = new System.Windows.Forms.CheckBox();
            this.currentLbl = new System.Windows.Forms.Label();
            this.currentHsb = new System.Windows.Forms.HScrollBar();
            this.outputTxtBox = new System.Windows.Forms.TextBox();
            this.sendCommandBtn = new System.Windows.Forms.Button();
            this.inputTxtBox = new System.Windows.Forms.TextBox();
            this.statusLbl = new System.Windows.Forms.Label();
            this.MicConCb = new System.Windows.Forms.CheckBox();
            this.SpeakConCb = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // micCb
            // 
            this.micCb.AutoSize = true;
            this.micCb.Location = new System.Drawing.Point(80, 93);
            this.micCb.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.micCb.Name = "micCb";
            this.micCb.Size = new System.Drawing.Size(202, 36);
            this.micCb.TabIndex = 0;
            this.micCb.Text = "Microphone";
            this.micCb.UseVisualStyleBackColor = true;
            this.micCb.CheckedChanged += new System.EventHandler(this.micCb_CheckedChanged);
            // 
            // speakerCb
            // 
            this.speakerCb.AutoSize = true;
            this.speakerCb.Location = new System.Drawing.Point(80, 174);
            this.speakerCb.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.speakerCb.Name = "speakerCb";
            this.speakerCb.Size = new System.Drawing.Size(159, 36);
            this.speakerCb.TabIndex = 0;
            this.speakerCb.Text = "Speaker";
            this.speakerCb.UseVisualStyleBackColor = true;
            this.speakerCb.CheckedChanged += new System.EventHandler(this.speakerCb_CheckedChanged);
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
            this.currentLbl.Click += new System.EventHandler(this.currentLbl_Click);
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
            // MicConCb
            // 
            this.MicConCb.AutoSize = true;
            this.MicConCb.Location = new System.Drawing.Point(781, 93);
            this.MicConCb.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.MicConCb.Name = "MicConCb";
            this.MicConCb.Size = new System.Drawing.Size(347, 36);
            this.MicConCb.TabIndex = 0;
            this.MicConCb.Text = "Microphone Connected";
            this.MicConCb.UseVisualStyleBackColor = true;
            // 
            // SpeakConCb
            // 
            this.SpeakConCb.AutoCheck = false;
            this.SpeakConCb.AutoSize = true;
            this.SpeakConCb.Location = new System.Drawing.Point(781, 174);
            this.SpeakConCb.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.SpeakConCb.Name = "SpeakConCb";
            this.SpeakConCb.Size = new System.Drawing.Size(304, 36);
            this.SpeakConCb.TabIndex = 0;
            this.SpeakConCb.Text = "Speaker Connected";
            this.SpeakConCb.UseVisualStyleBackColor = true;
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
            this.Controls.Add(this.SpeakConCb);
            this.Controls.Add(this.MicConCb);
            this.Controls.Add(this.speakerCb);
            this.Controls.Add(this.micCb);
            this.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.Name = "AudioForm";
            this.Text = "AudioEmulate";
            this.Load += new System.EventHandler(this.AudioEmulate_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox micCb;
        private System.Windows.Forms.CheckBox speakerCb;
        private System.Windows.Forms.Label currentLbl;
        private System.Windows.Forms.HScrollBar currentHsb;
        private System.Windows.Forms.TextBox outputTxtBox;
        private System.Windows.Forms.Button sendCommandBtn;
        private System.Windows.Forms.TextBox inputTxtBox;
        private System.Windows.Forms.Label statusLbl;
        private System.Windows.Forms.CheckBox MicConCb;
        private System.Windows.Forms.CheckBox SpeakConCb;
    }
}