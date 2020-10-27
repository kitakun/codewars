using System;

namespace CodeWarrior.Wars
{
    /// <summary>
    /// Implement a function that adds two numbers together and returns their sum in binary.
    /// The conversion can be done before, or after the addition.
    /// The binary number returned should be a string.
    /// </summary>
    public class BinaryAdditionWarrior : IWar
    {
        public void Launch()
        {
            Console.WriteLine($"{1} + {2} = {AddBinary(1, 2)}, should = '{11}'");
        }

        public static string AddBinary(int a, int b)
        {
            return Convert.ToString(a + b, 2);
        }
    }
}
