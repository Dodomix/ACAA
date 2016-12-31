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
        public static extern void encrypt(string filepath, string outpath, string nonce, string k, int alg);
        [DllImport("Algorithms.dll", EntryPoint = "decrypt")]
        public static extern void decrypt(string filepath, string outpath, string nonce, string k, int alg);

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
            string filePathInputEncrypt = "C:/Users/User/Documents/Visual Studio 2015/Projects/TestApplication/FormsApplication/testni_primjer.txt";
            string filePathInputDecrypt = "C:/Users/User/Documents/Visual Studio 2015/Projects/TestApplication/FormsApplication/encrypted.txt";
            initialize(controlEncrypt, filePathInputEncrypt);
            initialize(controlDecrypt, filePathInputDecrypt);
            
        }

        private void initialize(CryptoControl cryptoControl, string filePathInput)
        {
            cryptoControl.algorithmList.DataSource = Algorithms.Keys.ToList();
            cryptoControl.algorithmList.SelectedIndexChanged += new System.EventHandler(cryptoControl.algorithmList_SelectedIndexChanged);
            cryptoControl.comboBoxKeyLen.DataSource = KeyLengths[0];

            // otvori testnu datoteku za enkripciju
            //textBoxOutput.Text = Directory.GetCurrentDirectory();
            cryptoControl.filePathInput = filePathInput;
            cryptoControl.labelInputFile.Text = "testni_primjer.txt";

            try
            {
                Stream fileStream = File.OpenRead(filePathInput);
                using (StreamReader sr = new StreamReader(fileStream))
                {
                    string encryptedText = sr.ReadToEnd();
                    if (cryptoControl.Name == "controlDecrypt")
                    {
                        var textBytes = System.Text.Encoding.UTF8.GetBytes(encryptedText);
                        encryptedText = System.Convert.ToBase64String(textBytes);
                    }
                    
                    cryptoControl.textBoxInput.Text = encryptedText;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: Could not read test file from disk. Original error: " + ex.Message);
            }
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

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
                    String destPath = "../../encrypted.txt";

                    k = getKey(controlEncrypt);
                    nonce = controlEncrypt.nonce;
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
                            controlEncrypt.textBoxOutput.Text = base64Text;
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
                    String destPath = "../../decrypted.txt";
                    k = getKey(controlDecrypt);
                    nonce = controlDecrypt.nonce;
                    decrypt(filePath, destPath, nonce, k, algNum);

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

        private string getKey(CryptoControl cryptoControl)
        {
            // TODO uljepsaj
            string key = cryptoControl.textBoxKey.Text;
            int keyLen = (int)cryptoControl.comboBoxKeyLen.SelectedItem / 8;
            byte[] buffer = new byte[keyLen];
            buffer = System.Convert.FromBase64String(key);
            key = "";
            for (int i = 0; i < keyLen; ++i) key += buffer[i];
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
