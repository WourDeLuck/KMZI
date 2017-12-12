using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2
{
    /// <summary>
    /// Cryptor class.
    /// Encrypts and decrypts text.
    /// </summary>
    public class Crypter
    {
        /// <summary>
        /// Encrypts the text.
        /// </summary>
        /// <param name="text">Text to crypt.</param>
        /// <param name="keyLength">Length of the key.</param>
        public void Cryptor(string text, int keyLength)
        {
            int[] generatedKey = new int[keyLength];

            generatedKey = KeyGenerator(keyLength);
            generatedKey = TransformKey(generatedKey);

            string parsedKey = ParseKeyToString(generatedKey);

            Console.WriteLine("Key: " + parsedKey);
            string showKey = string.Join(" ", generatedKey);
            Console.WriteLine("ASCII transformed: " + showKey);

            List<string> dividedText = new List<string>();
            if (text.Length > keyLength)
                dividedText = DivideText(text, keyLength);
            else if (keyLength >= text.Length)
                dividedText.Add(text);

            string encryptedText = Encryptor(dividedText, generatedKey);
            Console.WriteLine("Encrypted text: " + encryptedText);

            Decryptor(encryptedText, generatedKey);
        }

        /// <summary>
        /// Decrypts the text using a key.
        /// </summary>
        /// <param name="cryptedText">Crypted text.</param>
        /// <param name="key">Key to decrypt with.</param>
        private void Decryptor(string cryptedText, int[] key)
        {
            List<string> dividedText = new List<string>();
            if (cryptedText.Length > key.Length)
                dividedText = DivideText(cryptedText, key.Length);
            else if (key.Length >= cryptedText.Length)
                dividedText.Add(cryptedText);

            string result = null;
            List<string> decryptedText = new List<string>();

            foreach (var item in dividedText)
            {
                char[] dec = new char[key.Length];

                for (int i = 0; i < item.Length; i++)
                    dec[i] = item[key[i]];

                string completeBlock = string.Join("", dec);
                decryptedText.Add(completeBlock);
            }

            result = string.Join("", decryptedText.ToArray());
            Console.WriteLine("Decrypted text: " + result);
        }

        /// <summary>
        /// Generates a random number sequence begining with zero and ending with key length.
        /// </summary>
        /// <param name="keyLength">Desirable key length.</param>
        /// <returns>Randomized non-repetitive key.</returns>
        private int[] KeyGenerator(int keyLength)
        {
            int[] firstKey = new int[keyLength];
            Random rnd = new Random();

            firstKey = Enumerable
                .Range(0, keyLength)
                .OrderBy(x => rnd.Next())
                .ToArray();

            return firstKey;
        }

        /// <summary>
        /// Transforms key to match ASCII sequence.
        /// </summary>
        /// <param name="key">Key</param>
        /// <returns>Transformed key</returns>
        private int[] TransformKey(int[] key)
        {
            for (int i=0; i<key.Length; i++)
            {
                key[i] = key[i] + 33;
            }

            return key;
        }

        /// <summary>
        /// Parses key to a string by ASCII table.
        /// </summary>
        /// <param name="key">Key</param>
        /// <returns>Parsed key</returns>
        private string ParseKeyToString(int[] key)
        {
            char[] symbols = new char[key.Length];
            for (int i = 0; i<key.Length; i++)
            {
                char c = (char)key[i];
                symbols[i] = c;
            }
            string finalKey = string.Join("", symbols);
            return finalKey;
        }

        /// <summary>
        /// Divide text into blocks.
        /// </summary>
        /// <param name="text">Text</param>
        /// <param name="length">Lenght of block</param>
        /// <returns>Text divided into block as a collection</returns>
        private List<string> DivideText(string text, int length)
        {
            List<string> result = new List<string>();
            int stringLength = text.Length;
            int chunkSize = length;

            for (int i = 0; i < stringLength; i += chunkSize)
            {
                if (i + chunkSize > stringLength)
                    chunkSize = stringLength - i;
                result.Add(text.Substring(i, chunkSize));
            }

            return result;
        }

        /// <summary>
        /// Encrypts the text.
        /// </summary>
        /// <param name="list">List of blocks of text</param>
        /// <param name="key">Key to encrypt text by</param>
        /// <returns>Encrypted text</returns>
        private string Encryptor(List<string> list, int[] key)
        {
            string result = null;
            List<string> encryptedText = new List<string>();

            for (int keyCount=0; keyCount<key.Length; keyCount++)
            {
                key[keyCount] = key[keyCount] - 33;
            }

            foreach (var item in list)
            {
                char[] enc = new char[key.Length];

                for (int i=0; i<item.Length; i++)
                    enc[key[i]] = item[i];

                string snakelicious = string.Join("", enc);
                encryptedText.Add(snakelicious);
            }

            result = string.Join("", encryptedText.ToArray());

            return result;
        }
    }
}
