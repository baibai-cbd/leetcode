using System;
using System.Collections.Generic;
using System.Text;

namespace LeetcodeCore
{
    public class WildcardMatching
    {
        // 44. Wildcard Matching
        public bool IsMatch(string s, string p)
        {
            var memoArr = new int[s.Length + 1][];
            for (int i = 0; i < memoArr.Length; i++)
            {
                memoArr[i] = new int[p.Length + 1];
            }

            return Helper(memoArr, s, p, 0, 0);
        }

        private bool Helper(int[][] memoArr, string s, string p, int indexS, int indexP)
        {
            if (memoArr[indexS][indexP] != 0)
            {
                return memoArr[indexS][indexP] == 1 ? true : false;
            }
            var result = false;
            if (s.Length == indexS && p.Length == indexP)
            {
                result = true;
            }
            else if (p.Length == indexP)
            {
                result = false;
            }
            else if (s.Length == indexS)
            {
                result = p[indexP] == '*' && Helper(memoArr, s, p, indexS, indexP + 1);
            }
            else if (p[indexP] == '*')
            {
                result = Helper(memoArr, s, p, indexS + 1, indexP) || Helper(memoArr, s, p, indexS, indexP + 1);
            }
            else if (p[indexP] == '?' || p[indexP] == s[indexS])
            {
                result = Helper(memoArr, s, p, indexS + 1, indexP + 1);
            }
            else
            {
                result = false;
            }

            memoArr[indexS][indexP] = result ? 1 : -1;
            return result;
        }
    }
}
