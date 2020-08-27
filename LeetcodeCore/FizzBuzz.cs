using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetcodeCore
{
    public class FizzBuzzSolution
    {
        // 412. Fizz Buzz
        public IList<string> FizzBuzz(int n)
        {
            return BuildFizzBuzz(n).ToList();
        }

        public IEnumerable<string> BuildFizzBuzz(int n)
        {
            for (int i = 1; i <= n; i++)
            {
                if (i % 3 == 0 && i % 5 == 0)
                {
                    yield return "FizzBuzz";
                }
                else if (i % 3 == 0)
                {
                    yield return "Fizz";
                }
                else if (i % 5 == 0)
                {
                    yield return "Buzz";
                }
                else
                {
                    yield return i.ToString();
                }
            }
        }
    }
}
