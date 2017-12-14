using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3
{
    /// <summary>
    /// Basic Number theory operations.
    /// </summary>
    public class NumberTheory
    {
        /// <summary>
        /// Canonical number factorization
        /// </summary>
        /// <param name="number"></param>
        public void CanonicalNumberFactorization(long number)
        {
            var result = Factorization(number);
            string stringResult = string.Join(" ", result.ToArray());
            Console.WriteLine("Prime factory of {0}: " + stringResult, number);
        }

        /// <summary>
        /// Number factorization process.
        /// </summary>
        /// <param name="number">Number to operate with.</param>
        private List<int> Factorization(long number)
        {
            List<int> sList = new List<int>();
            long temp = 1;
            for (int i = 2; i <= number; i++)
            {
                if ((number % i) == 0)
                {
                    temp = number / i;
                    sList.Add(i);
                    i = 1;
                    number = temp;
                }
            }
            return sList;        
        }

        /// <summary>
        /// GCD Euclid algorithm.
        /// </summary>
        /// <param name="num1">First number.</param>
        /// <param name="num2">Second number.</param>
        /// <returns></returns>
        public long GCD_Euclid(long num1, long num2)
        {
            long highest = Math.Max(num1, num2);
            long lowest = Math.Min(num1, num2);
            long temp = 0;

            if (highest % lowest == 0)
                return lowest;
            else
            {
                temp = highest % lowest;
                highest = lowest;
                lowest = temp;
                return GCD_Euclid(highest, lowest);
            }
        }

        /// <summary>
        /// Simple GCD.
        /// </summary>
        /// <param name="num1">First number.</param>
        /// <param name="num2">Second number.</param>
        /// <returns>GCD</returns>
        public int GCD_Simple(long num1, long num2)
        {
            var firstNumberFac = Factorization(num1);
            var secondNumberFac = Factorization(num2);

            var duplicates = firstNumberFac
                .Where(x => secondNumberFac.Any(y => x.Equals(y)));

            var gcd = duplicates.Max();
            return gcd;
        }

        /// <summary>
        /// Extended Euclidean Algoritm.
        /// </summary>
        /// <param name="num1">First number</param>
        /// <param name="num2">Second number</param>
        public void GCD_EuclidExtended(long num1, long num2)
        {
            // a*num1 + b*num2 = NOD(num1, num2)

            var result = EuclidExtended(num1, num2, out long x, out long y);
            Console.WriteLine("GCD({0}, {1}): " + result, num1, num2);
            Console.WriteLine("Number a: " + x);
            Console.WriteLine("Number b: " + y);

        }

        /// <summary>
        /// Calculates the numbers.
        /// </summary>
        /// <param name="a">First number</param>
        /// <param name="b">Second number</param>
        /// <param name="x">First number parameter</param>
        /// <param name="y">Sexond number parameter</param>
        /// <returns>GCD of two numbers.</returns>
        private long EuclidExtended(long a, long b, out long x, out long y)
        {
            if (a==0)
            {
                x = 0;
                y = 1;
                return b;
            }

            long d = EuclidExtended(b % a, a, out long x1, out long y1);
            x = y1 - (b / a) * x1;
            y = x1;
            return d;
        }

        /// <summary>
        /// Counts the function of Euler.
        /// </summary>
        /// <param name="number">Number to operate with.</param>
        public void Enter_EulerFunction(long number)
        {
            var result = EulerFunction(number);
            Console.WriteLine("Euler Function of number {0}: " + result, number);
        }

        /// <summary>
        /// Counts the function of Euler.
        /// </summary>
        /// <param name="number">Number to operate with.</param>
        /// <returns>Function of Euler.</returns>
        private double EulerFunction(long number)
        {

            // if number is prime
            if(IsPrime(number))
            {
                return number - 1;
            }
            else
            {
                var list = Factorization(number);
                var distinct = list.Distinct().ToList();
                double helpy = number;
                double resultOfMultiply = 1;

                foreach (var item in distinct)
                {
                    double val = item;
                    resultOfMultiply = resultOfMultiply * (1 - (1 / val)) ;
                }
                return resultOfMultiply * helpy;
            }
        }

        /// <summary>
        /// Checks if number is prime.
        /// </summary>
        /// <param name="number">Number to check</param>
        /// <returns>True if number is prime.</returns>
        private bool IsPrime(long number)
        {
            var list = Factorization(number);
            if (list.Max() == number)
                return true;
            else return false;
        }

        /// <summary>
        /// Finds the vice versa couples of numbers.
        /// </summary>
        /// <param name="number"></param>
        public void VersaCouples(long number)
        {
            long n = 2 * number;
            long[] arr = new long[n];

            for (int i = 0; i<number; i++)
                for (int j = 0; j<number; j++)
                {
                    if ((i * j) % number == 1)
                        Console.WriteLine(i + " * " + j + " = 1 (mod {0})", number);
                }
        }

        /// <summary>
        /// Finds the vice versa couples of numbers using 5, 6, 7.
        /// </summary>
        public void VersaCouples_V2()
        {
            int number = 2001;

            for (int i=0; i<number; i++)
            {
                if ((5 * i) % number == 1)
                    Console.WriteLine(5 + " * " + i + " = 1 (mod {0})", number);
            }

            for (int i = 0; i < number; i++)
            {
                if ((6 * i) % number == 1)
                    Console.WriteLine(6 + " * " + i + " = 1 (mod {0})", number);
            }

            for (int i = 0; i < number; i++)
            {
                if ((7 * i) % number == 1)
                    Console.WriteLine(7 + " * " + i + " = 1 (mod {0})", number);
            }

        }
    }
}
