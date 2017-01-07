namespace FormsApplication
{
    partial class Form1
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
            this.components = new System.ComponentModel.Container();
            this.encryptRadio = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.algorithmList = new System.Windows.Forms.ListBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.inputTextBox = new System.Windows.Forms.TextBox();
            this.selectButton = new System.Windows.Forms.Button();
            this.clearButton = new System.Windows.Forms.Button();
            this.outputTextBox = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.encryptButton = new System.Windows.Forms.Button();
            this.tagTextBox = new System.Windows.Forms.TextBox();
            this.decryptRadio = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // encryptRadio
            // 
            this.encryptRadio.AutoSize = true;
            this.encryptRadio.Checked = true;
            this.encryptRadio.Location = new System.Drawing.Point(7, 15);
            this.encryptRadio.Name = "encryptRadio";
            this.encryptRadio.Size = new System.Drawing.Size(71, 17);
            this.encryptRadio.TabIndex = 22;
            this.encryptRadio.TabStop = true;
            this.encryptRadio.Text = "Enkripcija";
            this.encryptRadio.UseVisualStyleBackColor = true;
            this.encryptRadio.CheckedChanged += new System.EventHandler(this.encryptRadio_CheckedChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Algoritam";
            // 
            // algorithmList
            // 
            this.algorithmList.FormattingEnabled = true;
            this.algorithmList.Location = new System.Drawing.Point(15, 25);
            this.algorithmList.Name = "algorithmList";
            this.algorithmList.Size = new System.Drawing.Size(120, 147);
            this.algorithmList.Sorted = true;
            this.algorithmList.TabIndex = 1;
            this.algorithmList.SelectedIndexChanged += new System.EventHandler(this.algorithmList_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 257);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Algoritam info";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 281);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(43, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Ključ K:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 303);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(71, 13);
            this.label4.TabIndex = 4;
            this.label4.Text = "Javni ključ N:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 325);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(59, 13);
            this.label5.TabIndex = 5;
            this.label5.Text = "Sažetak T:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(98, 281);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(37, 13);
            this.label6.TabIndex = 6;
            this.label6.Text = "16 okt";
            this.label6.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(98, 303);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(37, 13);
            this.label7.TabIndex = 7;
            this.label7.Text = "32 okt";
            this.label7.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(104, 325);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(31, 13);
            this.label8.TabIndex = 8;
            this.label8.Text = "8 okt";
            this.label8.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(145, 9);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(85, 13);
            this.label9.TabIndex = 9;
            this.label9.Text = "Ulazna datoteka";
            // 
            // inputTextBox
            // 
            this.inputTextBox.Location = new System.Drawing.Point(148, 25);
            this.inputTextBox.MaxLength = 600;
            this.inputTextBox.Multiline = true;
            this.inputTextBox.Name = "inputTextBox";
            this.inputTextBox.Size = new System.Drawing.Size(240, 291);
            this.inputTextBox.TabIndex = 10;
            // 
            // selectButton
            // 
            this.selectButton.Location = new System.Drawing.Point(232, 323);
            this.selectButton.Name = "selectButton";
            this.selectButton.Size = new System.Drawing.Size(75, 23);
            this.selectButton.TabIndex = 11;
            this.selectButton.Text = "Odaberi";
            this.selectButton.UseVisualStyleBackColor = true;
            this.selectButton.Click += new System.EventHandler(this.selectButton_Click);
            // 
            // clearButton
            // 
            this.clearButton.Location = new System.Drawing.Point(313, 323);
            this.clearButton.Name = "clearButton";
            this.clearButton.Size = new System.Drawing.Size(75, 23);
            this.clearButton.TabIndex = 12;
            this.clearButton.Text = "Obriši";
            this.clearButton.UseVisualStyleBackColor = true;
            this.clearButton.Click += new System.EventHandler(this.clearButton_Click);
            // 
            // outputTextBox
            // 
            this.outputTextBox.Location = new System.Drawing.Point(415, 25);
            this.outputTextBox.MaxLength = 600;
            this.outputTextBox.Multiline = true;
            this.outputTextBox.Name = "outputTextBox";
            this.outputTextBox.Size = new System.Drawing.Size(240, 291);
            this.outputTextBox.TabIndex = 14;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(412, 9);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(85, 13);
            this.label10.TabIndex = 13;
            this.label10.Text = "Izlazna datoteka";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(412, 325);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(59, 13);
            this.label12.TabIndex = 16;
            this.label12.Text = "Sažetak T:";
            // 
            // encryptButton
            // 
            this.encryptButton.Location = new System.Drawing.Point(580, 320);
            this.encryptButton.Name = "encryptButton";
            this.encryptButton.Size = new System.Drawing.Size(75, 23);
            this.encryptButton.TabIndex = 19;
            this.encryptButton.Text = "Kriptiraj";
            this.encryptButton.UseVisualStyleBackColor = true;
            this.encryptButton.Click += new System.EventHandler(this.encryptButton_Click);
            // 
            // tagTextBox
            // 
            this.tagTextBox.Location = new System.Drawing.Point(474, 322);
            this.tagTextBox.Name = "tagTextBox";
            this.tagTextBox.Size = new System.Drawing.Size(100, 20);
            this.tagTextBox.TabIndex = 21;
            // 
            // decryptRadio
            // 
            this.decryptRadio.AutoSize = true;
            this.decryptRadio.Location = new System.Drawing.Point(6, 38);
            this.decryptRadio.Name = "decryptRadio";
            this.decryptRadio.Size = new System.Drawing.Size(72, 17);
            this.decryptRadio.TabIndex = 23;
            this.decryptRadio.Text = "Dekripcija";
            this.decryptRadio.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.encryptRadio);
            this.groupBox1.Controls.Add(this.decryptRadio);
            this.groupBox1.Location = new System.Drawing.Point(15, 178);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(120, 62);
            this.groupBox1.TabIndex = 24;
            this.groupBox1.TabStop = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(674, 358);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.tagTextBox);
            this.Controls.Add(this.encryptButton);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.outputTextBox);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.clearButton);
            this.Controls.Add(this.selectButton);
            this.Controls.Add(this.inputTextBox);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.algorithmList);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "CryptoAEAD";
            this.Load += new System.EventHandler(this.CryptoAEAD_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox algorithmList;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox inputTextBox;
        private System.Windows.Forms.Button selectButton;
        private System.Windows.Forms.Button clearButton;
        private System.Windows.Forms.TextBox outputTextBox;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Button encryptButton;
        private System.Windows.Forms.TextBox tagTextBox;
        private System.Windows.Forms.RadioButton decryptRadio;
        private System.Windows.Forms.RadioButton encryptRadio;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ToolTip toolTip1;
    }
}

