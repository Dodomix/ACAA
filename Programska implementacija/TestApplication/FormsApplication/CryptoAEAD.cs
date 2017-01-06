using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices; // DLL support
using System.IO;

namespace FormsApplication
{
    public partial class CryptoAEAD : Form
    {

        [DllImport("Algorithms.dll", EntryPoint = "encrypt")]
        public static extern int encrypt(string filepath, string outpath, string nonce, string k, int alg);
        [DllImport("Algorithms.dll", EntryPoint = "decrypt")]
        public static extern int decrypt(string filepath, string outpath, string nonce, string k, int alg);

        public Dictionary<String, int> Algorithms;

        public Dictionary<int, List<int>> KeyLengths;

        public static int MAXTEXTLEN = 500;

        // TODO staviti varijabilno
        string nonce = "\x6b\x4c\x2d\x0e\xef\xd0\xb1\x92\x72\x53\x34\x15\xf6\xd7\xb8\x99";
        string k = "\x5a\x4b\x3c\x2d\x1e\x0f\x11\xf1\xe2\xd3\xc4\xb5\xa6\x97\x88\x79";

        public CryptoAEAD(Dictionary<String, int> Algorithms, Dictionary<int, List<int>> KeyLengths)
        {
            this.Algorithms = Algorithms;
            this.KeyLengths = KeyLengths;
            InitializeComponent();
        }

        private void CryptoAEAD_Load(object sender, EventArgs e)
        {
            // TODO
            string filePathInputEncrypt = "./files/testni_primjer.txt";
            string filePathInputDecrypt = "./files/testni_primjer_encrypted.txt";
            initialize(controlEncrypt, filePathInputEncrypt);
            initialize(controlDecrypt, filePathInputDecrypt);
            
        }

