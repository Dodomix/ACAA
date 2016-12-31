namespace FormsApplication
{
    partial class CryptoControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.textBoxTag = new System.Windows.Forms.TextBox();
            this.labelTag2 = new System.Windows.Forms.Label();
            this.textBoxOutput = new System.Windows.Forms.TextBox();
            this.labelOutput = new System.Windows.Forms.Label();
            this.buttonSelectFile = new System.Windows.Forms.Button();
            this.textBoxInput = new System.Windows.Forms.TextBox();
            this.labelInput = new System.Windows.Forms.Label();
            this.labelKeyLength = new System.Windows.Forms.Label();
            this.labelInputFile = new System.Windows.Forms.Label();
            this.algorithmList = new System.Windows.Forms.ListBox();
            this.labelAlg = new System.Windows.Forms.Label();
            this.comboBoxKeyLen = new System.Windows.Forms.ComboBox();
            this.labelOutputFile = new System.Windows.Forms.Label();
            this.textBoxKey = new System.Windows.Forms.TextBox();
            this.labelKeyFile = new System.Windows.Forms.Label();
            this.buttonGenerateKey = new System.Windows.Forms.Button();
            this.labelTaglen = new System.Windows.Forms.Label();
            this.labelNoncelen = new System.Windows.Forms.Label();
            this.labelKeylen = new System.Windows.Forms.Label();
            this.labelTag = new System.Windows.Forms.Label();
            this.labelNonce = new System.Windows.Forms.Label();
            this.labelKey = new System.Windows.Forms.Label();
            this.labelAlgInfo = new System.Windows.Forms.Label();
            this.labelKey2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // textBoxTag
            // 
            this.textBoxTag.Location = new System.Drawing.Point(440, 340);
            this.textBoxTag.Name = "textBoxTag";
            this.textBoxTag.Size = new System.Drawing.Size(100, 20);
            this.textBoxTag.TabIndex = 42;
            // 
            // labelTag2
            // 
            this.labelTag2.AutoSize = true;
            this.labelTag2.Location = new System.Drawing.Point(437, 324);
            this.labelTag2.Name = "labelTag2";
            this.labelTag2.Size = new System.Drawing.Size(59, 13);
            this.labelTag2.TabIndex = 40;
            this.labelTag2.Text = "Sažetak T:";
            // 
            // textBoxOutput
            // 
            this.textBoxOutput.Location = new System.Drawing.Point(440, 24);
            this.textBoxOutput.MaxLength = 600;
            this.textBoxOutput.Multiline = true;
            this.textBoxOutput.Name = "textBoxOutput";
            this.textBoxOutput.Size = new System.Drawing.Size(240, 291);
            this.textBoxOutput.TabIndex = 39;
            // 
            // labelOutput
            // 
            this.labelOutput.AutoSize = true;
            this.labelOutput.Location = new System.Drawing.Point(437, 8);
            this.labelOutput.Name = "labelOutput";
            this.labelOutput.Size = new System.Drawing.Size(85, 13);
            this.labelOutput.TabIndex = 38;
            this.labelOutput.Text = "Izlazna datoteka";
            // 
            // buttonSelectFile
            // 
            this.buttonSelectFile.Location = new System.Drawing.Point(13, 178);
            this.buttonSelectFile.Name = "buttonSelectFile";
            this.buttonSelectFile.Size = new System.Drawing.Size(120, 23);
            this.buttonSelectFile.TabIndex = 36;
            this.buttonSelectFile.Text = "Odaberi datoteku";
            this.buttonSelectFile.UseVisualStyleBackColor = true;
            this.buttonSelectFile.Click += new System.EventHandler(this.selectButton_Click);
            // 
            // textBoxInput
            // 
            this.textBoxInput.Location = new System.Drawing.Point(162, 24);
            this.textBoxInput.MaxLength = 600;
            this.textBoxInput.Multiline = true;
            this.textBoxInput.Name = "textBoxInput";
            this.textBoxInput.Size = new System.Drawing.Size(240, 291);
            this.textBoxInput.TabIndex = 35;
            // 
            // labelInput
            // 
            this.labelInput.AutoSize = true;
            this.labelInput.Location = new System.Drawing.Point(159, 8);
            this.labelInput.Name = "labelInput";
            this.labelInput.Size = new System.Drawing.Size(85, 13);
            this.labelInput.TabIndex = 34;
            this.labelInput.Text = "Ulazna datoteka";
            // 
            // labelKeyLength
            // 
            this.labelKeyLength.AutoSize = true;
            this.labelKeyLength.Location = new System.Drawing.Point(11, 322);
            this.labelKeyLength.Name = "labelKeyLength";
            this.labelKeyLength.Size = new System.Drawing.Size(70, 13);
            this.labelKeyLength.TabIndex = 28;
            this.labelKeyLength.Text = "Duljina ključa";
            // 
            // labelInputFile
            // 
            this.labelInputFile.Location = new System.Drawing.Point(250, 8);
            this.labelInputFile.Name = "labelInputFile";
            this.labelInputFile.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.labelInputFile.Size = new System.Drawing.Size(152, 13);
            this.labelInputFile.TabIndex = 27;
            this.labelInputFile.Text = "primjer.txt";
            this.labelInputFile.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // algorithmList
            // 
            this.algorithmList.FormattingEnabled = true;
            this.algorithmList.Location = new System.Drawing.Point(13, 24);
            this.algorithmList.Name = "algorithmList";
            this.algorithmList.Size = new System.Drawing.Size(120, 147);
            this.algorithmList.Sorted = true;
            this.algorithmList.TabIndex = 26;
            // 
            // labelAlg
            // 
            this.labelAlg.AutoSize = true;
            this.labelAlg.Location = new System.Drawing.Point(10, 8);
            this.labelAlg.Name = "labelAlg";
            this.labelAlg.Size = new System.Drawing.Size(46, 13);
            this.labelAlg.TabIndex = 25;
            this.labelAlg.Text = "Algoritmi";
            // 
            // comboBoxKeyLen
            // 
            this.comboBoxKeyLen.FormattingEnabled = true;
            this.comboBoxKeyLen.Location = new System.Drawing.Point(13, 338);
            this.comboBoxKeyLen.Name = "comboBoxKeyLen";
            this.comboBoxKeyLen.Size = new System.Drawing.Size(121, 21);
            this.comboBoxKeyLen.TabIndex = 43;
            this.comboBoxKeyLen.SelectedIndexChanged += new System.EventHandler(this.comboBoxKeyLen_SelectedIndexChanged);
            // 
            // labelOutputFile
            // 
            this.labelOutputFile.Location = new System.Drawing.Point(528, 8);
            this.labelOutputFile.Name = "labelOutputFile";
            this.labelOutputFile.Size = new System.Drawing.Size(152, 13);
            this.labelOutputFile.TabIndex = 44;
            this.labelOutputFile.Text = "primjer.txt";
            this.labelOutputFile.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // textBoxKey
            // 
            this.textBoxKey.Location = new System.Drawing.Point(162, 339);
            this.textBoxKey.Name = "textBoxKey";
            this.textBoxKey.Size = new System.Drawing.Size(159, 20);
            this.textBoxKey.TabIndex = 46;
            // 
            // labelKeyFile
            // 
            this.labelKeyFile.Location = new System.Drawing.Point(208, 324);
            this.labelKeyFile.Name = "labelKeyFile";
            this.labelKeyFile.Size = new System.Drawing.Size(113, 13);
            this.labelKeyFile.TabIndex = 48;
            this.labelKeyFile.Text = "primjer.txt";
            this.labelKeyFile.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // buttonGenerateKey
            // 
            this.buttonGenerateKey.Location = new System.Drawing.Point(327, 338);
            this.buttonGenerateKey.Name = "buttonGenerateKey";
            this.buttonGenerateKey.Size = new System.Drawing.Size(75, 23);
            this.buttonGenerateKey.TabIndex = 49;
            this.buttonGenerateKey.Text = "Generiraj";
            this.buttonGenerateKey.UseVisualStyleBackColor = true;
            this.buttonGenerateKey.Click += new System.EventHandler(this.buttonGenerateKey_Click);
            // 
            // labelTaglen
            // 
            this.labelTaglen.Location = new System.Drawing.Point(94, 286);
            this.labelTaglen.Name = "labelTaglen";
            this.labelTaglen.Size = new System.Drawing.Size(39, 13);
            this.labelTaglen.TabIndex = 56;
            this.labelTaglen.Text = "8 B";
            this.labelTaglen.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // labelNoncelen
            // 
            this.labelNoncelen.Location = new System.Drawing.Point(91, 264);
            this.labelNoncelen.Name = "labelNoncelen";
            this.labelNoncelen.Size = new System.Drawing.Size(42, 13);
            this.labelNoncelen.TabIndex = 55;
            this.labelNoncelen.Text = "32 B";
            this.labelNoncelen.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // labelKeylen
            // 
            this.labelKeylen.Location = new System.Drawing.Point(88, 242);
            this.labelKeylen.Name = "labelKeylen";
            this.labelKeylen.Size = new System.Drawing.Size(45, 13);
            this.labelKeylen.TabIndex = 54;
            this.labelKeylen.Text = "16 B";
            this.labelKeylen.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // labelTag
            // 
            this.labelTag.AutoSize = true;
            this.labelTag.Location = new System.Drawing.Point(11, 286);
            this.labelTag.Name = "labelTag";
            this.labelTag.Size = new System.Drawing.Size(59, 13);
            this.labelTag.TabIndex = 53;
            this.labelTag.Text = "Sažetak T:";
            // 
            // labelNonce
            // 
            this.labelNonce.AutoSize = true;
            this.labelNonce.Location = new System.Drawing.Point(11, 264);
            this.labelNonce.Name = "labelNonce";
            this.labelNonce.Size = new System.Drawing.Size(71, 13);
            this.labelNonce.TabIndex = 52;
            this.labelNonce.Text = "Javni ključ N:";
            // 
            // labelKey
            // 
            this.labelKey.AutoSize = true;
            this.labelKey.Location = new System.Drawing.Point(11, 242);
            this.labelKey.Name = "labelKey";
            this.labelKey.Size = new System.Drawing.Size(43, 13);
            this.labelKey.TabIndex = 51;
            this.labelKey.Text = "Ključ K:";
            // 
            // labelAlgInfo
            // 
            this.labelAlgInfo.AutoSize = true;
            this.labelAlgInfo.Location = new System.Drawing.Point(11, 218);
            this.labelAlgInfo.Name = "labelAlgInfo";
            this.labelAlgInfo.Size = new System.Drawing.Size(70, 13);
            this.labelAlgInfo.TabIndex = 50;
            this.labelAlgInfo.Text = "Algoritam info";
            // 
            // labelKey2
            // 
            this.labelKey2.AutoSize = true;
            this.labelKey2.Location = new System.Drawing.Point(159, 323);
            this.labelKey2.Name = "labelKey2";
            this.labelKey2.Size = new System.Drawing.Size(43, 13);
            this.labelKey2.TabIndex = 47;
            this.labelKey2.Text = "Ključ K:";
            // 
            // CryptoControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.labelTaglen);
            this.Controls.Add(this.labelNoncelen);
            this.Controls.Add(this.labelKeylen);
            this.Controls.Add(this.labelTag);
            this.Controls.Add(this.labelNonce);
            this.Controls.Add(this.labelKey);
            this.Controls.Add(this.labelAlgInfo);
            this.Controls.Add(this.buttonGenerateKey);
            this.Controls.Add(this.labelKeyFile);
            this.Controls.Add(this.labelKey2);
            this.Controls.Add(this.textBoxKey);
            this.Controls.Add(this.labelOutputFile);
            this.Controls.Add(this.comboBoxKeyLen);
            this.Controls.Add(this.textBoxTag);
            this.Controls.Add(this.labelTag2);
            this.Controls.Add(this.textBoxOutput);
            this.Controls.Add(this.labelOutput);
            this.Controls.Add(this.buttonSelectFile);
            this.Controls.Add(this.textBoxInput);
            this.Controls.Add(this.labelInput);
            this.Controls.Add(this.labelKeyLength);
            this.Controls.Add(this.labelInputFile);
            this.Controls.Add(this.algorithmList);
            this.Controls.Add(this.labelAlg);
            this.Name = "CryptoControl";
            this.Size = new System.Drawing.Size(691, 371);
            this.Load += new System.EventHandler(this.CryptoControl_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox textBoxTag;
        private System.Windows.Forms.Label labelTag2;
        private System.Windows.Forms.Label labelOutput;
        private System.Windows.Forms.Button buttonSelectFile;
        private System.Windows.Forms.Label labelInput;
        private System.Windows.Forms.Label labelKeyLength;
        private System.Windows.Forms.Label labelAlg;
        private System.Windows.Forms.Label labelKeyFile;
        private System.Windows.Forms.Button buttonGenerateKey;
        private System.Windows.Forms.Label labelTaglen;
        private System.Windows.Forms.Label labelNoncelen;
        private System.Windows.Forms.Label labelKeylen;
        private System.Windows.Forms.Label labelTag;
        private System.Windows.Forms.Label labelNonce;
        private System.Windows.Forms.Label labelKey;
        private System.Windows.Forms.Label labelAlgInfo;
        private System.Windows.Forms.Label labelKey2;
        public System.Windows.Forms.ListBox algorithmList;
        public System.Windows.Forms.TextBox textBoxOutput;
        public System.Windows.Forms.TextBox textBoxInput;
        public System.Windows.Forms.ComboBox comboBoxKeyLen;
        public System.Windows.Forms.TextBox textBoxKey;
        public System.Windows.Forms.Label labelInputFile;
        public System.Windows.Forms.Label labelOutputFile;
    }
}
