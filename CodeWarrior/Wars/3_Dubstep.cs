using System;
using System.Text;

namespace CodeWarrior.Wars
{
    public class DubstepWarrior : IWar
    {
        private const string wubSound = "WUB";

        public void Launch()
        {
            void attemp(string input, string expected)
            {
                var rawString = SongDecoder(input);
                Console.WriteLine($"From={input} Result={rawString}");
                Console.WriteLine($"Its ok={rawString == expected}");
            }


            attemp("U", "U");
            attemp("A", "U");
            attemp("WUWUBUBWUBUWUB", "ABC");

            attemp("WUBWUBABCWUB", "ABC");
            attemp("WUBWUBIWUBAMWUBWUBX", "I AM X");
        }

        public static string SongDecoder(string input)
        {
            var inputData = new StringBuilder(input);

            while (StartedWith(inputData, wubSound))
            {
                inputData.Remove(0, wubSound.Length);
            }

            while (EndedWith(inputData, wubSound))
            {
                inputData.Remove(inputData.Length - wubSound.Length, wubSound.Length);
            }

            inputData.Replace(wubSound, " ");

            while (IsHaveDoubleWhiteSpace(inputData, out var fromIndex))
            {
                inputData.Remove(fromIndex, 1);
            }

            return inputData.ToString();
        }

        private static bool StartedWith(StringBuilder stringData, string text)
        {
            for (var i = 0; i < stringData.Length && i < text.Length; i++)
            {
                if (stringData[i] != text[i])
                    return false;
            }
            return true;
        }

        private static bool EndedWith(StringBuilder stringData, string text)
        {
            var wubIndex = 0;
            for (var i = text.Length; i >= 0 && wubIndex < text.Length; i++)
            {
                var offsetedIndex = stringData.Length - i;
                if (offsetedIndex < 0)
                    return false;
                if (stringData[offsetedIndex] != text[wubIndex++])
                    return false;
            }
            return true;
        }

        private static bool IsHaveDoubleWhiteSpace(StringBuilder stringData, out int fromIndex)
        {
            fromIndex = -1;
            for (var i = 0; i < stringData.Length; i++)
            {
                if (i + 1 < stringData.Length)
                {
                    if (stringData[i] == ' ' && stringData[i + 1] == ' ')
                    {
                        fromIndex = i;
                        return true;
                    }
                }
                else if (i + 1 == stringData.Length && stringData[i] == ' ')
                {
                    fromIndex = i;
                    return true;
                }
                else
                {
                    break;
                }
            }

            return false;
        }
    }
}
