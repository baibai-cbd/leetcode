using System;
using System.Collections.Generic;
using System.Text;

namespace LeetcodeCore
{
    public class TextJustification
    {
        // 68. Text Justification
        public IList<string> FullJustify(string[] words, int maxWidth)
        {
            var results = new List<string>();
            var builder = new StringBuilder();
            var linkedList = new LinkedList<string>();
            var currCount = 0;
            var i = 0;

            while (true)
            {
                currCount += words[i].Length;
                linkedList.AddLast(words[i]);
                if (currCount > maxWidth - (linkedList.Count - 1))
                {
                    currCount -= words[i].Length;
                    linkedList.RemoveLast();
                    BuildWithCurrentWords(results, builder, linkedList, ref currCount, maxWidth, false);
                }
                else if (currCount == maxWidth - (linkedList.Count - 1))
                {
                    BuildWithCurrentWords(results, builder, linkedList, ref currCount, maxWidth, false);
                    i++;
                }
                else
                {
                    i++;
                }

                if (i == words.Length)
                {
                    if (linkedList.Count > 0)
                        BuildWithCurrentWords(results, builder, linkedList, ref currCount, maxWidth, true);
                    break;
                }
            }

            return results;
        }

        private void BuildWithCurrentWords(IList<string> results, StringBuilder builder, LinkedList<string> linkedList, ref int currCount, int maxWidth, bool lastLineFlag)
        {
            builder.Clear();
            //
            var arr = new int[linkedList.Count - 1];
            if (lastLineFlag)
                Array.Fill(arr, 1);
            else
                arr = DivideSpaces(maxWidth - currCount, linkedList.Count - 1);
            //
            var i = 0;
            while (i < arr.Length)
            {
                builder.Append(linkedList.First.Value);
                linkedList.RemoveFirst();
                builder.Append(new string(' ', arr[i]));
                i++;
            }
            builder.Append(linkedList.First.Value);
            builder.Append(new string(' ', maxWidth - builder.Length));
            Console.WriteLine($"Length of this line: {builder.Length}");
            results.Add(builder.ToString());
            //
            linkedList.Clear();
            currCount = 0;
        }

        private int[] DivideSpaces(int spaces, int slots)
        {
            if (slots > spaces)
                throw new ArgumentOutOfRangeException();
            if (slots == 0)
                return new int[0];

            var arr = new int[slots];
            var i = 0;
            while (spaces > 0)
            {
                arr[i]++;
                i++;
                if (i == arr.Length) i = 0;
                spaces--;
            }

            return arr;
        }
    }
}
