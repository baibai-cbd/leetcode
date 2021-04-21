using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetcodeCore
{
    public class BasicCalculatorIII
    {
        // 772. Basic Calculator III
        // build upon 227.BasicCalculatorII, use recursion to handle parenthesis,
        // need to careful on index boundary and handling of the close parenthese ')'
        private readonly char[] _operators = new char[] { '+', '-', '*', '/', ')' };

        public int Calculate(string s)
        {
            var i = 0;
            return RecursiveCalculate(s, ref i);
        }

        private int RecursiveCalculate(string s, ref int i)
        {
            var stack = new Stack<int>();
            var sign = '+';
            var currResult = 0;

            for (; i < s.Length; i++)
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

                if (i < s.Length && s[i] == '(')
                {
                    i++;
                    currResult = RecursiveCalculate(s, ref i);
                }

                if (i == s.Length || _operators.Contains(s[i]))
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

                    sign = (i == s.Length || s[i] == ')') ? '+' : s[i];
                    currResult = 0;
                }

                if (i < s.Length && s[i] == ')')
                {
                    i++;
                    break;
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
