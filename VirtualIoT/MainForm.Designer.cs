namespace VirtualIoT
{
    partial class MainForm
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
            this.registerBtn = new System.Windows.Forms.Button();
            this.deviceCb = new System.Windows.Forms.ComboBox();
            this.emailTb = new System.Windows.Forms.TextBox();
            this.emailStatusLbl = new System.Windows.Forms.Label();
            this.RegisteredDevicesCb = new System.Windows.Forms.ComboBox();
            this.powerBtn = new System.Windows.Forms.Button();
            this.friendlyTb = new System.Windows.Forms.TextBox();
            this.friendlyStatLbl = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // registerBtn
            // 
            this.registerBtn.Enabled = false;
            this.registerBtn.Location = new System.Drawing.Point(193, 78);
            this.registerBtn.Name = "registerBtn";
            this.registerBtn.Size = new System.Drawing.Size(75, 23);
            this.registerBtn.TabIndex = 0;
            this.registerBtn.Text = "Register";
            this.registerBtn.UseVisualStyleBackColor = true;
            this.registerBtn.Click += new System.EventHandler(this.confirmBtn_ClickAsync);
            // 
            // deviceCb
            // 
            this.deviceCb.FormattingEnabled = true;
            this.deviceCb.Location = new System.Drawing.Point(22, 34);
            this.deviceCb.Name = "deviceCb";
            this.deviceCb.Size = new System.Drawing.Size(121, 21);
            this.deviceCb.TabIndex = 2;
            this.deviceCb.SelectedIndexChanged += new System.EventHandler(this.deviceCb_SelectedIndexChanged);
            // 
            // emailTb
            // 
            this.emailTb.Location = new System.Drawing.Point(22, 78);
            this.emailTb.Name = "emailTb";
            this.emailTb.Size = new System.Drawing.Size(121, 20);
            this.emailTb.TabIndex = 3;
            this.emailTb.Text = "hunter2@example.com";
            this.emailTb.TextChanged += new System.EventHandler(this.emailTb_TextChanged);
            // 
            // emailStatusLbl
            // 
            this.emailStatusLbl.AutoSize = true;
            this.emailStatusLbl.Location = new System.Drawing.Point(19, 62);
            this.emailStatusLbl.Name = "emailStatusLbl";
            this.emailStatusLbl.Size = new System.Drawing.Size(32, 13);
            this.emailStatusLbl.TabIndex = 4;
            this.emailStatusLbl.Text = "Email";
            this.emailStatusLbl.Click += new System.EventHandler(this.emailStatusLbl_Click);
            // 
            // RegisteredDevicesCb
            // 
            this.RegisteredDevicesCb.FormattingEnabled = true;
            this.RegisteredDevicesCb.Location = new System.Drawing.Point(22, 219);
            this.RegisteredDevicesCb.Name = "RegisteredDevicesCb";
            this.RegisteredDevicesCb.Size = new System.Drawing.Size(121, 21);
            this.RegisteredDevicesCb.TabIndex = 5;
            // 
            // powerBtn
            // 
            this.powerBtn.Location = new System.Drawing.Point(193, 217);
            this.powerBtn.Name = "powerBtn";
            this.powerBtn.Size = new System.Drawing.Size(75, 23);
            this.powerBtn.TabIndex = 6;
            this.powerBtn.Text = "Power On";
            this.powerBtn.UseVisualStyleBackColor = true;
            this.powerBtn.Click += new System.EventHandler(this.powerBtn_Click);
            // 
            // friendlyTb
            // 
            this.friendlyTb.Location = new System.Drawing.Point(22, 117);
            this.friendlyTb.Name = "friendlyTb";
            this.friendlyTb.Size = new System.Drawing.Size(121, 20);
            this.friendlyTb.TabIndex = 3;
            this.friendlyTb.TextChanged += new System.EventHandler(this.emailTb_TextChanged);
            // 
            // friendlyStatLbl
            // 
            this.friendlyStatLbl.AutoSize = true;
            this.friendlyStatLbl.Location = new System.Drawing.Point(19, 101);
            this.friendlyStatLbl.Name = "friendlyStatLbl";
            this.friendlyStatLbl.Size = new System.Drawing.Size(74, 13);
            this.friendlyStatLbl.TabIndex = 4;
            this.friendlyStatLbl.Text = "Friendly Name";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(574, 375);
            this.Controls.Add(this.powerBtn);
            this.Controls.Add(this.RegisteredDevicesCb);
            this.Controls.Add(this.friendlyStatLbl);
            this.Controls.Add(this.emailStatusLbl);
            this.Controls.Add(this.friendlyTb);
            this.Controls.Add(this.emailTb);
            this.Controls.Add(this.deviceCb);
            this.Controls.Add(this.registerBtn);
            this.Name = "MainForm";
            this.Text = "MainForm";
            this.Load += new System.EventHandler(this.MainForm_LoadAsync);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button registerBtn;
        private System.Windows.Forms.ComboBox deviceCb;
        private System.Windows.Forms.TextBox emailTb;
        private System.Windows.Forms.Label emailStatusLbl;
        private System.Windows.Forms.ComboBox RegisteredDevicesCb;
        private System.Windows.Forms.Button powerBtn;
        private System.Windows.Forms.TextBox friendlyTb;
        private System.Windows.Forms.Label friendlyStatLbl;
    }
}

