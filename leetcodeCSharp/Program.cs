using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace leetcodeCSharp
{
    class Program
    {
        static void Main(string[] args)
        {
            // The code provided will print ‘Hello World’ to the console.
            // Press Ctrl+F5 (or go to Debug > Start Without Debugging) to run your app.
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
