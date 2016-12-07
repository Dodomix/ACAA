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

            /*
             * // all others len=16
            string nonce = "\x6b\x4c\x2d\x0e\xef\xd0\xb1\x92\x72\x53\x34\x15\xf6\xd7\xb8\x99";
            string k = "\x5a\x4b\x3c\x2d\x1e\x0f\x11\xf1\xe2\xd3\xc4\xb5\xa6\x97\x88\x79";

            int alg = Int32.Parse(args[3]);

            // keyak len=150
            if (alg == 4)
            {
                nonce = "\x6b\x4c\x2d\x0e\xef\xd0\xb1\x92\x72\x53\x34\x15\xf6\xd7\xb8\x6b\x4c\x2d\x0e\xef\xd0\xb1\x92\x72\x53\x34\x15\xf6\xd7\xb8\x6b\x4c\x2d\x0e\xef\xd0\xb1\x92\x72\x53\x34\x15\xf6\xd7\xb8\x6b\x4c\x2d\x0e\xef\xd0\xb1\x92\x72\x53\x34\x15\xf6\xd7\xb8\x6b\x4c\x2d\x0e\xef\xd0\xb1\x92\x72\x53\x34\x15\xf6\xd7\xb8\x6b\x4c\x2d\x0e\xef\xd0\xb1\x92\x72\x53\x34\x15\xf6\xd7\xb8\x6b\x4c\x2d\x0e\xef\xd0\xb1\x92\x72\x53\x34\x15\xf6\xd7\xb8\x6b\x4c\x2d\x0e\xef\xd0\xb1\x92\x72\x53\x34\x15\xf6\xd7\xb8\x6b\x4c\x2d\x0e\xef\xd0\xb1\x92\x72\x53\x34\x15\xf6\xd7\xb8\x6b\x4c\x2d\x0e\xef\xd0\xb1\x92\x72\x53\x34\x15\xf6\xd7\xb8";
            }
            // ocb len=12
            else if (alg == 5)
            {
                nonce = "\x6b\x4c\x2d\x0e\xef\xd0\xb1\x92\x72\x53\x34\x15";
            }
            // norx len=32
            else if (alg == 6)
            {
                nonce = "\x6b\x4c\x2d\x0e\xef\xd0\xb1\x92\x72\x53\x34\x15\xf6\xd7\xb8\x99\x6b\x4c\x2d\x0e\xef\xd0\xb1\x92\x72\x53\x34\x15\xf6\xd7\xb8\x99";
                k = "\x5a\x4b\x3c\x2d\x1e\x0f\x11\xf1\xe2\xd3\xc4\xb5\xa6\x97\x88\x79\x5a\x4b\x3c\x2d\x1e\x0f\x11\xf1\xe2\xd3\xc4\xb5\xa6\x97\x88\x79";
            }
           
            encrypt(args[0], args[1], nonce, k, alg);
            decrypt(args[1], args[2], nonce, k, alg); 
            */

        }
    }
}
