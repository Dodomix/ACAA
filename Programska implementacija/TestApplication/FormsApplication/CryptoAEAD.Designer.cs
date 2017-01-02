namespace FormsApplication
{
    partial class CryptoAEAD
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
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabEncrypt = new System.Windows.Forms.TabPage();
            this.controlEncrypt = new FormsApplication.CryptoControl();
            this.tabDecrypt = new System.Windows.Forms.TabPage();
            this.controlDecrypt = new FormsApplication.CryptoControl();
            this.buttonEncrypt = new System.Windows.Forms.Button();
            this.buttonDecrypt = new System.Windows.Forms.Button();
            this.tabControl.SuspendLayout();
            this.tabEncrypt.SuspendLayout();
            this.tabDecrypt.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.tabEncrypt);
            this.tabControl.Controls.Add(this.tabDecrypt);
            this.tabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl.Location = new System.Drawing.Point(0, 0);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(708, 406);
            this.tabControl.TabIndex = 0;
            // 
            // tabEncrypt
            // 
            this.tabEncrypt.BackColor = System.Drawing.SystemColors.Control;
            this.tabEncrypt.Controls.Add(this.buttonEncrypt);
            this.tabEncrypt.Controls.Add(this.controlEncrypt);
            this.tabEncrypt.Location = new System.Drawing.Point(4, 22);
            this.tabEncrypt.Name = "tabEncrypt";
            this.tabEncrypt.Padding = new System.Windows.Forms.Padding(3);
            this.tabEncrypt.Size = new System.Drawing.Size(700, 380);
            this.tabEncrypt.TabIndex = 0;
            this.tabEncrypt.Text = "Enkripcija";
            // 
            // controlEncrypt
            // 
            this.controlEncrypt.Location = new System.Drawing.Point(0, 0);
            this.controlEncrypt.Name = "controlEncrypt";
            this.controlEncrypt.Size = new System.Drawing.Size(703, 385);
            this.controlEncrypt.TabIndex = 0;
            // 
            // tabDecrypt
            // 
            this.tabDecrypt.BackColor = System.Drawing.SystemColors.Control;
            this.tabDecrypt.Controls.Add(this.buttonDecrypt);
            this.tabDecrypt.Controls.Add(this.controlDecrypt);
            this.tabDecrypt.Location = new System.Drawing.Point(4, 22);
            this.tabDecrypt.Name = "tabDecrypt";
            this.tabDecrypt.Padding = new System.Windows.Forms.Padding(3);
            this.tabDecrypt.Size = new System.Drawing.Size(700, 380);
            this.tabDecrypt.TabIndex = 1;
            this.tabDecrypt.Text = "Dekripcija";
            // 
            // controlDecrypt
            // 
            this.controlDecrypt.Location = new System.Drawing.Point(0, 0);
            this.controlDecrypt.Name = "controlDecrypt";
            this.controlDecrypt.Size = new System.Drawing.Size(703, 385);
            this.controlDecrypt.TabIndex = 1;
            // 
            // buttonEncrypt
            // 
            this.buttonEncrypt.Location = new System.Drawing.Point(557, 323);
            this.buttonEncrypt.Name = "buttonEncrypt";
            this.buttonEncrypt.Size = new System.Drawing.Size(123, 39);
            this.buttonEncrypt.TabIndex = 42;
            this.buttonEncrypt.Text = "Kriptiraj";
            this.buttonEncrypt.UseVisualStyleBackColor = true;
            this.buttonEncrypt.Click += new System.EventHandler(this.buttonEncrypt_Click);
            // 
            // buttonDecrypt
            // 
            this.buttonDecrypt.Location = new System.Drawing.Point(557, 323);
            this.buttonDecrypt.Name = "buttonDecrypt";
            this.buttonDecrypt.Size = new System.Drawing.Size(123, 39);
            this.buttonDecrypt.TabIndex = 42;
            this.buttonDecrypt.Text = "Dekriptiraj";
            this.buttonDecrypt.UseVisualStyleBackColor = true;
            this.buttonDecrypt.Click += new System.EventHandler(this.buttonDecrypt_Click);
            // 
            // CryptoAEAD
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(708, 406);
            this.Controls.Add(this.tabControl);
            this.Name = "CryptoAEAD";
            this.Text = "CryptoAEAD";
            this.Load += new System.EventHandler(this.CryptoAEAD_Load);
            this.tabControl.ResumeLayout(false);
            this.tabEncrypt.ResumeLayout(false);
            this.tabDecrypt.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabEncrypt;
        private System.Windows.Forms.TabPage tabDecrypt;
        private CryptoControl controlEncrypt;
        private CryptoControl controlDecrypt;
        public System.Windows.Forms.Button buttonEncrypt;
        public System.Windows.Forms.Button buttonDecrypt;
    }
}