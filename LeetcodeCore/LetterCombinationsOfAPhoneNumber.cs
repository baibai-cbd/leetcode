using System;
using System.Collections.Generic;
using System.Text;

namespace LeetcodeCore
{
    public class LetterCombinationsOfAPhoneNumber
    {
        // 17. Letter Combinations of a Phone Number
        private static string[] _numLetterMap = new string[] { "", "", "abc", "def", "ghi", "jkl", "mno", "pqrs", "tuv", "wxyz" };

        public IList<string> LetterCombinations(string digits)
        {
            if (digits == null || digits.Length == 0)
                return new List<string>();

            var results = new List<string>();
            Backtrack(results, new StringBuilder(), digits, digits.Length, 0);
            return results;
        }

        private void Backtrack(IList<string> results, StringBuilder sb, string digits, int length, int index)
        {
            if (sb.Length == length)
            {
                results.Add(sb.ToString());
                return;
            }

            var currChars = MapKeyNumToCharArray(digits[index]);
            for (int i = 0; i < currChars.Length; i++)
            {
                sb.Append(currChars[i]);
                Backtrack(results, sb, digits, length, index + 1);
                sb.Remove(sb.Length - 1, 1);
            }
        }

        private string MapKeyNumToCharArray(char num)
        {
            if (num - '0' <= 1 || num - '9' > 0)
                throw new ArgumentOutOfRangeException();

            return _numLetterMap[num - '0'];
        }
    }
}
