using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace FormsApplication
{
    public partial class CryptoControl : UserControl
    {
        // na jednom mjestu?
        public static int MAXTEXTLEN = 500;

        public String filePathInput = null;

        public String filePathOutput = null;

        public String filePathKey = null;

        public string nonce = "\x6b\x4c\x2d\x0e\xef\xd0\xb1\x92\x72\x53\x34\x15\xf6\xd7\xb8\x99";

        private bool keySet = false;
        private int lastIndex = 0;

        public CryptoControl()
        {
            InitializeComponent();
        }

        private void CryptoControl_Load(object sender, EventArgs e)
        {
            // TODO datasource u cc ?
            //algorithmList.DataSource = ((CryptoAEAD)Parent.Parent.Parent).Algorithms.Keys.ToList();
            //this.algorithmList.SelectedIndexChanged += new System.EventHandler(this.algorithmList_SelectedIndexChanged);
            
            // TODO
            filePathKey = "./files/kljuc128.txt";

            comboBoxKeyLen.DrawItem += new DrawItemEventHandler(this.comboBoxKeyLen_DrawItem);
        }

        private void selectButton_Click(object sender, EventArgs e)
        {
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
                            if (Name == "controlDecrypt" && 
                                !ofd.SafeFileName.EndsWith("_encrypted.txt"))
                            {
                                throw new Exception("Incorrect file name format! The files for decryption must end in \"_encrypted.txt\"");
                            }

                            filePathInput = ofd.FileName;
                            labelInputFile.Text = ofd.SafeFileName;

                            filePathOutput = getOutputPath(filePathInput);
                            labelOutputFile.Text = Path.GetFileName(filePathOutput);

                            string encryptedText = sr.ReadToEnd();
                            if (Name == "controlDecrypt")
                            {
                                string plainText = encryptedText.Substring(0, encryptedText.Length - 16);
                                string tag = encryptedText.Substring(encryptedText.Length - 16, 16);

                                var textBytes = System.Text.Encoding.UTF8.GetBytes(plainText);
                                var tagBytes = System.Text.Encoding.UTF8.GetBytes(tag);

                                string base64Text = System.Convert.ToBase64String(textBytes);
                                string base64Tag = System.Convert.ToBase64String(tagBytes);

                                encryptedText = base64Text;
                                textBoxTag.Text = base64Tag;
                            }
                            
                            String ext = Path.GetExtension(ofd.FileName);
                            if (ext.Equals(".txt"))
                            {
                                if (encryptedText.Length > MAXTEXTLEN)
                                {
                                    encryptedText = encryptedText.Substring(0, MAXTEXTLEN);
                                    encryptedText += " ...";
                                }
                                textBoxInput.Text = encryptedText;

                            }
                            else
                            {
                                textBoxInput.Text = ofd.FileName;
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

        private void buttonGenerateKey_Click(object sender, EventArgs e)
        {
            generateKey();
        }

        public void algorithmList_SelectedIndexChanged(object sender, EventArgs e)
        {
            // odaberi algoritam i u drugom tabu
            TabControl tabControl = (TabControl)Parent.Parent;
            int otherTabIndex = tabControl.SelectedIndex ^ 1;
            TabPage otherTab = (TabPage)tabControl.TabPages[otherTabIndex];
            // TODO cryptocontrol na indexu 1???
            CryptoControl cryptoControl = (CryptoControl)otherTab.Controls[1];
            cryptoControl.algorithmList.SelectedIndex = algorithmList.SelectedIndex;

            // dohvati odgovarajuce duljine kljuceva
            int algNum = this.getAlgorithmNum();
            comboBoxKeyLen.DataSource = ((CryptoAEAD)Parent.Parent.Parent).KeyLengths[algNum];

            // dohvati odgovarajuci nonce
            nonce = getNonce(algNum);
            labelNoncelen.Text = nonce.Length.ToString() + " B";

            comboBoxKeyLen.Refresh();
        }

        private string getNonce(int algNum)
        {
            // TODO hardkodirano
            string n = "\x6b\x4c\x2d\x0e\xef\xd0\xb1\x92\x72\x53\x34\x15\xf6\xd7\xb8\x99";
            int len = 16;
            if (algNum == 4) len = 160; //keyak
            if (algNum == 6) len = 32; //norx

            string nonce = "";
            for (int i = 0; i < len/16; ++i) nonce += n;
            return nonce;
        }

        private void comboBoxKeyLen_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!this.has256version(this.getAlgorithmNum()) && comboBoxKeyLen.SelectedIndex == 1)
            {
                comboBoxKeyLen.SelectedIndex = 0;
                return;
            }

            if (comboBoxKeyLen.SelectedIndex != lastIndex)
            {
                keySet = false;
                lastIndex = comboBoxKeyLen.SelectedIndex;
            }

            if (!keySet && filePathKey!=null)
            {
                int keyLen = (int)comboBoxKeyLen.SelectedItem / 8;
                filePathKey = Path.Combine(Path.GetDirectoryName(filePathKey),
                    "kljuc" + keyLen.ToString()) + ".txt";
                string fileName = Path.GetFileName(filePathKey);
                labelKeylen.Text = "(" + keyLen.ToString() + " B)";

                try
                {
                    loadKey(filePathKey, fileName);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: Could not read file from disk. Original error: " + ex.Message
                        + "The program will generate a new key.");
                    generateKey();
                    saveFile();
                }
                keySet = true;
            }
            
        }

        private void comboBoxKeyLen_DrawItem(object sender, DrawItemEventArgs e)
        {
            Font myFont = new Font("Aerial", 10, FontStyle.Regular);
            if (!this.has256version(this.getAlgorithmNum()) && e.Index == 1)
            {
                e.Graphics.DrawString(comboBoxKeyLen.Items[e.Index].ToString(), myFont, Brushes.LightGray, e.Bounds);
            }
            else
            {
                e.DrawBackground();
                e.Graphics.DrawString(comboBoxKeyLen.Items[e.Index].ToString(), myFont, Brushes.Black, e.Bounds);
                e.DrawFocusRectangle();
            }
        }

        private void generateKey()
        {
            int keyLen = (int)comboBoxKeyLen.SelectedItem / 8;
            byte[] buffer = new byte[keyLen];

            Random rnd = new Random();
            rnd.NextBytes(buffer);

            string base64Text = System.Convert.ToBase64String(buffer);
            textBoxKey.Text = base64Text;

            TabControl tabControl = (TabControl)Parent.Parent;
            int otherTabIndex = tabControl.SelectedIndex ^ 1;
            TabPage otherTab = (TabPage)tabControl.TabPages[otherTabIndex];
            string controlName = (otherTabIndex == 1 ? "controlDecrypt" : "controlEncrypt");
            CryptoControl cryptoControl = (CryptoControl)otherTab.Controls.Find(controlName, false).First();
            cryptoControl.textBoxKey.Text = base64Text;
        }

        private void loadKey(string filePath, string fileName)
        {
            filePathKey = filePath;
            labelKeyFile.Text = fileName;

            byte[] bytes = File.ReadAllBytes(filePath);
            
            int keyLen = (int)comboBoxKeyLen.SelectedItem / 8;
            if (bytes.Length < keyLen)
            {
                // paddaj s nulama
                Array.Resize(ref bytes, keyLen);
            }
            else if (bytes.Length > keyLen)
            {
                // skrati kljuc
                byte[] newBytes = new byte[keyLen];
                Array.Copy(bytes, newBytes, keyLen);
                bytes = newBytes;
            }
            string base64Key = Convert.ToBase64String(bytes);

            textBoxKey.Text = base64Key;
            // drugi tab
            TabControl tabControl = (TabControl)Parent.Parent;
            int otherTabIndex = tabControl.SelectedIndex ^ 1;
            TabPage otherTab = (TabPage)tabControl.TabPages[otherTabIndex];
            string controlName = (otherTabIndex == 1 ? "controlDecrypt" : "controlEncrypt");
            CryptoControl cryptoControl = (CryptoControl)otherTab.Controls.Find(controlName, false).First();
            cryptoControl.textBoxKey.Text = base64Key;
            cryptoControl.labelKeyFile.Text = fileName;
        }

        private void textBoxKey_TextChanged(object sender, EventArgs e)
        {

        }

        public string getOutputPath(string filePathInput)
        {
            string output = "";
            if (Name == "controlEncrypt")
            {
                output = filePathOutput = Path.Combine(
                    Path.GetDirectoryName(filePathInput),
                    Path.GetFileNameWithoutExtension(filePathInput)
                    + "_encrypted.txt");
            }
            else if (Name == "controlDecrypt")
            {
                int len = Path.GetFileNameWithoutExtension(filePathInput).Length;
                output = filePathOutput = Path.Combine(
                    Path.GetDirectoryName(filePathInput),
                    Path.GetFileNameWithoutExtension(filePathInput).Substring(0, len - 10)
                    + "_decrypted.txt");
            }
            return output;
        }

        private void buttonSelectKeyFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.InitialDirectory = "c:\\";
            ofd.Filter = "txt files (*.txt)|*.txt";
            ofd.FilterIndex = 0;
            ofd.RestoreDirectory = true;

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    Stream fileStream = ofd.OpenFile();
                    if (fileStream != null)
                    {
                        loadKey(ofd.FileName, ofd.SafeFileName);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: Could not read file from disk. Original error: " + ex.Message);
                }
            }
        }

        private void buttonSaveKeyFile_Click(object sender, EventArgs e)
        {
            saveFile();
        }

        private void saveFile()
        {
            byte[] keyBytes = Convert.FromBase64String(textBoxKey.Text);
            File.WriteAllBytes(filePathKey, keyBytes);
        }

        private bool has256version(int algorithmNum)
        {
            return algorithmNum == 7 || algorithmNum == 10 || algorithmNum == 11 || algorithmNum == 12;
        }

        private int getAlgorithmNum()
        {
            return ((CryptoAEAD)Parent.Parent.Parent).Algorithms[algorithmList.SelectedItem.ToString()];
        }
    }
}
