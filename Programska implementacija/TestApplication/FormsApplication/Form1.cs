using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Runtime.InteropServices; // DLL support
using System.IO;

namespace FormsApplication
{
    
    public partial class Form1 : Form
    {
        [DllImport("Algorithms.dll", EntryPoint = "encrypt")]
        public static extern void encrypt(string filepath, string outpath, string nonce, string k, int alg);
        [DllImport("Algorithms.dll", EntryPoint = "decrypt")]
        public static extern void decrypt(string filepath, string outpath, string nonce, string k, int alg);

        private static int MAXTEXTLEN = 500;
        
        private Dictionary<String, int> Algorithms;

        private String filePath = null;

        private bool encryption = true;

        // TODO staviti varijabilno
        string nonce = "\x6b\x4c\x2d\x0e\xef\xd0\xb1\x92\x72\x53\x34\x15\xf6\xd7\xb8\x99";
        string k = "\x5a\x4b\x3c\x2d\x1e\x0f\x11\xf1\xe2\xd3\xc4\xb5\xa6\x97\x88\x79";

        public Form1(Dictionary<String, int> Algorithms)
        {
            this.Algorithms = Algorithms;
            InitializeComponent();
        }

        private void CryptoAEAD_Load(object sender, EventArgs e)
        {
            algorithmList.DataSource = Algorithms.Keys.ToList();
            // otvori testnu datoteku za enkripciju
            //outputTextBox.Text = Directory.GetCurrentDirectory();

            filePath = "../../testni_primjer.txt";
            try
            {
                Stream fileStream = File.OpenRead(filePath);
                using (StreamReader sr = new StreamReader(fileStream))
                {
                    inputTextBox.Text = sr.ReadToEnd();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: Could not read test file from disk. Original error: " + ex.Message);
            }
        }

        private void selectButton_Click(object sender, EventArgs e)
        {
            if (!encryption) return;
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.InitialDirectory = "c:\\";
            ofd.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            ofd.FilterIndex = 2;
            ofd.RestoreDirectory = true;

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    Stream fileStream = ofd.OpenFile();
                    if (fileStream != null)
                    {
                        using (StreamReader sr = new StreamReader(fileStream))
                        {
                            filePath = ofd.FileName;
                            String ext = Path.GetExtension(ofd.FileName);
                            if (ext.Equals(".txt"))
                            {
                                String text = sr.ReadToEnd();
                                if (text.Length > MAXTEXTLEN)
                                {
                                    text = text.Substring(0, MAXTEXTLEN);
                                    text += " ...";
                                }
                                inputTextBox.Text = text;

                            }
                            else
                            {
                                inputTextBox.Text = ofd.FileName;
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: Could not read file from disk. Original error: " + ex.Message);
                }
            }
        }

        private void clearButton_Click(object sender, EventArgs e)
        {
            filePath = null;
            inputTextBox.Text = "";
            outputTextBox.Text = "";
        }

        // also used for decryption
        private void encryptButton_Click(object sender, EventArgs e)
        {
            String selectedAlgorithm = algorithmList.SelectedItem.ToString();
            int algNum = Algorithms[selectedAlgorithm];
            if (encryption)
            {
                if (filePath != null)
                {
                    String destPath = "../../encrypted.txt";
                    encrypt(filePath, destPath, nonce, k, algNum);

                    try
                    {
                        Stream fileStream = File.OpenRead(destPath);
                        using (StreamReader sr = new StreamReader(fileStream))
                        {
                            string encryptedText = sr.ReadToEnd();
                            var textBytes = System.Text.Encoding.UTF8.GetBytes(encryptedText);
                            string base64Text = System.Convert.ToBase64String(textBytes);

                            if (base64Text.Length > MAXTEXTLEN)
                            {
                                base64Text = base64Text.Substring(0, MAXTEXTLEN);
                                base64Text += " ...";
                            }
                            outputTextBox.Text = base64Text;
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error: Could not read file from disk. Original error: " + ex.Message);
                    }
                }
            }
            else
            {
                String srcPath = "../../encrypted.txt";
                if (srcPath != null && inputTextBox.Text.Length > 0)
                {
                    String destPath = "../../decrypted.txt";
                    decrypt(srcPath, destPath, nonce, k, algNum);

                    try
                    {
                        Stream fileStream = File.OpenRead(destPath);
                        using (StreamReader sr = new StreamReader(fileStream))
                        {
                            outputTextBox.Text = sr.ReadToEnd();
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error: Could not read file from disk. Original error: " + ex.Message);
                    }
                }
            }
        }

        private void encryptRadio_CheckedChanged(object sender, EventArgs e)
        {
            encryption = !encryption;
            if (encryption)
            {
                encryptButton.Text = "Kriptiraj";
            }
            else
            {
                encryptButton.Text = "Dekriptiraj";
            }

            string temp = inputTextBox.Text;
            inputTextBox.Text = outputTextBox.Text;
            outputTextBox.Text = temp;
        }

        private void algorithmList_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
