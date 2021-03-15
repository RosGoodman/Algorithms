
using Graphs.Graph;
using System;

namespace Graphs
{
    public class Program
    {
        static void Main(string[] args)
        {
            int[][] matrix = new int[13][];
            matrix[0] = new int[] { 1, 1, 0, 2, 3, 0, 0, 0, 0, 0, 0, 0, 0 };
            matrix[1] = new int[] { 1, 0, 0, 0, 0, 2, 0, 0, 0, 0, 0, 0, 0 };
            matrix[2] = new int[] { 0, 0, 0, 2, 2, 2, 0, 0, 0, 0, 0, 0, 0 };
            matrix[3] = new int[] { 0, 0, 2, 0, 0, 0, 4, 0, 0, 0, 0, 0, 0 };
            matrix[4] = new int[] { 0, 0, 2, 0, 0, 2, 1, 0, 0, 0, 0, 0, 0 };
            matrix[5] = new int[] { 0, 2, 2, 0, 2, 0, 0, 0, 0, 0, 6, 7, 0 };
            matrix[6] = new int[] { 0, 0, 0, 0, 1, 0, 0, 4, 5, 0, 0, 0, 0 };
            matrix[7] = new int[] { 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0 };
            matrix[8] = new int[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 6, 0, 0, 5 };
            matrix[9] = new int[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 4, 0, 0 };
            matrix[10] = new int[] { 0, 0, 0, 0, 0, 6, 0, 0, 0, 4, 0, 0, 0 };
            matrix[11] = new int[] { 0, 0, 0, 0, 0, 7, 0, 0, 0, 0, 0, 0, 8 };
            matrix[12] = new int[] { 0, 0, 0, 0, 0, 0, 0, 0, 5, 0, 0, 0, 0 };

            GraphClass graph = new GraphClass();
            graph.AddItem(matrix);

            graph.PrintGraphMatrix();
            Console.ReadLine();
        }
    }
}
