using System;

namespace LeetcodeCore
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            //
            // TODO: Test code can be here
            var n = 3;
            var flights = new int[][] { new int[] { 0, 1, 100 }, new int[] { 1, 2, 100 }, new int[] { 0, 2, 500 } };
            var src = 0;
            var dst = 2;
            var K = 0;
            var testClass = new CheapestFlightsWithinKStops();
            var result = testClass.FindCheapestPrice(n, flights, src, dst, K);
            Console.WriteLine(result);
            //
            Console.ReadKey();
        }
    }
}
