using System;
using System.Collections.Generic;
using System.Text;

namespace LeetcodeCore
{
    public class StringCompression
    {
        // 443. String Compression
        public int Compress(char[] chars)
        {
            if (chars == null || chars.Length == 0)
                return 0;
            var newLength = 0;
            var index = 0;
            var currChar = chars[index];
            var currCount = 0;
            while (index < chars.Length)
            {
                if (chars[index] == currChar)
                {
                    currCount++;
                    index++;
                }
                else
                {
                    chars[newLength] = currChar;
                    newLength += FillArrayWithCountedNumber(chars, currCount, newLength);
                    currChar = chars[index];
                    currCount = 0;
                }
            }

            chars[newLength] = currChar;
            newLength += FillArrayWithCountedNumber(chars, currCount, newLength);

            Array.Resize(ref chars, newLength);
            return newLength;
        }

        private int FillArrayWithCountedNumber(char[] chars, int currCount, int newLength)
        {
            if (currCount == 1)
            {
                return 1;
            }
            else
            {
                var digitArr = currCount.ToString().ToCharArray();
                for (int i = 0; i < digitArr.Length; i++)
                {
                    chars[newLength + i + 1] = digitArr[i];
                }
                return digitArr.Length + 1;
            }
        }
    }
}
