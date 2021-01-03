using System;
using System.Collections.Generic;
using System.Text;

namespace Stack_Hackerank_1
{
    class StringPermutations
    {
        public static void Main1(string[] args)
        {
            Console.Write("Enter the word to get all permutations : ");
            var inputString = Console.ReadLine();

            permuteString(inputString.ToCharArray(), 0, inputString.Length - 1);
            Console.WriteLine(count);

            Console.Write("want to test another problem : ");
            var repeat = Console.ReadLine();
            if (repeat == "Yes" || repeat == "yes")
                Main1(new string[1]);
        }
        static int count = 0;
        private static void permuteString(char[] inputCharArr, int start, int end)
        {
            if (start == end)
            {
                Console.WriteLine(String.Join("", inputCharArr));
                count++;
            }
            else
            {
                for (int i = start; i <= end; i++)
                {
                    inputCharArr = swap(inputCharArr, i, start);
                    permuteString(inputCharArr, start + 1, end);
                    inputCharArr = swap(inputCharArr, i, start);
                }
            }
        }

        private static char[] swap(char[] inputCharArr, int i, int start)
        {
            char temp = inputCharArr[i];
            inputCharArr[i] = inputCharArr[start];
            inputCharArr[start] = temp;
            return inputCharArr;
        }
    }
}
