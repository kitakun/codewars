using System;
using System.Collections.Generic;

namespace CodeWarrior.Wars
{
    /// <summary>
    /// Write a function that takes an integer as input, and returns the number of bits that are equal to one in
    /// the binary representation of that number. You can guarantee that input is non-negative.
    /// 
    /// Example: The binary representation of 1234 is 10011010010, so the function should return 5 in this case
    /// </summary>
    public class BitCountingWarrior : IWar
    {
        public void Launch()
        {
            void consoleTest(int expected, int paramVal)
            {
                Console.WriteLine($"Expect={expected} got={CountBits(paramVal)}");
            }

            consoleTest(0, 0);
            consoleTest(1, 4);
            consoleTest(3, 7);
            consoleTest(2, 9);
            consoleTest(2, 10);
            consoleTest(14, 77231418);
        }

        public static int CountBits(int n)
        {
            var bitsList = IntToBits(n);
            return CalcNumCount(bitsList, 1);
        }

        private static List<int> IntToBits(int n)
        {
            var allNumbersList = new List<int>();

            int process(int inp)
            {
                if (inp == 0 || inp == 1)
                {
                    allNumbersList.Add(inp);
                    return inp;
                }

                var part1 = inp % 2;
                allNumbersList.Add(part1);
                return part1 + 10 * process(inp / 2);
            }

            process(n);

            allNumbersList.Reverse();
            return allNumbersList;
        }

        private static int CalcNumCount(List<int> numbers, int val)
        {
            var counts = 0;
            for (var i = 0; i < numbers.Count; i++)
            {
                if (numbers[i] == val)
                {
                    counts++;
                }
            }
            return counts;
        }
    }
}
