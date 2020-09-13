using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Stack_Hackerank_1
{
    class FractionalKnapSack
    {
        public static void Main6(string[] args)
        {
            Console.WriteLine("Order of Input shall be 1st line to tell weight of knapsack \n 2nd line to tell the total number of weight value pairs \n 3rd line will be space separated weights \n 4th line to be space separated values ");

            int knapsackWeight = Int32.Parse(Console.ReadLine());
            int inputSize = Int32.Parse(Console.ReadLine());

            List<int> weightList = new List<int>();
            List<int> valueList = new List<int>();
            Dictionary<int, double> valuePerUnitWeightList = new Dictionary<int, double>();

            Console.ReadLine().Split(' ').ToList().ForEach(x => weightList.Add(Int32.Parse(x)));
            Console.ReadLine().Split(' ').ToList().ForEach(x => valueList.Add(Int32.Parse(x)));

            for (int i = 0; i < inputSize; i++)
            {
                double valuePerUnitWeight = weightList[i] / valueList[i];
                valuePerUnitWeightList[i] = Math.Round(valuePerUnitWeight, 2);
            }

            valuePerUnitWeightList.OrderBy(x => x.Value);
            List<string> output = new List<string>();

            for (int i = valuePerUnitWeightList.Count-1; i >= 0 ; i--)
            {
                if (knapsackWeight == 0)
                    break;
                else
                {
                    var currentElement = valuePerUnitWeightList.ElementAt(i);
                    int quantity = Min(weightList[currentElement.Key], knapsackWeight);

                    knapsackWeight -= (int)(quantity * currentElement.Value);

                    output.Add($"{quantity} of element at position {currentElement.Key} was taken");
                }
            }

            output.ForEach(x => Console.WriteLine(x));
        }

        private static int Min(int elementWeight, int knapsackWeight)
        {
            return elementWeight<knapsackWeight ? elementWeight : knapsackWeight;
        }
    }
}
