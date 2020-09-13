using System;

namespace Stack_Hackerank_1
{
    class GCD
    {
        public static void Main4(string[] args)
        {
            int input1 = Int32.Parse(Console.ReadLine());
            int input2 = Int32.Parse(Console.ReadLine());

            Console.WriteLine(getGCD(input1, input2));
        }

        private static int getGCD(int input1, int input2)
        {
            if (input2 == 0)
                return input1;
            else
                return getGCD(input2, (input1 % input2));
        }
    }
}
