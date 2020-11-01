using System;
using System.Collections.Generic;

namespace CodeWarrior.Wars
{
    public class RomanNumeralsDecoder : IWar
    {
        private static readonly Dictionary<char, int> _digits = new Dictionary<char, int>
        {
            { 'I', 1 },
            { 'V', 5 },
            { 'X', 10 },
            { 'L', 50 },
            { 'C', 100 },
            { 'D', 500 },
            { 'M', 1000 },
        };

        public void Launch()
        {
            void test(string chars, int expected) =>
                Console.WriteLine($"{chars} should be {expected} => got {Solution(chars)}");

            test("MMVIII", 2008);
            test("MDCLXVI", 1666);
            test("XXI", 21);
            test("IV", 4);
            test("MCMLIV", 1954);
            test("MCMXC", 1990);
            test("MMXIV", 2014);
        }

        public static int Solution(string roman)
        {
            roman = roman.ToUpper();

            var result = default(int);
            var minus = default(int);
            for (var i = 0; i < roman.Length; i++)
            {
                int thisNumeral = _digits[roman[i]] - minus;

                if (i >= roman.Length - 1
                    || thisNumeral + minus >= _digits[roman[i + 1]])
                {
                    result += thisNumeral;
                    minus = 0;
                }
                else
                {
                    minus = thisNumeral;
                }
            }

            return result;
        }
    }
}
