using System;
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
            var nums = new int[] { 73, 74, 75, 71, 69, 72, 76, 73 };

            var testClass = new DailyTemperaturesSolution();
            var result = testClass.DailyTemperatures(nums);
            foreach (var item in result)
            {
                Console.Write($"-{item}-");
            }
            //
            Console.ReadKey();
        }
    }
}
