using System;

namespace CodeWarrior.Wars
{
    public class SumOfDigits : IWar
    {
        public void Launch()
        {
            Console.WriteLine($"16 = 1 + 6 = 7, but go = {DigitalRoot(16)}");
            Console.WriteLine($"942 = 9 + 4 + 2 -> 1 + 5 = 6, but go = {DigitalRoot(942)}");
        }

        public int DigitalRoot(long n)
        {
            var w = (n - 1) % 9 + 1;
            if (n < 10)
            {
                return (int)n;
            }

            var result = default(int);

            long value = n;
            do
            {
                int module = (int)value % 10;
                result += module;
                value /= 10;

            } while (value != 0);

            return DigitalRoot(result);
        }
    }
}
