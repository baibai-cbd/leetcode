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
            var inorder = new int[] { 9, 3, 15, 20, 7 };
            var postorder = new int[] { 9, 15, 7, 20, 3 };


            var testClass = new ConstructBinaryTreeFromInorderAndPostorderTraversal();
            var result = testClass.BuildTree(inorder, postorder);
            Console.WriteLine(result);
            //
            Console.ReadKey();
        }
    }
}
