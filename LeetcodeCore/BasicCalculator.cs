using System;
using System.Collections.Generic;
using System.Text;

namespace LeetcodeCore
{
    public class BasicCalculator
    {
        // 224. Basic Calculator
        // Deal with only "+,-,(,)", keep a rolling sum
        public int Calculate(string s)
        {
            var stack = new Stack<int>();
            var sign = 1;
            var sum = 0;

            for (int i = 0; i < s.Length; i++)
            {
                if (char.IsWhiteSpace(s[i]))
                    continue;

                if (char.IsDigit(s[i]))
                {
                    var num = s[i] - '0';
                    while (i + 1 < s.Length && char.IsDigit(s[i+1]))
                    {
                        num = s[i+1] - '0' + num * 10;
                        i++;
                    }
                    sum += num * sign;
                }
                else if (s[i] == '+')
                {
                    sign = 1;
                }
                else if (s[i] == '-')
                {
                    sign = -1;
                }
                else if (s[i] == '(')
                {
                    stack.Push(sum);
                    stack.Push(sign);
                    sum = 0;
                    sign = 1;
                }
                else if (s[i] == ')')
                {
                    sum = sum * stack.Pop() + stack.Pop();
                }
            }

            return sum;
        }
    }
}
