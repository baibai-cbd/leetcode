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
}
