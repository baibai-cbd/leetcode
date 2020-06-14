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
            var amount = 5;
            var coins = new int[] { 1, 2, 5 };
            var cc2 = new CoinChange2();
            var result = cc2.Change(amount, coins);
            Console.WriteLine(result);
            //
            Console.ReadKey();
        }
    }
}
