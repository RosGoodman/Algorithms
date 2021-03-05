using System;
using System.Collections.Generic;

namespace Task_1
{
    class Program
    {
        static void Main(string[] args)
        {
            int count = 10000;  //размер массива
            int length = 5;     //длина строк в массиве

            StringGenerator stringGenerator = new StringGenerator();
            string[] strArray = stringGenerator.GetRandomStringArray(count, length);
            HashSet<string> hashSat = stringGenerator.GetHashSet(count, length);

            StringFinder stringFinder = new StringFinder();
            int strIndex = stringFinder.Find(stringGenerator.GetRandomString(length), strArray);

            Console.WriteLine(strIndex);

            Console.ReadLine();
        }
    }
}
