using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Stack_Hackerank_1
{
    class SelectionSort
    {
        public static void Main1(string[] args)
        {
            List<int> inputList = new List<int>();
            Console.ReadLine().Split(" ").ToList().ForEach(x => inputList.Add(Int32.Parse(x)));

            DoASelectionSort(inputList);

            Console.WriteLine("The sorted array is : ");
            inputList.ForEach(x => Console.Write($"{x} "));

            Main1(new string[1]);
        }

        private static void DoASelectionSort(List<int> inputList)
        {
            for (int i = 0; i < inputList.Count; i++)
            {
                int minIndex = -1;
                int minNumber = int.MaxValue;

                for (int j = i; j < inputList.Count; j++)
                {
                    if (inputList[j] < minNumber)
                    {
                        minNumber = inputList[j];
                        minIndex = j;
                    }
                }

                swap(i, minIndex, inputList);
            }
        }

        private static void swap(int firstIndex, int minIndex, List<int> inputList)
        {
            int temp = inputList[firstIndex];
            inputList[firstIndex] = inputList[minIndex];
            inputList[minIndex] = temp;
        }
    }
}
