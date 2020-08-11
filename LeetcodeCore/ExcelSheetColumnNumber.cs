using System;
using System.Collections.Generic;
using System.Text;

namespace LeetcodeCore
{
    public class ExcelSheetColumnNumber
    {
        // 171. Excel Sheet Column Number
        public int TitleToNumber(String s)
        {
            int result = 0;
            for (int i = 0; i < s.Length; i++)
            {
                result = result * 26 + (s[i] - 'A' + 1);
            }
            return result;
        }
    }
}
