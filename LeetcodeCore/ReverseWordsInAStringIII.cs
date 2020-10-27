using System;

namespace LeetcodeCore
{
    public class ReverseWordsInAStringIII
    {
        // 557. Reverse Words in a String III
        public string ReverseWords(string s)
        {
            var words = s.Split(' ');
            for (int i = 0; i < words.Length; i++)
            {
                var arr = words[i].ToCharArray();
                Array.Reverse(arr);
                words[i] = new string(arr);
            }

            return string.Join(' ', words);
        }
    }
}
