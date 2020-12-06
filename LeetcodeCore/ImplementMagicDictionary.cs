using System;
using System.Collections.Generic;
using System.Text;

namespace LeetcodeCore
{
    public class ImplementMagicDictionary
    {
        // 676. Implement Magic Dictionary
        // TODO: Try Trie implementation next time
    }

    public class MagicDictionary
    {
        private List<string>[] _arrayOfStringLists;

        /** Initialize your data structure here. */
        public MagicDictionary()
        {
            _arrayOfStringLists = new List<string>[101];
        }

        public void BuildDict(string[] dictionary)
        {
            foreach (var s in dictionary)
            {
                if (_arrayOfStringLists[s.Length] == null)
                {
                    _arrayOfStringLists[s.Length] = new List<string>();
                }
                _arrayOfStringLists[s.Length].Add(s);
            }
        }

        public bool Search(string searchWord)
        {
            if (_arrayOfStringLists[searchWord.Length] == null)
                return false;

            var charArray1 = searchWord.ToCharArray();
            foreach (var word in _arrayOfStringLists[searchWord.Length])
            {
                var count = 0;
                var charArray2 = word.ToCharArray();
                for (int i = 0; i < charArray1.Length; i++)
                {
                    if (charArray1[i] != charArray2[i])
                        count++;
                    if (count > 1) 
                        break;
                }
                if (count == 1)
                    return true;
            }
            return false;
        }
    }
}
