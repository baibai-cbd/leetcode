using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetcodeCore
{
    public class GroupAnagrams
    {
        // 49 Group Anagrams

        public IList<IList<string>> FindGroupAnagrams(string[] strs)
        {
            byte[][] oneHotArrays = new byte[strs.Length][];
            for (int i = 0; i < strs.Length; i++)
            {
                byte[] subArray = new byte[26];
                oneHotArrays[i] = subArray;
                foreach (char c in strs[i])
                {
                    subArray[c-97]++;
                }
            }

            string[] convertedArrays = new string[strs.Length];
            for (int i = 0; i < strs.Length; i++)
            {
                convertedArrays[i] = BitConverter.ToString(oneHotArrays[i]);
            }

            IList<IList<string>> output = new List<IList<string>>();
            var dict = new Dictionary<string,int>();
            for (int i = 0; i < convertedArrays.Length; i++)
            {
                if (dict.TryGetValue(convertedArrays[i], out int index))
                {
                    output.ElementAt(index).Add(strs[i]);
                }
                else
                {
                    dict.Add(convertedArrays[i], output.Count);
                    var list = new List<string>();
                    list.Add(strs[i]);
                    output.Add(list);
                }
            }

            return output;
        }
    }
}
