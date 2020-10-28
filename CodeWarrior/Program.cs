using System;
using CodeWarrior.Wars;

namespace CodeWarrior
{
    class Program
    {
        static void Main(string[] args)
        {
            IWar war = new BitCountingWarrior();

            war.Launch();

            Console.WriteLine("====DONE====");
            Console.ReadKey();
        }
    }
}
