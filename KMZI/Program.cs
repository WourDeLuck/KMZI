using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lab2;
using Lab3;
using Lab5;
using System.Numerics;

namespace KMZI
{
    class Program
    {
        static void Main(string[] args)
        {
            DiffieHellman dh = new DiffieHellman();
            Random rnd = new Random();

            // 1. Alice and Bob generate random 128-bit numbers.
            BigInteger a = dh.GenerateRandomNumber(rnd);
            BigInteger b = dh.GenerateRandomNumber(rnd);
            Console.WriteLine("Alice's secret key: " + a);
            Console.WriteLine("Bob's secret key: " + b);

            // 2a. Also an open prime number P is being generated.
            int p = 340412687;
            Console.WriteLine("Random prime key: " + p);

            // 2b. Another number is being generated which is a primitive root modulo p.
            int g = 7;
            Console.WriteLine("Primitive root: " + g);

            // 3. Alice and Bob generate open keys using open parameters and their numbers.
            BigInteger A = dh.DiscreteExp(g, a, p);
            BigInteger B = dh.DiscreteExp(g, b, p);
            Console.WriteLine("Alice's open key: " + A);
            Console.WriteLine("Bob's open key: " + B);

            // 4. Open keys are being exchanged.

            // 5. Alice and Bob calculate common key using open key of each other and own closed keys.
            BigInteger K1 = dh.DiscreteExp(B, a, p);
            BigInteger K2 = dh.DiscreteExp(A, b, p);

            if (K1 == K2)
                Console.WriteLine("Keys are equal: " + K1 + ", " + K2);

            Console.ReadKey();
        }

        public void DHProtocol()
        {
            DiffieHellman dh = new DiffieHellman();
            Random rnd = new Random();

        }

        public void ShowLab3()
        {
            NumberTheory nt = new NumberTheory();
            long n = 101398751;
            long m = 326147777;

            long firNum = 11;
            long secNum = 24;
            long thiNum = 2001;

            // 1. Найти канонические разложения чисел  m  и  n.
            nt.CanonicalNumberFactorization(n);
            nt.CanonicalNumberFactorization(m);

            // 2а. Найти НОД используя алгоритм Эвклида.
            var euclRes = nt.GCD_Euclid(n, m);
            Console.WriteLine("GCD Euclid: " + euclRes);

            // 2б. Найти НОД используя разложение чисел на простые множители.
            var gcdRes = nt.GCD_Simple(n, m);
            Console.WriteLine("Simple GCD: " + gcdRes);

            // 3. С помощью расширенного алгоритма Евклида найти целые a, b, удовлетворяющие соотношению Безу.
            nt.GCD_EuclidExtended(n, m);

            // 4. Вычислить функцию Эйлера для k,n,m.
            nt.Enter_EulerFunction(firNum);
            nt.Enter_EulerFunction(secNum);
            nt.Enter_EulerFunction(thiNum);

            // 5. В кольцах  Z/kZ и Z/nZ найти пары взаимно обратных по умножению элементов.
            nt.VersaCouples(firNum);
            nt.VersaCouples(thiNum);

            // 6. В кольце Z/mZ найти обратные к элементам 5, 6, 7.
            nt.VersaCouples_V2();

            Console.ReadKey();
        }
      
    }
}
