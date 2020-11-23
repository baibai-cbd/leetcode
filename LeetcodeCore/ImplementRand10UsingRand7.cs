using System;
using System.Collections.Generic;
using System.Text;

namespace LeetcodeCore
{
    public class ImplementRand10UsingRand7
    {
        // 470. Implement Rand10() Using Rand7()
        public int Rand10()
        {
            var dict = new Dictionary<Tuple<int, int>, int>();
            dict.Add(new Tuple<int, int>(1, 2), 1);
            dict.Add(new Tuple<int, int>(1, 3), 2);
            dict.Add(new Tuple<int, int>(1, 4), 3);
            dict.Add(new Tuple<int, int>(1, 5), 4);
            dict.Add(new Tuple<int, int>(1, 6), 5);
            dict.Add(new Tuple<int, int>(1, 7), 6);
            dict.Add(new Tuple<int, int>(2, 3), 7);
            dict.Add(new Tuple<int, int>(2, 4), 8);
            dict.Add(new Tuple<int, int>(2, 5), 9);
            dict.Add(new Tuple<int, int>(2, 6), 10);

            var tuple = new Tuple<int, int>(Rand7(), Rand7());
            while (!dict.ContainsKey(tuple))
            {
                tuple = new Tuple<int, int>(Rand7(), Rand7());
            }

            return dict.GetValueOrDefault(tuple);
        }

        private int Rand7()
        {
            throw new NotImplementedException();
        }


        public int Rand10Another()
        {
            int result = 40;
            while (result >= 40) { result = 7 * (Rand7() - 1) + (Rand7() - 1); }
            return result % 10 + 1;
        }
    }
}
