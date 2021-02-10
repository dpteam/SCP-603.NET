using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace SCP603Sim
{
    class Program
    {
        public static bool Survived = true;
        public static List<int> primes = new List<int>();
        public static List<int> GeneratePrimesNaive(int n)
        {
            primes.Add(2);
            int nextPrime = 3;
            while (primes.Count < n)
            {
                int sqrt = (int)Math.Sqrt(nextPrime);
                bool isPrime = true;
                for (int i = 0; (int)primes[i] <= sqrt; i++)
                {
                    if (nextPrime % primes[i] == 0)
                    {
                        isPrime = false;
                        break;
                    }
                }
                if (isPrime)
                {
                    primes.Add(nextPrime);
                }
                nextPrime += 2;
            }
            return primes;
        }

        public static bool IsPrime(int number)
        {
            if (number <= 1) return false;
            if (number == 2) return true;
            if (number % 2 == 0) return false;

            var boundary = (int)Math.Floor(Math.Sqrt(number));

            for (int i = 3; i <= boundary; i += 2)
                if (number % i == 0)
                    return false;

            return true;
        }

        public static void Main(string[] args) {
            if (Survived == false)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Kernel Panic");
                Console.WriteLine("0xFFFFFFFF: No CRC[Code-Reproduction-Code]");
            }
            else
            {
                var a = GeneratePrimesNaive(Int16.MaxValue);
                while (IsPrime(a[0]))
                {
                    Console.WriteLine(String.Join("\n", a));
                    Thread.Sleep(30000);
                }
            }
            Console.ResetColor();
            Console.ReadKey();
        }
	}
}