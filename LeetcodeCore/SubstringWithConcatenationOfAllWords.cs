using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetcodeCore
{
    public class SubstringWithConcatenationOfAllWords
    {
        // 30. Substring with Concatenation of All Words
        // Great solution uses the fact that all words are same length
        // thus any substring's starting index mod wordLength is within [0,wordLength-1]
        // therefore we can loop thru [0,wordLength-1], checking every chunk of wordLength instead of each character
        public IList<int> FindSubstring(string s, string[] words)
        {
            var result = new List<int>();
            var wordLength = words[0].Length;
            var totalLength = wordLength * words.Length;

            if (s.Length < totalLength)
                return result;

            var refDict = new Dictionary<string, int>();
            var countDict = new Dictionary<string, int>();

            foreach (var w in words)
            {
                if (refDict.ContainsKey(w))
                {
                    refDict[w]++;
                    countDict[w]++;
                }
                else
                {
                    refDict.Add(w, 1);
                    countDict.Add(w, 1);
                }

            }

            var l = 0;
            var wordCount = 0;
            for (; l < wordLength; l++)
            {
                // sliding window operation
                var ll = l;
                var rr = l;
                while (rr <= s.Length - wordLength) // looping until one wordLength from end
                {
                    if (rr - ll < totalLength)
                    {
                        var currWord = s.Substring(rr, wordLength);
                        rr += wordLength;
                        if (refDict.ContainsKey(currWord))
                        {
                            wordCount++;
                            countDict[currWord]--;
                            if (rr - ll == totalLength && wordCount == totalLength / wordLength && CheckExactMatch(countDict))
                                result.Add(ll);
                        }
                    }
                    else
                    {
                        var currWord = s.Substring(ll, wordLength);
                        ll += wordLength;
                        if (refDict.ContainsKey(currWord))
                        {
                            wordCount--;
                            countDict[currWord]++;
                        }
                    }
                }
                // reset the counting states
                wordCount = 0;
                countDict = new Dictionary<string, int>(refDict);
            }

            return result;
        }

        private bool CheckExactMatch(Dictionary<string, int> countDict)
        {
            return countDict.All(kvp => kvp.Value == 0);
        }
    }
}
