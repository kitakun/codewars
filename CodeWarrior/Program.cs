namespace CodeWarrior
{
    using System;

    using CodeWarrior.Wars;

    class Program
    {
        static void Main(string[] args)
        {
            IWar war = new HumanReadableDurationFormat_12();

            do
            {
                war.Launch();
            }
            while (Console.ReadKey().Key != ConsoleKey.Escape);

            Console.WriteLine("====DONE====");
        }
    }
}
