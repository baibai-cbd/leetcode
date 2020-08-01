using System;
using System.Collections.Generic;
using System.Text;

namespace LeetcodeCore
{
    public class DetectCapital
    {
        // 520. Detect Capital
        public bool DetectCapitalUse(string word)
        {
            if (word.Length <=1)
                return true;
            if (word.ToUpper().Equals(word))
                return true;
            if (word.Substring(1).ToLower().Equals(word.Substring(1)))
                return true;

            return false;
        }
    }
}
