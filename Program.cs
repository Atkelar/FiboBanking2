using System;
using System.Collections.Generic;

namespace FibonacciBanking
{
    class Program
    {
        private const int targetAmount = 1000000;

        static void Main(string[] args)
        {
            int a, b;
            a = 1;
            b = 1;
            List<Tuple<int, int>> fibos = new List<Tuple<int, int>>();
            while (a + b < targetAmount)
            {
                int next = a + b;
                fibos.Add(new Tuple<int, int>(a, b));
                Console.WriteLine("Fibonacci Pair: f1={0} + f2={1} = {2}", a, b, next);
                a = b;
                b = next;
            }

            Tuple<int, int> result = null;
            // there are countless(almost) possibilities for the 1,1 case, so skip that.
            for (int i = fibos.Count - 1; i > 1; i--)
            {
                result = SolveForStep(i, fibos[i].Item1, fibos[i].Item2);
                if (result != null)
                    break;
            }

            int checkA = a = result.Item1;
            int checkB = b = result.Item2;

            int count = 2;
            Console.WriteLine("Day 1: {0}", a);
            while (b <= targetAmount)
            {
                Console.WriteLine("Day {0} : {1}", count, b);
                int next = a + b;
                a = b;
                b = next;
                count++;
            }

            // this is when day 1 is NOT added to day 2 however! So we need to subtract original A from original B
            Console.WriteLine("Solution: deposit {0} and {1}, reach {3} in {2} days", checkA, checkB - checkA, count - 1, targetAmount);
        }

        private static Tuple<int, int> SolveForStep(int i, int f1, int f2)
        {
            Console.Write("Trying for step {0} ({1},{2}) ", i, f1, f2);
            int count = 0;
            int maxA = targetAmount / f1 - f2;   // no need to search beyond that.  We have to assume "0" is not a valid deposit!
            int a = 1;
            Tuple<int, int> found = null;
            while (a < maxA)
            {
                int b = 1;
                int result;
                do
                {
                    result = f1 * a + f2 * b;
                    if (result == targetAmount)
                    {
                        count++;
                        if (count == 1)
                        {
                            Console.WriteLine();
                            found = new Tuple<int, int>(a, b);
                        }
                        Console.WriteLine("  Found solution for {0} and {1}", a, b);
                    }
                    b++;
                } while (result < targetAmount);
                a++;
            }
            if (count == 0)
                Console.WriteLine("no solution.");
            else
                Console.WriteLine("...found {0} solutions!", count);
            return found;
        }
    }
}
