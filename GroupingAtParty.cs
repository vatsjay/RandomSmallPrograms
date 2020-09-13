using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Stack_Hackerank_1
{
    class GroupingAtParty
    {
        public static void Main6(string[] args)
        {
            List<double> inputList = new List<double>();
            Console.ReadLine().Split(' ').ToList().ForEach(x => inputList.Add(double.Parse(x)));

            inputList.Sort();

            int startIndex = 0;
            List<string> groups = new List<string>();

            while (startIndex < inputList.Count)
            {
                string group = String.Empty;
                double endGroupIndicator = inputList.ElementAt(startIndex) + 1;

                group += inputList.ElementAt(startIndex).ToString() + " ";
                startIndex++;
                while ((startIndex < inputList.Count) && (inputList.ElementAt(startIndex) <= endGroupIndicator))
                {
                    group += inputList.ElementAt(startIndex).ToString() + " ";
                    startIndex++;
                }

                group += "\t";
                groups.Add(group);
            }

            Console.WriteLine($"Then number of groups is {groups.Count} \n the groups are : ");
            groups.ForEach(x => Console.Write(x));
        }
    }
}
