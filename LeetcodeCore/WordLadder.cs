using System;
using System.Collections.Generic;
using System.Text;

namespace LeetcodeCore
{
    public class WordLadder
    {
        // 127. Word Ladder
        // Try 2-way BFS next time
        public int LadderLength(string beginWord, string endWord, IList<string> wordList)
        {
            var set = new HashSet<string>(wordList);
            
            if (!set.Contains(endWord))
                return 0;

            var queue = new Queue<string>();
            queue.Enqueue(beginWord);
            var length = 1;

            while (queue.Count > 0)
            {
                var currCount = queue.Count;
                for (int i = 0; i < currCount; i++)
                {
                    var currWord = queue.Dequeue();
                    var chars = currWord.ToCharArray();
                    for (int j = 0; j < chars.Length; j++)
                    {
                        var origChar = chars[j];
                        for (char c = 'a'; c <= 'z'; c++)
                        {
                            if (c == origChar)
                                continue;
                            chars[j] = c;
                            var newWord = new string(chars);
                            if (newWord == endWord)
                                return length + 1;
                            if (set.Contains(newWord))
                            {
                                queue.Enqueue(newWord);
                                set.Remove(newWord);
                            }
                        }
                        chars[j] = origChar;
                    }
                }
                length++;
            }
            return 0;
        }
    }
}
