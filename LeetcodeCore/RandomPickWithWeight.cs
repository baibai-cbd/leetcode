using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetcodeCore
{
    public class RandomPickWithWeight
    {
        // 528. Random Pick with Weight
        // This problem ties to binary search returns negative specific index when not found
        private double[] probs;

        public RandomPickWithWeight(int[] w)
        {
            double sum = 0;
            probs = new double[w.Length];
            foreach (var item in w)
                sum += item;
            for (int i = 0; i < w.Length; i++)
            {
                w[i] += (i == 0) ? 0 : w[i - 1];
                probs[i] = w[i] / sum;
            }
        }

        public int PickIndex()
        {
            var rand = new Random();
            return Math.Abs(Array.BinarySearch(probs, rand.NextDouble())) - 1;
        }
    }

    // solution with usage of int only
    public class RandomPickWithWeight2
    {

        public int[] _aggr;
        public int _sum;
        public Random _rand;

        public RandomPickWithWeight2(int[] w)
        {
            _sum = 0;
            _aggr = new int[w.Length];
            _rand = new Random();
            for (int i = 0; i < w.Length; i++)
            {
                _sum += w[i];
                _aggr[i] = _sum;
            }
        }

        public int PickIndex()
        {
            var randInt = _rand.Next(1, _sum + 1);

            var index = Array.BinarySearch(_aggr, randInt);
            if (index >= 0)
                return index;
            else
                return (index + 1) * -1;
        }
    }
}
