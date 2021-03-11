using BenchmarkDotNet.Attributes;
using System.Collections.Generic;

namespace Task_1
{
    public class Benchmark
    {
        #region TestStringFider

        [Benchmark]
        [ArgumentsSource(nameof(RandomStringsArray))]
        public void TestStringFinder(string[] strArray, string rString)
        {
            StringFinder stringFinder = new StringFinder();
            stringFinder.Find(rString, strArray);
        }

        public IEnumerable<object[]> RandomStringsArray()
        {
            int length = 5;     //длина рандомной строки
            int count = 10000;  //размер массива строк

            StringGenerator stringGenerator = new StringGenerator();
            string[] strArray = stringGenerator.GetRandomStringArray(count, length);
            string rString = stringGenerator.GetRandomString(length);

            yield return new object[] { strArray, rString };
        }

        #endregion

        #region TestHash

        [Benchmark]
        [ArgumentsSource(nameof(RandomStrings_Array))]
        public void TestHashContain(HashSet<string> strHash, string rString)
        {
            strHash.Contains(rString);
        }

        public IEnumerable<object[]> RandomStrings_Array()
        {
            int length = 5;     //длина рандомной строки
            int count = 10000;  //размер массива строк

            StringGenerator stringGenerator = new StringGenerator();
            HashSet<string> hash = stringGenerator.GetHashSet(count, length);
            string rString = stringGenerator.GetRandomString(length);

            yield return new object[] { hash, rString };
        }

        #endregion

    }
}
