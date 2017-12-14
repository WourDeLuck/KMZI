using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lab2;
using Lab3;

namespace KMZI
{
    class Program
    {
        static void Main(string[] args)
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
