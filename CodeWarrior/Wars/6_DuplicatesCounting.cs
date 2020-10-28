using System;
using System.Collections.Generic;

namespace CodeWarrior.Wars
{
    public class DuplicatesCounting : IWar
    {
        public void Launch()
        {
            void test(string str, int expected)
            {
                var dupCount = DuplicateCount(str);
                var isSuccessText = dupCount == expected ? "SUCCESS" : "FAILED";
                Console.WriteLine($"[{isSuccessText}] Expect={expected} text={str}");
            }

            test(string.Empty, 0);
            test("abcde", 0);
            test("aabbcde", 2);
            test("aabBcde", 2);
            test("Indivisibility", 1);
        }

        public static int DuplicateCount(string str)
        {
            var data = new Dictionary<char, int>();
            var lowerText = str.ToLower();
            for (var i = 0; i < lowerText.Length; i++)
            {
                var cChar = lowerText[i];
                if (data.TryGetValue(cChar, out var curVal))
                {
                    data[cChar] = ++curVal;
                }
                else
                {
                    data.Add(cChar, 1);
                }
            }

            var dupsCount = 0;
            using (var enumer = data.GetEnumerator())
            {
                while (enumer.MoveNext())
                {
                    if (enumer.Current.Value > 1)
                    {
                        dupsCount++;
                    }
                }
            }

            return dupsCount;
        }
    }
}
