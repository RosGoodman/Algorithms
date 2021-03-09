using System;
using Task_2.Tree;

namespace Task_2
{
    class Program
    {
        static void Main(string[] args)
        {
            Generator generator = new Generator();
            int[] array = new int[] { 55, 24, 15, 18, 10, 36, 30, 31, 26, 28, 41, 39, 48, 84, 61, 95 };
            TreeClass tree = new TreeClass();

            for (int i = 0; i < array.Length; i++)
            {
                tree.AddItem(array[i]);
            }

            tree.PrintTree();

            Console.ReadLine();
        }
    }
}
