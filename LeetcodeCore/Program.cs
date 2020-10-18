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
            var nums = new int[] { 3, 2, 1, 4 };

            var testClass = new TrappingRainWater();
            var result = testClass.Trap(nums);
            
            Console.WriteLine($"-{result}-");
            //
            Console.ReadKey();
        }
    }
}
