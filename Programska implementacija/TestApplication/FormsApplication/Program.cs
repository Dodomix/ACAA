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

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new CryptoAEAD(Algorithms));
        }
    }
}
