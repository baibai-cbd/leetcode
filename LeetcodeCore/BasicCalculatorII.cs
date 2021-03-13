using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetcodeCore
{
    public class BasicCalculatorII
    {
        // 227. Basic Calculator II
        public int Calculate(string s)
        {
            s = s.Trim(); // trim is important, otherwise the trailing white space can mess up the index check
            var stack = new Stack<int>();
            var sign = '+';
            var currResult = 0;

            for (int i = 0; i < s.Length; i++)
            {
                if (char.IsWhiteSpace(s[i]))
                    continue;

                if (char.IsDigit(s[i]))
                {
                    var num = 0;
                    while (i < s.Length && char.IsDigit(s[i]))
                    {
                        num = num * 10 + (s[i] - '0');
                        i++;
                    }
                    currResult = num;
                }

                if (i == s.Length || new char[] { '+', '-', '*', '/' }.Contains(s[i]))
                {
                    if (sign == '+')
                    {
                        stack.Push(currResult);
                    }
                    else if (sign == '-')
                    {
                        stack.Push(-currResult);
                    }
                    else if (sign == '*')
                    {
                        stack.Push(stack.Pop() * currResult);
                    }
                    else if (sign == '/')
                    {
                        stack.Push(stack.Pop() / currResult);
                    }

                    sign = i == s.Length ? '+' : s[i];
                    currResult = 0;
                }
            }

            var result = 0;
            while (stack.Count > 0)
            {
                result += stack.Pop();
            }
            return result;
        }
    }
}
