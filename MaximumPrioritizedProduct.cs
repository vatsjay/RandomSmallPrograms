using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Stack_Hackerank_1
{
    class MaximumPrioritizedProduct
    {
        public static void Main2(string[] args)
        {
            while (true)
            {
                Random random = new Random();
                long length = random.Next(2, 1500);

                long[] inputArray = new long[length];
                for (long j = 0; j < inputArray.Length; j++)
                {
                    inputArray[j] = random.Next(0, 111111111);
                }

                long res1 = getMaxPairwiseProduct(inputArray);
                long res2 = getMaxPairwiseProductBruteForce(inputArray);
                Console.WriteLine($"Results are res1: {res1} res2 {res2}");

                if (res1 != res2)
                {
                    Console.WriteLine($"wrong answer for length {length} input array : ");
                    inputArray.ToList().ForEach(x => Console.Write($" {x} "));
                    break;
                }

                Console.WriteLine("Correct answer");
            }

            long lengthOfInputArray = long.Parse(Console.ReadLine());
            long[] inputList = new long[lengthOfInputArray];

            if (lengthOfInputArray < 2)
            {
                Console.WriteLine("Please input at least two numbers");
                Main2(null);
            }
            long i = 0;
            Console.ReadLine().Split(' ').ToList().ForEach(x => inputList[i++]= long.Parse(x));

            Console.WriteLine($"Maximum pairwise product of the numbers in array is : {getMaxPairwiseProduct(inputList)}");
        }

        private static long getMaxPairwiseProduct(long[] inputList)
        {
            long secondMaxInput;
            long maxInput = getMaxAndSecondMaxFromArray(inputList, out secondMaxInput);

            return maxInput * secondMaxInput;
        }

        private static long getMaxAndSecondMaxFromArray(long[] inputList, out long secondMaxInput)
        {
            long maxNumber = long.MinValue;
            secondMaxInput = long.MinValue;
            long maxIndex = -1;

            for (long i = 0; i < inputList.Length; i++)
            {
                if (inputList[i] >= maxNumber)
                {
                    secondMaxInput = maxNumber;
                    maxNumber = inputList[i];
                    maxIndex = i;
                }
                else if (inputList[i] >= secondMaxInput && i != maxIndex)
                    secondMaxInput = inputList[i];
            }
            
            return maxNumber;
        }

            
        private static long getMaxPairwiseProductBruteForce(long[] inputArray)
        {
            long maxProduct = long.MinValue;

            for (long i = 0; i < inputArray.Length; i++)
            {
                for (long j = i+1; j < inputArray.Length; j++)
                {
                    if (inputArray[i] * inputArray[j] > maxProduct)
                        maxProduct = inputArray[i] * inputArray[j];
                }
            }

            return maxProduct;
        }
    }
}
