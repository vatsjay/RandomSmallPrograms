using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Stack_Hackerank_1
{
    class QuickSort
    {
        public static void Main1(string[] args)
        {
            List<int> inputList = new List<int>();
            Console.ReadLine().Split(" ").ToList().ForEach(x => inputList.Add(Int32.Parse(x)));

            DoAQuickSort(inputList, 0, inputList.Count);

            Console.WriteLine("The sorted array is");
            inputList.ForEach(x => Console.Write($"{x} "));
        }

        private static void DoAQuickSort(List<int> inputList, int lowerBound, int upperBound)
        {
            if (lowerBound >= upperBound)
                return;
            else
            {
                int pivot = inputList[lowerBound];
                int tempLowerBound = lowerBound;
                for (int i = lowerBound + 1; i < upperBound; i++)
                {
                    if (inputList[i] < pivot)
                    {
                        tempLowerBound++;
                        if(i != tempLowerBound)
                            swap(inputList, tempLowerBound, i);
                    }
                }
                swap(inputList, lowerBound, tempLowerBound);
                DoAQuickSort(inputList, lowerBound, tempLowerBound);
                DoAQuickSort(inputList, tempLowerBound + 1, upperBound);
            }
        }

        private static void swap(List<int> inputList, int firstIndex, int minIndex)
        {
            int temp = inputList[firstIndex];
            inputList[firstIndex] = inputList[minIndex];
            inputList[minIndex] = temp;
        }
    }
}
