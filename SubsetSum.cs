using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Stack_Hackerank_1
{
    public static class SubsetSum
    {
        public static void Main1(string[] args)
        {
            List<int> one = new List<int>() { 1, 2, 3, 4, 5, 6, 5, 4 };
            var oneZip = one.Zip(new List<bool>() { false, true, false, false, true });


            List<KeyValuePair<int, bool>> two = new List<KeyValuePair<int, bool>>();
            one.ForEach(x => { two.Add(new KeyValuePair<int, bool>(x, false)); });
        }
    }
}
