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
                            filePathInput = ofd.FileName;
                            labelInputFile.Text = ofd.SafeFileName;

                            String ext = Path.GetExtension(ofd.FileName);
                            if (ext.Equals(".txt"))
                            {
                                String text = sr.ReadToEnd();
                                if (text.Length > MAXTEXTLEN)
                                {
                                    text = text.Substring(0, MAXTEXTLEN);
                                    text += " ...";
                                }
                                textBoxInput.Text = text;

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

        private void buttonSelectKey_Click(object sender, EventArgs e)
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
                            filePathKey = ofd.FileName;
                            labelKeyFile.Text = ofd.SafeFileName;

                            String ext = Path.GetExtension(ofd.FileName);
                            if (ext.Equals(".txt"))
                            {
                                // TODO keylen i bez tockica
                                String text = sr.ReadToEnd();
                                if (text.Length > MAXTEXTLEN)
                                {
                                    text = text.Substring(0, MAXTEXTLEN);
                                    text += " ...";
                                }
                                textBoxKey.Text = text;

                            }
                            else
                            {
                                // error
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
            int algNum = ((CryptoAEAD)Parent.Parent.Parent).Algorithms[algorithmList.SelectedItem.ToString()];
            comboBoxKeyLen.DataSource = ((CryptoAEAD)Parent.Parent.Parent).KeyLengths[algNum];

            // dohvati odgovarajuci nonce
            nonce = getNonce(algNum);
            // TODO azuriraj u alg info
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
            if (comboBoxKeyLen.SelectedIndex != lastIndex)
            {
                keySet = false;
                lastIndex = comboBoxKeyLen.SelectedIndex;
            }

            if (!keySet)
            {
                generateKey();
                keySet = true;
            }
            
        }

        private void generateKey()
        {
            string k = "\x5a\x4b\x3c\x2d\x1e\x0f\x11\xf1\xe2\xd3\xc4\xb5\xa6\x97\x88\x79";
            //byte[] buffer = new byte[] { 0x5a, 0x4b, 0x3c, 0x2d, 0x1e, 0x0f, 0x11, 0xf1, 0xe2, 0xd3, 0xc4, 0xb5, 0xa6, 0x97, 0x88, 0x79 };
            int keyLen = (int)comboBoxKeyLen.SelectedItem / 8;
            byte[] buffer = new byte[keyLen];

            Random rnd = new Random();
            rnd.NextBytes(buffer);

            string base64Text = System.Convert.ToBase64String(buffer);
            textBoxKey.Text = base64Text;

            TabControl tabControl = (TabControl)Parent.Parent;
            int otherTabIndex = tabControl.SelectedIndex ^ 1;
            TabPage otherTab = (TabPage)tabControl.TabPages[otherTabIndex];
            // TODO cryptocontrol na indexu 1???
            CryptoControl cryptoControl = (CryptoControl)otherTab.Controls[1];
            cryptoControl.textBoxKey.Text = base64Text;
        }

    }
}
