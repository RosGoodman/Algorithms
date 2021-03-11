using System;
using Task_1.Search_BFS_DFS;
using Task_2.Tree;

namespace Task_2
{
    class Program
    {
        static void Main(string[] args)
        {
            Generator generator = new Generator();
            int[] array = generator.GetIntArray(15);
            TreeClass tree = new TreeClass();

            for (int i = 0; i < array.Length; i++)
            {
                tree.AddItem(array[i]);
            }

            Searchs search = new Searchs();
            int searchigValue = 31;
            TreeNode searchNode = search.SearchBFS(tree.GetRoot(), searchigValue);
            TreeNode searchNode1 = search.SearchDFS(tree.GetRoot(), searchigValue);

            string arrayString = string.Empty;
            for (int i = 0; i < array.Length; i++)
            {
                arrayString += array[i] + " ";
            }
            Console.WriteLine();
            Console.WriteLine("Array " + arrayString);

            if (searchNode != null)
            {
                Console.WriteLine("BFS  " + searchNode.Value);
                Console.WriteLine("DFS  " + searchNode1.Value);
            }
            else
            {
                Console.WriteLine();
                Console.WriteLine("Такое значение ({0}) не найдено.", searchigValue);
            }

            Console.ReadLine();
        }
    }
}
