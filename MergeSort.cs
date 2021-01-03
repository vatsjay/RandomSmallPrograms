using System;
using System.Collections.Generic;
using System.Linq;

namespace Stack_Hackerank_1
{
    class MergeSort
    {
        public static void Main1(string[] args)
        {
            List<int> inputList = new List<int>();
            Console.ReadLine().Split(" ").ToList().ForEach(x => inputList.Add(Int32.Parse(x)));

            inputList = DoAMergeSort(inputList);

            Console.WriteLine("The sorted array is");
            inputList.ForEach(x => Console.Write($"{x} "));
        }

        private static List<int> DoAMergeSort(List<int> inputList)
        {
            if (inputList.Count == 1)
            { return inputList; }

            else
            {
                int mid = inputList.Count / 2;
                List<int> sortedFirstHalfList = DoAMergeSort(inputList.Take(mid).ToList());
                List<int> sortedSecondHalfList = DoAMergeSort(inputList.Skip(mid).Take(inputList.Count - mid).ToList());

                return MergeByArray(sortedFirstHalfList.ToArray(), sortedSecondHalfList.ToArray()).ToList();
            }
        }

        private static List<int> MergeByList(List<int> sortedFirstHalfList, List<int> sortedSecondHalfList)
        {
            List<int> returnList = new List<int>();

            while (sortedFirstHalfList.Count > 0 && sortedSecondHalfList.Count > 0)
            {
                if (sortedFirstHalfList[0] < sortedSecondHalfList[0])
                {
                    returnList.Add(sortedFirstHalfList[0]);
                    sortedFirstHalfList.RemoveAt(0);
                }
                else
                {
                    returnList.Add(sortedSecondHalfList[0]);
                    sortedSecondHalfList.RemoveAt(0);
                }
            }

            returnList.AddRange(sortedFirstHalfList);
            returnList.AddRange(sortedSecondHalfList);

            return returnList;
        }

        private static int[] MergeByArray(int[] firstInput, int[] secondInput)
        {
            int firstArrayIndex = 0;
            int secondArrayIndex = 0;
            int resultArrayIndex = 0;
            int[] resultArray = new int[firstInput.Length + secondInput.Length];

            while (firstArrayIndex < firstInput.Length && secondArrayIndex < secondInput.Length)
            {
                if (firstInput[firstArrayIndex] < secondInput[secondArrayIndex])
                {
                    resultArray[resultArrayIndex] = firstInput[firstArrayIndex];
                    firstArrayIndex++;
                    resultArrayIndex++;
                }
                else
                {
                    resultArray[resultArrayIndex] = secondInput[secondArrayIndex];
                    secondArrayIndex++;
                    resultArrayIndex++;
                }
            }

            if (firstArrayIndex < firstInput.Length)
            {
                for (int i = firstArrayIndex; i < firstInput.Length; i++)
                {
                    resultArray[resultArrayIndex] = firstInput[firstArrayIndex];
                    firstArrayIndex++;
                    resultArrayIndex++;
                }
            }
            else
            {
                for (int i = secondArrayIndex; i < (secondInput.Length); i++)
                {
                    resultArray[resultArrayIndex] = secondInput[secondArrayIndex];
                    secondArrayIndex++;
                    resultArrayIndex++;
                }
            }

            return resultArray;
        }
        }
    }
