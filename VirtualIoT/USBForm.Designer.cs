namespace VirtualIoT
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
            this.clientsBtn = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // currentLbl
            // 
            this.currentLbl.AutoSize = true;
            this.currentLbl.Location = new System.Drawing.Point(230, 283);
            this.currentLbl.Name = "currentLbl";
            this.currentLbl.Size = new System.Drawing.Size(72, 13);
            this.currentLbl.TabIndex = 5;
            this.currentLbl.Text = "Current Draw:";
            this.currentLbl.Click += new System.EventHandler(this.currentLbl_Click);
            // 
            // currentHsb
            // 
            this.currentHsb.Location = new System.Drawing.Point(107, 242);
            this.currentHsb.Maximum = 1009;
            this.currentHsb.Name = "currentHsb";
            this.currentHsb.Size = new System.Drawing.Size(328, 17);
            this.currentHsb.TabIndex = 4;
            this.currentHsb.Scroll += new System.Windows.Forms.ScrollEventHandler(this.currentHsb_Scroll);
            // 
            // clientsBtn
            // 
            this.clientsBtn.Location = new System.Drawing.Point(44, 29);
            this.clientsBtn.Name = "clientsBtn";
            this.clientsBtn.Size = new System.Drawing.Size(75, 23);
            this.clientsBtn.TabIndex = 6;
            this.clientsBtn.Text = "Start";
            this.clientsBtn.UseVisualStyleBackColor = true;
            this.clientsBtn.Click += new System.EventHandler(this.clientsBtn_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(88, 139);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(334, 20);
            this.textBox1.TabIndex = 7;
            // 
            // UsbForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(532, 360);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.clientsBtn);
            this.Controls.Add(this.currentLbl);
            this.Controls.Add(this.currentHsb);
            this.Name = "UsbForm";
            this.Text = "USB";
            this.Load += new System.EventHandler(this.USB_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label currentLbl;
        private System.Windows.Forms.HScrollBar currentHsb;
        private System.Windows.Forms.Button clientsBtn;
        private System.Windows.Forms.TextBox textBox1;
    }
}