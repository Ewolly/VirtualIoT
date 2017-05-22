namespace VirtualIoT
{
    partial class SmartPlugForm
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
            this.powerCb = new System.Windows.Forms.CheckBox();
            this.currentLbl = new System.Windows.Forms.Label();
            this.currentHsb = new System.Windows.Forms.HScrollBar();
            this.outputTb = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // powerCb
            // 
            this.powerCb.AutoCheck = false;
            this.powerCb.BackColor = System.Drawing.SystemColors.Highlight;
            this.powerCb.Cursor = System.Windows.Forms.Cursors.No;
            this.powerCb.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.powerCb.Location = new System.Drawing.Point(153, 114);
            this.powerCb.Name = "powerCb";
            this.powerCb.Size = new System.Drawing.Size(109, 41);
            this.powerCb.TabIndex = 0;
            this.powerCb.Text = "Power";
            this.powerCb.UseVisualStyleBackColor = false;
            // 
            // currentLbl
            // 
            this.currentLbl.AutoSize = true;
            this.currentLbl.Location = new System.Drawing.Point(185, 230);
            this.currentLbl.Name = "currentLbl";
            this.currentLbl.Size = new System.Drawing.Size(72, 13);
            this.currentLbl.TabIndex = 5;
            this.currentLbl.Text = "Current Draw:";
            this.currentLbl.Click += new System.EventHandler(this.currentLbl_Click);
            // 
            // currentHsb
            // 
            this.currentHsb.Location = new System.Drawing.Point(62, 189);
            this.currentHsb.Maximum = 1009;
            this.currentHsb.Name = "currentHsb";
            this.currentHsb.Size = new System.Drawing.Size(328, 17);
            this.currentHsb.TabIndex = 4;
            this.currentHsb.Scroll += new System.Windows.Forms.ScrollEventHandler(this.currentHsb_Scroll);
            // 
            // outputTb
            // 
            this.outputTb.AutoSize = true;
            this.outputTb.Location = new System.Drawing.Point(13, 287);
            this.outputTb.Name = "outputTb";
            this.outputTb.Size = new System.Drawing.Size(39, 13);
            this.outputTb.TabIndex = 6;
            this.outputTb.Text = "Output";
            // 
            // SmartPlugForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(452, 312);
            this.Controls.Add(this.outputTb);
            this.Controls.Add(this.currentLbl);
            this.Controls.Add(this.currentHsb);
            this.Controls.Add(this.powerCb);
            this.Name = "SmartPlugForm";
            this.Text = "SmartPlug";
            this.Load += new System.EventHandler(this.SmartPlug_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox powerCb;
        private System.Windows.Forms.Label currentLbl;
        private System.Windows.Forms.HScrollBar currentHsb;
        private System.Windows.Forms.Label outputTb;
    }
}