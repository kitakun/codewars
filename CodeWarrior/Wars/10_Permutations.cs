using System;
using System.Collections.Generic;

namespace CodeWarrior.Wars
{
    public class Permutations : IWar
    {
        public void Launch()
        {
            Console.WriteLine($"Expect=[a] got={string.Join(",", SinglePermutations("a"))}");
            Console.WriteLine($"Expect=[ab,ba] got={string.Join(",", SinglePermutations("ab"))}");
            Console.WriteLine($"Expect=[aabb,abab,abba,baab,baba,bbaa] got={string.Join(",", SinglePermutations("aabb"))}");
        }

        public static List<string> SinglePermutations(string s)
        {
            var result = new List<string>();

            Permute(s.ToCharArray(), 0, new char[s.Length], new bool[s.Length], result);

            return result;
        }

        private static void Permute(char[] items, int itemIndex, char[] permutation, bool[] isUsedIndex, List<string> results)
        {
            for (int i = 0; i < items.Length; ++i)
            {
                if (!isUsedIndex[i])
                {
                    isUsedIndex[i] = true;
                    permutation[itemIndex] = items[i];

                    if (itemIndex < (items.Length - 1))
                    {
                        Permute(items, itemIndex + 1, permutation, isUsedIndex, results);
                    }
                    else
                    {
                        var finalString = new string(permutation);
                        if (!results.Contains(finalString))
                        {
                            results.Add(finalString);
                        }
                    }

                    isUsedIndex[i] = false;
                }
            }
        }
    }
}
