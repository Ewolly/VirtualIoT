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
            this.micCb.Location = new System.Drawing.Point(30, 39);
            this.micCb.Name = "micCb";
            this.micCb.Size = new System.Drawing.Size(82, 17);
            this.micCb.TabIndex = 0;
            this.micCb.Text = "Microphone";
            this.micCb.UseVisualStyleBackColor = true;
            this.micCb.CheckedChanged += new System.EventHandler(this.micCb_CheckedChanged);
            // 
            // speakerCb
            // 
            this.speakerCb.AutoSize = true;
            this.speakerCb.Location = new System.Drawing.Point(30, 73);
            this.speakerCb.Name = "speakerCb";
            this.speakerCb.Size = new System.Drawing.Size(66, 17);
            this.speakerCb.TabIndex = 0;
            this.speakerCb.Text = "Speaker";
            this.speakerCb.UseVisualStyleBackColor = true;
            this.speakerCb.CheckedChanged += new System.EventHandler(this.speakerCb_CheckedChanged);
            // 
            // currentLbl
            // 
            this.currentLbl.AutoSize = true;
            this.currentLbl.Location = new System.Drawing.Point(228, 244);
            this.currentLbl.Name = "currentLbl";
            this.currentLbl.Size = new System.Drawing.Size(72, 13);
            this.currentLbl.TabIndex = 5;
            this.currentLbl.Text = "Current Draw:";
            this.currentLbl.Click += new System.EventHandler(this.currentLbl_Click);
            // 
            // currentHsb
            // 
            this.currentHsb.Location = new System.Drawing.Point(103, 208);
            this.currentHsb.Maximum = 1009;
            this.currentHsb.Name = "currentHsb";
            this.currentHsb.Size = new System.Drawing.Size(328, 17);
            this.currentHsb.TabIndex = 4;
            this.currentHsb.Scroll += new System.Windows.Forms.ScrollEventHandler(this.currentHsb_Scroll);
            // 
            // outputTxtBox
            // 
            this.outputTxtBox.Location = new System.Drawing.Point(13, 297);
            this.outputTxtBox.Multiline = true;
            this.outputTxtBox.Name = "outputTxtBox";
            this.outputTxtBox.ReadOnly = true;
            this.outputTxtBox.Size = new System.Drawing.Size(512, 88);
            this.outputTxtBox.TabIndex = 6;
            // 
            // sendCommandBtn
            // 
            this.sendCommandBtn.Location = new System.Drawing.Point(450, 269);
            this.sendCommandBtn.Name = "sendCommandBtn";
            this.sendCommandBtn.Size = new System.Drawing.Size(75, 23);
            this.sendCommandBtn.TabIndex = 7;
            this.sendCommandBtn.Text = "Send";
            this.sendCommandBtn.UseVisualStyleBackColor = true;
            this.sendCommandBtn.Click += new System.EventHandler(this.sendCommandBtn_Click);
            // 
            // inputTxtBox
            // 
            this.inputTxtBox.Location = new System.Drawing.Point(13, 271);
            this.inputTxtBox.Name = "inputTxtBox";
            this.inputTxtBox.Size = new System.Drawing.Size(430, 20);
            this.inputTxtBox.TabIndex = 8;
            // 
            // statusLbl
            // 
            this.statusLbl.AutoSize = true;
            this.statusLbl.Location = new System.Drawing.Point(13, 252);
            this.statusLbl.Name = "statusLbl";
            this.statusLbl.Size = new System.Drawing.Size(40, 13);
            this.statusLbl.TabIndex = 9;
            this.statusLbl.Text = "Status:";
            // 
            // MicConCb
            // 
            this.MicConCb.AutoSize = true;
            this.MicConCb.Location = new System.Drawing.Point(293, 39);
            this.MicConCb.Name = "MicConCb";
            this.MicConCb.Size = new System.Drawing.Size(137, 17);
            this.MicConCb.TabIndex = 0;
            this.MicConCb.Text = "Microphone Connected";
            this.MicConCb.UseVisualStyleBackColor = true;
            // 
            // SpeakConCb
            // 
            this.SpeakConCb.AutoCheck = false;
            this.SpeakConCb.AutoSize = true;
            this.SpeakConCb.Location = new System.Drawing.Point(293, 73);
            this.SpeakConCb.Name = "SpeakConCb";
            this.SpeakConCb.Size = new System.Drawing.Size(121, 17);
            this.SpeakConCb.TabIndex = 0;
            this.SpeakConCb.Text = "Speaker Connected";
            this.SpeakConCb.UseVisualStyleBackColor = true;
            // 
            // AudioForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(537, 397);
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