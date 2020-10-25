using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetcodeCore
{
    public class GenerateParentheses
    {
        // 22. Generate Parentheses
        public IList<string> GenerateParenthesis(int n)
        {
            var results = new List<string>();
            Backtracking(results, "", n, 0, 0);
            return results;
        }

        private void Backtracking(IList<string> results, string s, int n, int left, int right)
        {
            if (s.Length == n*2)
            {
                results.Add(s);
                return;
            }

            if (left < n)
                Backtracking(results, s + "(", n, left + 1, right);
            if (right < left)
                Backtracking(results, s + ")", n, left, right + 1);
        }
    }
}
