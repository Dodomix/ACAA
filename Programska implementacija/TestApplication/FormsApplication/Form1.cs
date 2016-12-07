using System;
using System.Collections.Generic;
using System.Linq;
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

        // TODO nonce hardkodiraj
        private static int MAXTEXTLEN = 500;
        
        private Dictionary<String, int> Algorithms;

        private Stream fileStream = null;

        public CryptoAEAD(Dictionary<String, int> Algorithms)
        {
            this.Algorithms = Algorithms;
            InitializeComponent();
        }

        private void CryptoAEAD_Load(object sender, EventArgs e)
        {
            algorithmList.DataSource = Algorithms.Keys.ToList();
            // TODO otvori testnu datoteku za enkripciju
            //fileStream = ;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label13_Click(object sender, EventArgs e)
        {

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
                    fileStream = ofd.OpenFile();
                    if (fileStream != null)
                    {
                        using (StreamReader sr = new StreamReader(fileStream))
                        {
                            
                            String ext = Path.GetExtension(ofd.FileName);
                            if (ext.Equals(".txt"))
                            {
                                String text = sr.ReadToEnd();
                                if (text.Length > MAXTEXTLEN)
                                {
                                    text = text.Substring(0, MAXTEXTLEN);
                                    text += "...";
                                }
                                inputTextBox.Text = text;

                            } else
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
            fileStream = null;
            inputTextBox.Text = "";
        }

        private void encryptButton_Click(object sender, EventArgs e)
        {
            //String selectedAlgorithm = algorithmList.SelectedItem.ToString();
            //int algNum = Algorithms[selectedAlgorithm];   
        }
    }
}
