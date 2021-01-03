using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Stack_Hackerank_1
{
    class KnapSack
    {
        public static void Main1(string[] args)
        {
            Console.Write("Enter the length of array : "); //5, 3
            int inputLength = Int32.Parse(Console.ReadLine());

            Console.Write("Enter the weight of bag : "); //5, 50
            int weightOfBag = Int32.Parse(Console.ReadLine());

            Console.WriteLine("Enter space separated weights : "); // [1, 2, 5, 6, 7] [10, 20, 30]

            int[] weightArray = new int[inputLength];
            int[] valueArray = new int[inputLength];
            
            var weightInput = Console.ReadLine().Split(" ");
            Console.WriteLine("Enter space separated respective values : "); // [1, 6, 18, 22, 28] [60, 100, 120]

            var valueInput = Console.ReadLine().Split(" ");

            for (int i = 0; i < inputLength; i++)
            {
                weightArray[i] = Int32.Parse(weightInput[i]);
                valueArray[i] = Int32.Parse(valueInput[i]);
            }

            // 40, 220
            Console.WriteLine($"Maximum profit for the given scenario is {RecursiveKnapsack(weightArray, valueArray, weightOfBag, inputLength)}");

            int[] memoryArray = new int[inputLength];
            memoryArray[0] = 0;
            for (int i = 1; i < inputLength; i++)
            {
                memoryArray[i] = -1;
            }

            Console.WriteLine($"Maximum profit for the given scenario with memodized array is {MemodisedRecursionKnapsack(memoryArray, weightArray, valueArray, weightOfBag, inputLength)}");

            Console.WriteLine($"Maximum profit for the given scenario with dynamic programming is {DynamicKnapsack(weightArray, valueArray, weightOfBag, inputLength)}");

            Console.WriteLine($"Maximum profit for the given scenario with dynamic programming from geeksforgeeks is {knapSack(weightOfBag, weightArray, valueArray, inputLength)}");

            Console.Write("want to test another problem : ");
            var repeat = Console.ReadLine();
            if(repeat == "Yes" || repeat == "yes")
                Main1(new string[1]);
        }

        private static int RecursiveKnapsack(int[] weightArray, int[] valueArray, int totalWeight, int length)
        {
            if (totalWeight == 0 || length == 0)
                return 0;
            else
            {
                if (weightArray[length - 1] <= totalWeight)
                    return Max((valueArray[length - 1] + RecursiveKnapsack(weightArray, valueArray, totalWeight - weightArray[length - 1], length - 1))
                        , RecursiveKnapsack(weightArray, valueArray, totalWeight, length - 1));
                else
                    return RecursiveKnapsack(weightArray, valueArray, totalWeight, length - 1);
            }
        }

        private static int Max(int firstNumber, int secondNumber)
        {
            return (firstNumber >= secondNumber) ? firstNumber : secondNumber;
        }

        private static int MemodisedRecursionKnapsack(int[] memoryArray, int[] weightArray, int[] valueArray, int totalWeight, int length)
        {
            if (length == 0 || totalWeight == 0)
                return memoryArray[0];
            else
            {
                if (memoryArray[length - 1] == -1)
                {
                    if (weightArray[length - 1] <= totalWeight)
                        return memoryArray[length - 1] = Max((valueArray[length - 1] + MemodisedRecursionKnapsack(memoryArray, weightArray, valueArray, totalWeight - weightArray[length - 1], length - 1))
                            , MemodisedRecursionKnapsack(memoryArray, weightArray, valueArray, totalWeight, length - 1));
                    else
                        return memoryArray[length - 1] = MemodisedRecursionKnapsack(memoryArray, weightArray, valueArray, totalWeight, length - 1);
                }
                else
                    return memoryArray[length - 1];
            }
        }

        private static int DynamicKnapsack(int[] weightArray, int[] valueArray, int weight, int length)
        {
            int[,] resultArray = new int[length + 1, weight+ 1];
            for (int i = 0; i <= length; i++)
            {
                for (int j = 0; j <= weight; j++)
                {
                    if (i == 0 || j == 0)
                        resultArray[i, j] = 0;
                    else if (weightArray[i - 1] <= j)
                    {
                        resultArray[i, j] = Max(valueArray[i - 1] + resultArray[i - 1, j - weightArray[i - 1]], resultArray[i - 1, j]);
                    }
                    else
                        resultArray[i, j] = resultArray[i - 1, j];
                }
            }

            return resultArray[length, weight];
        }

        static int knapSack(int W, int[] wt,
                        int[] val, int n)
        {
            int i, w;
            int[,] K = new int[n + 1, W + 1];

            // Build table K[][] in bottom 
            // up manner 
            for (i = 0; i <= n; i++)
            {
                for (w = 0; w <= W; w++)
                {
                    if (i == 0 || w == 0)
                        K[i, w] = 0;
                    else if (wt[i - 1] <= w)
                        K[i, w] = Math.Max(
                            val[i - 1]
                                + K[i - 1, w - wt[i - 1]],
                            K[i - 1, w]);
                    else
                        K[i, w] = K[i - 1, w];
                }
            }

            return K[n, W];
        }
    }
}