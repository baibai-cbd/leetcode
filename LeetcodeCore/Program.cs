using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;

namespace LeetcodeCore
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            //
            // TODO: Test code can be here
            var nums = new char[][] {
                new char[] { '1', '1', '1' },
                new char[] { '0', '1', '0' },
                new char[] { '1', '1', '1' }
            };
            var s = "[1,2,3,null,null,4,5]";
            var i = 3;
            //
            var s1 = "**|**|*|*|";
            var start = new int[] { 1, 1 };
            var end = new int[] { 5, 6 };
            //var s1Splitted = s1.Split('|');

            var arr2 = new int[]{ 5, 2, 1 };
            var arr = new int[] { 60, 30, 30, 30, 30, 30, 30, 30, 30, 30, 30, 30, 30, 30, 30, 30, 30, 30, 30, 30, 30, 30, 30, 30, 30, 30, 30, 30, 30, 30 };
            //
            var arr3 = new int[] { 2, 3, 5, 1 };
            var arr4 = new int[] { 1, 1, 1, 0, 0, 0, 1, 1, 1, 1, 0 };
            var numOfNodes = 7;
            //
            var stringArr = new string[] { "88 99 200", "88 99 300", "99 32 100", "12 12 15" };
            var threshold = 2;
            //
            var instances = 2;
            var utils = new int[] { 25, 23, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 76, 80 };
            //
            var t1 = new TreeNode(1);
            var t2 = new TreeNode(2);
            var t3 = new TreeNode(3);
            var t4 = new TreeNode(4);
            var t5 = new TreeNode(5);
            t1.left = t2;
            t1.right = t3;
            t3.left = t4;
            t3.right = t5;

            var chars = new char[] { '3', '5', '9', '+', '2', '*', '+' };

            var matrix = new int[3][];
            matrix[0] = new int[] { 4, 4 };
            matrix[1] = new int[] { 1, 2 };
            matrix[2] = new int[] { 3, 6 };

            var balloons = new int[2][];
            balloons[0] = new int[] { -2147483646, -2147483645 };
            balloons[1] = new int[] { 2147483646, 2147483647 };
            //[[-2147483646,-2147483645],[2147483646,2147483647]]

            var url = "https://baibai.com";

            var prerequisites = new int[1][];
            prerequisites[0] = new int[] { 1, 0 };
            //
            var strings = new List<string>() { "aaaa", "aaa" };
            var longString = "aaaaaaa";
            //
            var watch = new Stopwatch();
            //
            // ["LFUCache","put","put","get","put","get","get","put","get","get","get"]
            // [[2],[1,1],[2,2],[1],[3,3],[2],[3],[4,4],[1],[3],[4]]
            var testClass = new BasicCalculatorII();
            watch.Start();
            var result = testClass.Calculate(" 3 / 2 ");
            watch.Stop();

            Console.WriteLine($"--{result}--{watch.Elapsed}");
            //
            Console.ReadKey();
        }
    }
}
