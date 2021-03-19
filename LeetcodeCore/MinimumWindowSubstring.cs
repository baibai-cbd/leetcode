using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetcodeCore
{
    public class MinimumWindowSubstring
    {
        // 76. Minimum Window Substring
        // TODO: Pretty hard problem, try to understand other solutions
        public string MinWindow(string s, string t)
        {
            var i = 0;
            var j = 0;
            var minTuple = (-1, -1, s.Length + 1);
            var refDict = new Dictionary<char, int>();
            var workDict = new Dictionary<char, int>();
            var validFlag = false;

            foreach (var c in t)
            {
                if (refDict.ContainsKey(c))
                {
                    refDict[c]++;
                }
                else
                {
                    refDict.Add(c, 1);
                    workDict.Add(c, 0);
                }
            }

            if (refDict.ContainsKey(s[i]))
            {
                workDict[s[i]]++;
                if (CheckValidSubstring(refDict, workDict))
                {
                    validFlag = true;
                    return s.Substring(i, 1);
                }
            }

            for (i = 0; i < s.Length; i++)
            {
                while (!validFlag)
                {
                    if (j == s.Length - 1)
                    {
                        break;
                    }
                    else
                    {
                        j++;
                    }
                    if (refDict.ContainsKey(s[j]))
                    {
                        workDict[s[j]]++;
                        if (CheckValidSubstring(refDict, workDict))
                        {
                            validFlag = true;
                            minTuple = minTuple.Item3 > (j - i + 1) ? (i, j, (j - i + 1)) : minTuple;
                        }
                    }
                }

                if (validFlag) 
                    minTuple = minTuple.Item3 > (j - i + 1) ? (i, j, (j - i + 1)) : minTuple;

                if (refDict.ContainsKey(s[i]))
                {
                    if (refDict[s[i]] < workDict[s[i]])
                    {
                        workDict[s[i]]--;
                    }
                    else
                    {
                        workDict[s[i]]--;
                        validFlag = false;
                    }
                }
            }

            return minTuple.Item3 > s.Length ? "" : s.Substring(minTuple.Item1, minTuple.Item3);
        }

        private bool CheckValidSubstring(IDictionary<char, int> refDict, IDictionary<char, int> workDict)
        {
            return refDict.All(p => p.Value <= workDict[p.Key]);
        }
    }
}
