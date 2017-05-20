namespace VirtualIoT
{
    partial class AudioEmulate
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
            this.startBtn = new System.Windows.Forms.Button();
            this.stopBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // micCb
            // 
            this.micCb.AutoSize = true;
            this.micCb.Location = new System.Drawing.Point(46, 65);
            this.micCb.Name = "micCb";
            this.micCb.Size = new System.Drawing.Size(82, 17);
            this.micCb.TabIndex = 0;
            this.micCb.Text = "Microphone";
            this.micCb.UseVisualStyleBackColor = true;
            // 
            // speakerCb
            // 
            this.speakerCb.AutoSize = true;
            this.speakerCb.Location = new System.Drawing.Point(293, 65);
            this.speakerCb.Name = "speakerCb";
            this.speakerCb.Size = new System.Drawing.Size(66, 17);
            this.speakerCb.TabIndex = 0;
            this.speakerCb.Text = "Speaker";
            this.speakerCb.UseVisualStyleBackColor = true;
            // 
            // startBtn
            // 
            this.startBtn.Location = new System.Drawing.Point(46, 97);
            this.startBtn.Name = "startBtn";
            this.startBtn.Size = new System.Drawing.Size(75, 23);
            this.startBtn.TabIndex = 1;
            this.startBtn.Text = "Start";
            this.startBtn.UseVisualStyleBackColor = true;
            this.startBtn.Click += new System.EventHandler(this.startBtn_Click);
            // 
            // stopBtn
            // 
            this.stopBtn.Location = new System.Drawing.Point(46, 144);
            this.stopBtn.Name = "stopBtn";
            this.stopBtn.Size = new System.Drawing.Size(75, 23);
            this.stopBtn.TabIndex = 2;
            this.stopBtn.Text = "Stop";
            this.stopBtn.UseVisualStyleBackColor = true;
            this.stopBtn.Click += new System.EventHandler(this.stopBtn_Click);
            // 
            // AudioEmulate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(537, 397);
            this.Controls.Add(this.stopBtn);
            this.Controls.Add(this.startBtn);
            this.Controls.Add(this.speakerCb);
            this.Controls.Add(this.micCb);
            this.Name = "AudioEmulate";
            this.Text = "AudioEmulate";
            this.Load += new System.EventHandler(this.AudioEmulate_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox micCb;
        private System.Windows.Forms.CheckBox speakerCb;
        private System.Windows.Forms.Button startBtn;
        private System.Windows.Forms.Button stopBtn;
    }
}