using System;

using CodeWarrior.Wars;

namespace CodeWarrior
{
    class Program
    {
        static void Main(string[] args)
        {
            IWar war = new Permutations();

            do
            {
                war.Launch();
            }
            while (Console.ReadKey().Key != ConsoleKey.Escape);

            Console.WriteLine("====DONE====");
        }
    }
}
