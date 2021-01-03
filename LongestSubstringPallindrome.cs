using System;
using System.Collections.Generic;
using System.Text;

namespace Stack_Hackerank_1
{
    class LongestSubstringPallindrome
    {
        public static void Main1(string[] args)
        {
            string input = Console.ReadLine();

            printLongestPallindromeSubstring(input);
        }

        private static void printLongestPallindromeSubstring(string  inputString)
        {
            int lenghtOfInputString = inputString.Length;

            bool[,] memoryTable = new bool[lenghtOfInputString, lenghtOfInputString];

            for (int i = 0; i < lenghtOfInputString; i++)
            {
                memoryTable[i, i] = true;
            }

            int maxPallindromeSubStringLength = 1;
            int startIndex = 0;

            for (int i = 0; i < lenghtOfInputString-1; i++)
            {
                if(inputString[i] == inputString[i+1])
                {
                    memoryTable[i, i + 1] = true;
                    startIndex = i;
                    maxPallindromeSubStringLength = 2;
                }
            }

            for (int subStringLength = 3; subStringLength < lenghtOfInputString; subStringLength++)
            {
                for (int j = 0; j < lenghtOfInputString-subStringLength+1; j++)
                {
                    int endIndex = subStringLength + j - 1;

                    if(memoryTable[j+1, endIndex-1] && inputString[j] == inputString[endIndex])
                    {
                        memoryTable[j, endIndex] = true;

                        if(subStringLength > maxPallindromeSubStringLength)
                        {
                            maxPallindromeSubStringLength = subStringLength;
                            startIndex = j;
                        }
                    }
                }
            }

            Console.WriteLine(inputString.Substring(startIndex, maxPallindromeSubStringLength));
        }
    }
}
