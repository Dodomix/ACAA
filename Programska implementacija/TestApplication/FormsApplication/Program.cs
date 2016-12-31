using System;
using System.Collections;
using System.Collections.Generic;
using System.Windows.Forms;

namespace FormsApplication
{
    static class Program
    {
        private static int ALG_NUM = 11;

        [STAThread]
        static void Main()
        {
            ArrayList AlgorithmNames = new ArrayList();
            AlgorithmNames.Add("ASCON");
            AlgorithmNames.Add("AESOTR_S");
            AlgorithmNames.Add("AESOTR_P");
            AlgorithmNames.Add("Acorn");
            AlgorithmNames.Add("Keyak");
            AlgorithmNames.Add("OCB");
            AlgorithmNames.Add("Norx");
            AlgorithmNames.Add("Deoxys");
            AlgorithmNames.Add("Ketje");
            AlgorithmNames.Add("AEZ");
            AlgorithmNames.Add("MORUS");

            Dictionary<String, int> Algorithms = new Dictionary<String, int>();
            for (int i=0; i<ALG_NUM; ++i)
            {
                Algorithms.Add((String)AlgorithmNames[i], i);
            }

            Dictionary<int, List<int>> KeyLengths = new Dictionary<int, List<int>>();
            foreach(KeyValuePair<String, int> entry in Algorithms)
            {
                List<int> keysList = new List<int>();
                keysList.Add(128);
                keysList.Add(256);
                KeyLengths.Add(entry.Value, keysList);
            }

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new Form1(Algorithms));
            Application.Run(new CryptoAEAD(Algorithms, KeyLengths));
        }
    }
}
