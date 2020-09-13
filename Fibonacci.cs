using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace Stack_Hackerank_1
{
    class Fibonacci
    {
        public static void Main3(string[] args)
        {
            int input = Int32.Parse(Console.ReadLine());
            Random rand = new Random();
            while (true)
            {
                Stopwatch s = new Stopwatch();
                input = rand.Next(0, 500);
                s.Start();

                //long res1 = recursiveFibonacci(input);
                //Console.WriteLine(s.ElapsedMilliseconds);
                long res2 = fastFibonacci(input);
                

                //Console.WriteLine($"Fibonacci for {input} is {res1}");
                Console.WriteLine($"Fibonacci for {input} is {res2}");

                //if (res1 != res2)
                  //  break;
                s.Stop();
                Console.WriteLine(s.ElapsedMilliseconds);
            }
        }

        private static int recursiveFibonacci(int input)
        {
            if (input <= 1)
                return input;
            else
                return (recursiveFibonacci(input - 1) + recursiveFibonacci(input - 2));
        }

        private static long fastFibonacci(int number)
        {
            if (number <= 1)
                return number;
            else
            {
                long first = 0;
                long second = 1;
                long fibonacci = 0;

                for (int i = 2; i <= number; i++)
                {
                    fibonacci = first + second;
                    first = second;
                    second = fibonacci;
                }

                return fibonacci;
            }
        }
    }
}
