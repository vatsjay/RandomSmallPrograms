using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Stack_Hackerank_1
{
    class BinarySearch
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Input format : input the number to search and in the next line input space separated random numbers");
            int numberToSearch = Int32.Parse(Console.ReadLine());
            List<int> inputList = new List<int>();
            Console.ReadLine().Split(' ').ToList().ForEach(x => inputList.Add(Int32.Parse(x)));

            inputList.Sort();

            Console.WriteLine($"the position of key using recursive algo is (zero based index) : {recursiveBinarySearch(numberToSearch, inputList, 0, inputList.Count)}");
            Console.WriteLine($"the result using recursive algo is (zero based index) : {iterativeBinarySearch(numberToSearch, inputList, 0, inputList.Count)}");
        }

        private static int recursiveBinarySearch(int key, List<int> inputList, int searchFrom, int searchTill)
        {
            if (searchFrom > searchTill)
                return searchFrom - 1;

            int mid = (int)Math.Floor((double)(searchTill - searchFrom) / 2);
            if (inputList[mid] == key)
                return mid;
            else if (inputList[mid] > key)
            {
                return recursiveBinarySearch(key, inputList, mid + 1, searchTill);
            }
            else
            {
                return recursiveBinarySearch(key, inputList, searchFrom, mid - 1);
            }

        }

        private static int iterativeBinarySearch(int key, List<int> inputList, int searchFrom, int searchTill)
        {
            while (searchFrom < searchTill)
            {
                int mid = (int)Math.Floor((double)(searchTill - searchFrom) / 2);
                
                if (inputList[mid] == key)
                    return mid;
                else if (inputList[mid] > key)
                {
                    searchFrom = mid + 1;
                }
                else
                {
                    searchTill = mid - 1;
                }
            }

            return -1;
        }
    }
}