        private void initialize(CryptoControl cryptoControl, string filePathInput)
        {
            cryptoControl.algorithmList.DataSource = Algorithms.Keys.ToList();
            cryptoControl.algorithmList.SelectedIndexChanged += new System.EventHandler(cryptoControl.algorithmList_SelectedIndexChanged);
            cryptoControl.comboBoxKeyLen.DataSource = KeyLengths[0];

            // otvori testnu datoteku za enkripciju
            //cryptoControl.textBoxOutput.Text = Directory.GetCurrentDirectory();
            // TODO trenutno u bin/debug
            cryptoControl.filePathInput = filePathInput;
            cryptoControl.labelInputFile.Text = Path.GetFileName(filePathInput);

            cryptoControl.filePathOutput = cryptoControl.getOutputPath(filePathInput);
            cryptoControl.labelOutputFile.Text = Path.GetFileName(cryptoControl.filePathOutput);
            
            try
            {
                Stream fileStream = File.OpenRead(filePathInput);
                using (StreamReader sr = new StreamReader(fileStream))
                {
                    string encryptedText = sr.ReadToEnd();
                    if (cryptoControl.Name == "controlDecrypt")
                    {
                        string plainText = encryptedText.Substring(0, encryptedText.Length - 16);
                        string tag = encryptedText.Substring(encryptedText.Length - 16, 16);

                        var textBytes = System.Text.Encoding.UTF8.GetBytes(plainText);
                        var tagBytes = System.Text.Encoding.UTF8.GetBytes(tag);

                        string base64Text = System.Convert.ToBase64String(textBytes);
                        string base64Tag = System.Convert.ToBase64String(tagBytes);

                        encryptedText = base64Text;
                        cryptoControl.textBoxTag.Text = base64Tag;
                    }
                    cryptoControl.textBoxInput.Text = encryptedText;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: Could not read test file from disk. Original error: " + ex.Message);
            }
        }
        
        private void buttonEncrypt_Click(object sender, EventArgs e)
        {
            try
            {
                String selectedAlgorithm = controlEncrypt.algorithmList.SelectedItem.ToString();
                int algNum = Algorithms[selectedAlgorithm];
                algNum = selectImplementation(algNum, controlEncrypt);

                string filePath = controlEncrypt.filePathInput;
                if (filePath != null)
                {
                    String destPath = controlEncrypt.filePathOutput;

                    k = getKey(controlEncrypt);
                    nonce = controlEncrypt.nonce;
                    int status = encrypt(filePath, destPath, nonce, k, algNum);
                    if (status != 0) throw new Exception();

                    try
                    {
                         Stream fileStream = File.OpenRead(destPath);
                        using (StreamReader sr = new StreamReader(fileStream))
                        {
                            string encryptedText = sr.ReadToEnd();
                            string plainText = encryptedText.Substring(0, encryptedText.Length - 16);
                            string tag = encryptedText.Substring(encryptedText.Length - 16, 16);

                            var textBytes = System.Text.Encoding.UTF8.GetBytes(plainText);
                            var tagBytes = System.Text.Encoding.UTF8.GetBytes(tag);

                            string base64Text = System.Convert.ToBase64String(textBytes);
                            string base64Tag = System.Convert.ToBase64String(tagBytes);

                            if (base64Text.Length > MAXTEXTLEN)
                            {
                                base64Text = base64Text.Substring(0, MAXTEXTLEN);
                                base64Text += " ...";
                            }
                            controlEncrypt.textBoxOutput.Text = base64Text;
                            controlEncrypt.textBoxTag.Text = base64Tag;
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error: Could not read file from disk. Original error: " + ex.Message);
                    }
                }
                controlEncrypt.textBoxOutput.BackColor = Color.LightGreen;
            }
            catch (Exception ex)
            {
                controlEncrypt.textBoxOutput.Text = "Enkripcija neuspjela!";
                controlEncrypt.textBoxOutput.BackColor = Color.LightPink;
                //MessageBox.Show("Error: Encryption failed! Original error: " + ex.Message);
            }
        }

        private void buttonDecrypt_Click(object sender, EventArgs e)
        {
            try
            {
                String selectedAlgorithm = controlDecrypt.algorithmList.SelectedItem.ToString();
                int algNum = Algorithms[selectedAlgorithm];
                algNum = selectImplementation(algNum, controlDecrypt);

                string filePath = controlDecrypt.filePathInput;
                if (filePath != null && controlDecrypt.textBoxInput.Text.Length > 0)
                {
                    String destPath = controlDecrypt.filePathOutput;
                    k = getKey(controlDecrypt);
                    nonce = controlDecrypt.nonce;
                    int status = decrypt(filePath, destPath, nonce, k, algNum);
                    if (status != 0) throw new Exception();

                    try
                    {
                        Stream fileStream = File.OpenRead(destPath);
                        using (StreamReader sr = new StreamReader(fileStream))
                        {
                            controlDecrypt.textBoxOutput.Text = sr.ReadToEnd();
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error: Could not read file from disk. Original error: " + ex.Message);
                    }
                }
                controlDecrypt.textBoxOutput.BackColor = Color.LightGreen;
            }
            catch (Exception ex)
            {
                controlDecrypt.textBoxOutput.Text = "Dekripcija neuspjela!";
                controlDecrypt.textBoxOutput.BackColor = Color.LightPink;
                //MessageBox.Show("Error: Decryption failed! Original error: " + ex.Message);
            }
        }

        public static string getKey(CryptoControl cryptoControl)
        {
            string key = cryptoControl.textBoxKey.Text;
            int keyLen = (int)cryptoControl.comboBoxKeyLen.SelectedItem / 8;
            byte[] buffer = new byte[keyLen];
            buffer = System.Convert.FromBase64String(key);
            key = BitConverter.ToString(buffer);
            //key = "";
            //for (int i = 0; i < keyLen; ++i) key += buffer[i];
            return key;
        }

        private int selectImplementation(int algNum, CryptoControl cryptoControl)
        {
            if ((int)cryptoControl.comboBoxKeyLen.SelectedItem == 256)
            {
                // TODO hardkodirano
                if (algNum == 7) algNum = 11; // Deoxys
                if (algNum == 10) algNum = 12; // MORUS
            }
            return algNum;
        }
        
    }
}
