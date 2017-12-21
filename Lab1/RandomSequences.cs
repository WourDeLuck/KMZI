using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Security.Cryptography;
using System.Numerics;

namespace Lab1
{
    /// <summary>
    /// Test class for testing random sequence generating.
    /// </summary>
    public class RandomSequences
    {
        /// <summary>
        /// Size of file.
        /// </summary>
        private byte[] bt = new byte[20000000];

        /// <summary>
        /// String to store file path.
        /// </summary>
        private string begPath = @"C:\temp\";

        /// <summary>
        /// Generates a random sequence of numbers
        /// </summary>
        /// <param name="fileName">Desirable name of file.</param>
        public void GenerateRandomSequence(string fileName)
        {
            string filePath = begPath + fileName;
            Random rnd = new Random();

            rnd.NextBytes(bt);

            using (BinaryWriter bn = new BinaryWriter(new FileStream(filePath, FileMode.Create)))
            {
                bn.Write(bt);
            }

            Console.WriteLine("File has been created.");
        }

        /// <summary>
        /// Generates a random sequence using Crypto API.
        /// </summary>
        /// <param name="fileName"></param>
        public void PseudorandomSequence(string fileName)
        {
            string filePath = begPath + fileName;
            RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider();

            rng.GetBytes(bt);

            using (BinaryWriter bn = new BinaryWriter(new FileStream(filePath, FileMode.Create)))
            {
                bn.Write(bt);
            }

            Console.WriteLine("File has been created.");
        }

        /// <summary>
        /// Generates a random sequence by algoritm.
        /// </summary>
        /// <param name="fileName"></param>
        public void AlgorhitmRandomizer(string fileName)
        {
            string filePath = begPath + fileName;
            double num = 0;
            double mod = Math.Pow(2, 32) - 5;
            double smth = 0;

            for (int i=0; i<3; i++)
            {
                num = ((i + 1) * 1234567) * i;
                bt[i] = (byte)num;
            }

            for (int i=3; i<bt.Length; i++)
            {
                int fNum = 1176 * bt[i - 1];
                int sNum = 1476 * bt[i - 2];
                int tNum = 1776 * bt[i - 3];

                smth = (fNum + sNum + tNum) % mod;

                while (smth > 4294967291)
                    smth -= 4294967291;
                num = smth * i;
                byte b = (byte)num;
                bt[i] = b;
            }

            using (BinaryWriter bn = new BinaryWriter(new FileStream(filePath, FileMode.Create)))
            {
                bn.Write(bt);
            }
        }

    }
}
