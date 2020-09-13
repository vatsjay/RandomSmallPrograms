using System;

namespace Stack_Hackerank_1
{
    class Program
    {
        public static void Main1(string[] args)
        {
            int numberOfTestCases = Int32.Parse(Console.ReadLine());
            while (numberOfTestCases-- > 0)
            {
                string inputString = Console.ReadLine();

                Console.WriteLine(getResultantString(inputString));
            }
        }

        private static string getResultantString(string input)
        {
            if (input.Length == 0)
            {
                return "KHALI";
            }
            char[] inputCharArr = input.ToCharArray();
            int maxEvenSubArrayLength = 0;
            int maxEvenSubArrayLengthStartIndex = 0;
            int tempMaxEvenSubArrayLength = 1;
            char previousChar = inputCharArr[0];

            for (int i = 1; i < inputCharArr.Length; i++)
            {
                if (previousChar == inputCharArr[i])
                {
                    tempMaxEvenSubArrayLength++;
                }
                else
                {
                    if (tempMaxEvenSubArrayLength > maxEvenSubArrayLength)
                    {
                        maxEvenSubArrayLength = tempMaxEvenSubArrayLength % 2 == 0 ? tempMaxEvenSubArrayLength : tempMaxEvenSubArrayLength - 1;
                        maxEvenSubArrayLengthStartIndex = i - tempMaxEvenSubArrayLength;
                    }
                    previousChar = inputCharArr[i];
                    tempMaxEvenSubArrayLength = 1;
                }
            }
            if (tempMaxEvenSubArrayLength > maxEvenSubArrayLength)
            {
                maxEvenSubArrayLength = tempMaxEvenSubArrayLength % 2 == 0 ? tempMaxEvenSubArrayLength : tempMaxEvenSubArrayLength - 1;
                maxEvenSubArrayLengthStartIndex = input.Length - tempMaxEvenSubArrayLength;
            }
            if (maxEvenSubArrayLength > 0)
                return getResultantString(input.Remove(maxEvenSubArrayLengthStartIndex, maxEvenSubArrayLength));
            else
                return input;
        }
    }
}
