namespace VirtualIoT
{
    partial class InfraredForm
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
            this.outputTb = new System.Windows.Forms.TextBox();
            this.feedback1Cb = new System.Windows.Forms.CheckBox();
            this.feedback2Cb = new System.Windows.Forms.CheckBox();
            this.feedbackCb = new System.Windows.Forms.CheckBox();
            this.feedback4Cb = new System.Windows.Forms.CheckBox();
            this.currentHsb = new System.Windows.Forms.HScrollBar();
            this.currentLbl = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // outputTb
            // 
            this.outputTb.Location = new System.Drawing.Point(52, 53);
            this.outputTb.Name = "outputTb";
            this.outputTb.ReadOnly = true;
            this.outputTb.Size = new System.Drawing.Size(379, 20);
            this.outputTb.TabIndex = 0;
            this.outputTb.Text = "Infrared can suck a massive cock";
            // 
            // feedback1Cb
            // 
            this.feedback1Cb.Appearance = System.Windows.Forms.Appearance.Button;
            this.feedback1Cb.Location = new System.Drawing.Point(52, 79);
            this.feedback1Cb.Name = "feedback1Cb";
            this.feedback1Cb.Size = new System.Drawing.Size(91, 24);
            this.feedback1Cb.TabIndex = 1;
            this.feedback1Cb.Text = "1";
            this.feedback1Cb.UseVisualStyleBackColor = true;
            // 
            // feedback2Cb
            // 
            this.feedback2Cb.Appearance = System.Windows.Forms.Appearance.Button;
            this.feedback2Cb.Location = new System.Drawing.Point(149, 79);
            this.feedback2Cb.Name = "feedback2Cb";
            this.feedback2Cb.Size = new System.Drawing.Size(93, 24);
            this.feedback2Cb.TabIndex = 1;
            this.feedback2Cb.Text = "2";
            this.feedback2Cb.UseVisualStyleBackColor = true;
            // 
            // feedbackCb
            // 
            this.feedbackCb.Appearance = System.Windows.Forms.Appearance.Button;
            this.feedbackCb.Location = new System.Drawing.Point(248, 79);
            this.feedbackCb.Name = "feedbackCb";
            this.feedbackCb.Size = new System.Drawing.Size(92, 24);
            this.feedbackCb.TabIndex = 1;
            this.feedbackCb.Text = "3";
            this.feedbackCb.UseVisualStyleBackColor = true;
            // 
            // feedback4Cb
            // 
            this.feedback4Cb.Appearance = System.Windows.Forms.Appearance.Button;
            this.feedback4Cb.Location = new System.Drawing.Point(346, 79);
            this.feedback4Cb.Name = "feedback4Cb";
            this.feedback4Cb.Size = new System.Drawing.Size(85, 24);
            this.feedback4Cb.TabIndex = 1;
            this.feedback4Cb.Text = "4";
            this.feedback4Cb.UseVisualStyleBackColor = true;
            // 
            // currentHsb
            // 
            this.currentHsb.Location = new System.Drawing.Point(83, 194);
            this.currentHsb.Maximum = 1009;
            this.currentHsb.Name = "currentHsb";
            this.currentHsb.Size = new System.Drawing.Size(328, 17);
            this.currentHsb.TabIndex = 2;
            this.currentHsb.Scroll += new System.Windows.Forms.ScrollEventHandler(this.currentHsb_Scroll);
            // 
            // currentLbl
            // 
            this.currentLbl.AutoSize = true;
            this.currentLbl.Location = new System.Drawing.Point(206, 235);
            this.currentLbl.Name = "currentLbl";
            this.currentLbl.Size = new System.Drawing.Size(72, 13);
            this.currentLbl.TabIndex = 3;
            this.currentLbl.Text = "Current Draw:";
            this.currentLbl.Click += new System.EventHandler(this.currentLbl_Click);
            // 
            // InfraredForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(489, 304);
            this.Controls.Add(this.currentLbl);
            this.Controls.Add(this.currentHsb);
            this.Controls.Add(this.feedback4Cb);
            this.Controls.Add(this.feedbackCb);
            this.Controls.Add(this.feedback2Cb);
            this.Controls.Add(this.feedback1Cb);
            this.Controls.Add(this.outputTb);
            this.Name = "InfraredForm";
            this.Text = "Infrared";
            this.TransparencyKey = System.Drawing.Color.Fuchsia;
            this.Load += new System.EventHandler(this.Infrared_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox outputTb;
        private System.Windows.Forms.CheckBox feedback1Cb;
        private System.Windows.Forms.CheckBox feedback2Cb;
        private System.Windows.Forms.CheckBox feedbackCb;
        private System.Windows.Forms.CheckBox feedback4Cb;
        private System.Windows.Forms.HScrollBar currentHsb;
        private System.Windows.Forms.Label currentLbl;
    }
}