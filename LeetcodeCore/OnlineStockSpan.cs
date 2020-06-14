using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetcodeCore
{
    public class OnlineStockSpan
    {
        // 901. Online Stock Span
        public class StockSpanner
        {
            readonly Stack<Tuple<int, int>> spanStack;

            public StockSpanner()
            {
                spanStack = new Stack<Tuple<int, int>>();
            }

            public int Next(int price)
            {
                var currPair = new Tuple<int, int>(price, 1);
                if (spanStack.Count == 0 || spanStack.Peek().Item1 > price)
                {
                    spanStack.Push(currPair);
                    return currPair.Item2;
                }

                while (spanStack.Peek().Item1 <= price)
                {
                    var popped = spanStack.Pop();
                    currPair = new Tuple<int, int>(currPair.Item1, currPair.Item2 + popped.Item2);
                    if (spanStack.Count == 0)
                    {
                        break;
                    }
                }
                spanStack.Push(currPair);
                return currPair.Item2;
            }
        }
    }
}
