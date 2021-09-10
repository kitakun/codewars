namespace CodeWarrior
{
    using System;
    using System.IO;
    using System.Linq;

    using BenchmarkDotNet.Configs;
    using BenchmarkDotNet.Running;

    using CodeWarrior.Benchmark;
    using CodeWarrior.Wars;

    using OfficeOpenXml;

    class Program
    {
        static void Main(string[] args)
        {
            //LaunchWar();
            LaunchBenchmark();
        }

        static void LaunchWar()
        {
            IWar war = new TelephoneWar();

            do
            {
                war.Launch();
            }
            while (Console.ReadKey().Key != ConsoleKey.Escape);

            Console.WriteLine("====DONE====");
        }

        static void LaunchBenchmark()
        {
#if RELEASE
            BenchmarkRunner.Run<TelephoneWarBenchmarks>();
#else
            BenchmarkSwitcher.FromAssembly(typeof(Program).Assembly).Run(new string[0], new DebugInProcessConfig());
#endif
        }
    }
}
