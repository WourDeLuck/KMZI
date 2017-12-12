using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lab2;

namespace KMZI
{
    class Program
    {
        static void Main(string[] args)
        {
            Crypter crypt = new Crypter();

            string text = "Hello, I'm your neighbor. Goodbye, I'll see you later.";
            int keyLength = 64;

            Console.WriteLine("Text: " + text);
            Console.WriteLine("Key length: " + keyLength);
            Console.WriteLine();
            crypt.Cryptor(text, keyLength);

            Console.ReadKey();
        }
    }
}
