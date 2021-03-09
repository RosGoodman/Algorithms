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

            TreeNode sNode = tree.GetNodeByValue(84);
            if(sNode.ParentNode != null) Console.WriteLine("p" + sNode.ParentNode.Value);
            if (sNode.LeftChild != null) Console.WriteLine("l" + sNode.LeftChild.Value);
            if (sNode.RightChild != null) Console.WriteLine("r" + sNode.RightChild.Value);
            Console.WriteLine();

            tree.RemoveItem(84);

            sNode = tree.GetNodeByValue(55);
            if (sNode.ParentNode != null) Console.WriteLine("p" + sNode.ParentNode.Value);
            if (sNode.LeftChild != null) Console.WriteLine("l" + sNode.LeftChild.Value);
            if (sNode.RightChild != null) Console.WriteLine("r" + sNode.RightChild.Value);
            Console.WriteLine();


            sNode = tree.GetNodeByValue(61);
            if (sNode.ParentNode != null) Console.WriteLine("p" + sNode.ParentNode.Value);
            if (sNode.LeftChild != null) Console.WriteLine("l" + sNode.LeftChild.Value);
            if (sNode.RightChild != null) Console.WriteLine("r" + sNode.RightChild.Value);
            Console.WriteLine();


            sNode = tree.GetNodeByValue(95);
            if (sNode.ParentNode != null) Console.WriteLine("p" + sNode.ParentNode.Value);
            if (sNode.LeftChild != null) Console.WriteLine("l" + sNode.LeftChild.Value);
            if (sNode.RightChild != null) Console.WriteLine("r" + sNode.RightChild.Value);
            Console.WriteLine();


            Console.ReadLine();
        }
    }
}
