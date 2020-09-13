using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Stack_Hackerank_1
{
    class MaxNumberFromInputDigits
    {
        public static void Main5(string[] args)
        {
            List<int> inputList = new List<int>();
            Console.ReadLine().Split(' ').ToList().ForEach(x => inputList.Add(Int32.Parse(x)));

            string output = String.Empty;

            inputList.Sort();
            inputList.Reverse();
            inputList.ForEach(x => output += x.ToString());

            Console.WriteLine(long.Parse(output));
        }
    }
}
