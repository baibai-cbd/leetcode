using System;
using System.Collections.Generic;
using System.Text;

namespace LeetcodeCore
{
    public class SimplifyPathSolution
    {
        // 71. Simplify Path
        public string SimplifyPath(string path)
        {

            var stack = new Stack<string>();
            var segments = path.Split('/', StringSplitOptions.RemoveEmptyEntries);
            var sb = new StringBuilder();

            foreach (var s in segments)
            {
                if (s.Equals("."))
                    continue;

                if (s.Equals(".."))
                {
                    if (stack.Count == 0)
                        continue;
                    else
                        stack.Pop();
                }
                else
                {
                    stack.Push(s);
                }
            }

            if (stack.Count == 0)
                return "/";

            foreach (var s in stack)
            {
                sb.Insert(0, s);
                sb.Insert(0, "/");
            }

            return sb.ToString();
        }
    }
}
