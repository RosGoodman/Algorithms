using BenchmarkDotNet.Running;

namespace BenchmarkTests
{
    class Program
    {
        static void Main(string[] args)
        {
            BenchmarkSwitcher.FromAssembly(typeof(Program).Assembly).Run(args); //запуск тестов
        }
    }
}
