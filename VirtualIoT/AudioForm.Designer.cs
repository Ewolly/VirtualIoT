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
            this.powerCb = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // receiveChkBox
            // 
            this.receiveChkBox.AutoSize = true;
            this.receiveChkBox.Enabled = false;
            this.receiveChkBox.Location = new System.Drawing.Point(26, 83);
            this.receiveChkBox.Name = "receiveChkBox";
            this.receiveChkBox.Size = new System.Drawing.Size(66, 17);
            this.receiveChkBox.TabIndex = 0;
            this.receiveChkBox.Text = "Receive";
            this.receiveChkBox.UseVisualStyleBackColor = true;
            this.receiveChkBox.CheckedChanged += new System.EventHandler(this.checkboxChangedAsync);
            // 
            // sendChkBox
            // 
            this.sendChkBox.AutoSize = true;
            this.sendChkBox.Enabled = false;
            this.sendChkBox.Location = new System.Drawing.Point(26, 117);
            this.sendChkBox.Name = "sendChkBox";
            this.sendChkBox.Size = new System.Drawing.Size(51, 17);
            this.sendChkBox.TabIndex = 0;
            this.sendChkBox.Text = "Send";
            this.sendChkBox.UseVisualStyleBackColor = true;
            this.sendChkBox.CheckedChanged += new System.EventHandler(this.checkboxChangedAsync);
            // 
            // currentLbl
            // 
            this.currentLbl.AutoSize = true;
            this.currentLbl.Location = new System.Drawing.Point(228, 244);
            this.currentLbl.Name = "currentLbl";
            this.currentLbl.Size = new System.Drawing.Size(72, 13);
            this.currentLbl.TabIndex = 5;
            this.currentLbl.Text = "Current Draw:";
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
            // willReceiveChkBox
            // 
            this.willReceiveChkBox.AutoSize = true;
            this.willReceiveChkBox.Enabled = false;
            this.willReceiveChkBox.Location = new System.Drawing.Point(288, 117);
            this.willReceiveChkBox.Name = "willReceiveChkBox";
            this.willReceiveChkBox.Size = new System.Drawing.Size(86, 17);
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
            this.willSendChkBox.Location = new System.Drawing.Point(288, 83);
            this.willSendChkBox.Name = "willSendChkBox";
            this.willSendChkBox.Size = new System.Drawing.Size(71, 17);
            this.willSendChkBox.TabIndex = 0;
            this.willSendChkBox.Text = "Will Send";
            this.willSendChkBox.UseVisualStyleBackColor = true;
            this.willSendChkBox.CheckedChanged += new System.EventHandler(this.checkboxChangedAsync);
            // 
            // powerCb
            // 
            this.powerCb.AutoCheck = false;
            this.powerCb.AutoSize = true;
            this.powerCb.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.powerCb.Location = new System.Drawing.Point(450, 22);
            this.powerCb.Name = "powerCb";
            this.powerCb.Size = new System.Drawing.Size(72, 24);
            this.powerCb.TabIndex = 10;
            this.powerCb.Text = "Power";
            this.powerCb.UseVisualStyleBackColor = true;
            // 
            // AudioForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(537, 397);
            this.Controls.Add(this.powerCb);
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
        private System.Windows.Forms.CheckBox powerCb;
    }
}