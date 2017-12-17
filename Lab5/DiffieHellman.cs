using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;


namespace Lab5
{
    /// <summary>
    /// Diffie-Hellman protocol.
    /// </summary>
    public class DiffieHellman
    {
        /// <summary>
        /// Generates a random 128-bit number.
        /// </summary>
        /// <returns>Random number</returns>
        public BigInteger GenerateRandomNumber(Random rnd)
        {
            int[] intArrays = new int[39];

            for (int i = 0; i < intArrays.Length; i++)
            {
                intArrays[i] = rnd.Next(0, 9);
            }

            string parsedNumber = string.Join("", intArrays);
            BigInteger number = BigInteger.Parse(parsedNumber);
            return number;
        }

        /// <summary>
        /// Discrete exponentiation.
        /// </summary>
        /// <param name="number">Open root primitive.</param>
        /// <param name="degree">Generated big integer.</param>
        /// <param name="module">Open random prime number.</param>
        /// <returns>Remainder of the division.</returns>
        public BigInteger DiscreteExp(BigInteger number, BigInteger degree, int module)
        {
            return BigInteger.ModPow(number, degree, module);
        }

    }
}
