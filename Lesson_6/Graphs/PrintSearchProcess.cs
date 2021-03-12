
using Graphs.Graph;
using System;

namespace Graphs
{
    public class PrintSearchProcess
    {
        public void ProcessBFS(Node[] nodes)
        {
            string wave = string.Empty;
            for (int i = 0; i < nodes.Length; i++)
            {
                wave += nodes[i].Value + " ";
            }
            Console.WriteLine(wave);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <param name="searchType"></param>
        public void FoundNode(int value, string searchType)
        {
            if(value == -1)
                Console.WriteLine();
            Console.WriteLine("{0}: {1}", searchType, value);
        }
    }
}
