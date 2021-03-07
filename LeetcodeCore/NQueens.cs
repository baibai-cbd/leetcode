using System;
using System.Collections.Generic;
using System.Text;

namespace LeetcodeCore
{
    public class NQueens
    {
        // 51. N-Queens
        // Classical backtracking problem
        // tricky part is representing diagonal lines, vertical lines occupied states with hashset
        private HashSet<int> _colSet = new HashSet<int>();
        private HashSet<int> _leftDiagSet = new HashSet<int>(); // means 45 degree left of vertical line
        private HashSet<int> _rightDiagSet = new HashSet<int>(); // means 45 degree right of vertical line

        public IList<IList<string>> SolveNQueens(int n)
        {
            var results = new List<IList<string>>();

            Backtrack(results, new List<string>(), 1, n, new StringBuilder());
            return results;
        }

        private void Backtrack(IList<IList<string>> results, IList<string> currResult, int row, int n, StringBuilder sb)
        {
            if (row > n)
            {
                results.Add(new List<string>(currResult));
                return;
            }

            for (int i = 1; i <= n; i++)
            {
                if (_colSet.Contains(i) || _leftDiagSet.Contains(row - i) || _rightDiagSet.Contains(row + i))   // row-i & row+i would give same number for cells in the same diagonal line
                    continue;

                // append the current row text representation
                sb.Clear();
                for (int j = 1; j < i; j++) sb.Append('.');
                sb.Append('Q');
                for (int j = i+1; j <= n; j++) sb.Append('.');
                currResult.Add(sb.ToString());
                // set hashset occupied states
                _colSet.Add(i);
                _leftDiagSet.Add(row - i);
                _rightDiagSet.Add(row + i);
                //
                Backtrack(results, currResult, row + 1, n, sb);
                // clear the states & remove last row text
                currResult.RemoveAt(currResult.Count - 1);
                _colSet.Remove(i);
                _leftDiagSet.Remove(row - i);
                _rightDiagSet.Remove(row + i);
            }
        }
    }
}
