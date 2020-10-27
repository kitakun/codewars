using System;
using System.Collections.Generic;

namespace CodeWarrior.Wars
{
    /// <summary>
    /// Write a function that takes in a string of one or more words, and returns the same string,
    /// but with all five or more letter words reversed (Just like the name of this Kata).
    /// Strings passed in will consist of only letters and spaces.
    /// Spaces will be included only when more than one word is present.
    ///
    /// Examples: spinWords( "Hey fellow warriors" ) => returns "Hey wollef sroirraw"
    /// spinWords( "This is a test") => returns "This is a test"
    /// spinWords( "This is another test" ) => returns "This is rehtona test"
    /// </summary>
    public class SpinWordsWarriorUnsafe : IWar
    {
        private static readonly List<char> _reusableCharList = new List<char>(8);

        public void Launch()
        {
            // Hey wollef sroirraw
            Console.WriteLine(SpinWords("Hey fellow warriors"));

            // This is a test
            Console.WriteLine(SpinWords("This is a test"));

            // should be Welcome
            Console.WriteLine(SpinWords("emocleW"));
        }

        public static unsafe string SpinWords(string sentence)
        {
            if (sentence.Length > 0)
            {
                int startWordFrom = 0;
                for (var i = 0; i < sentence.Length; i++)
                {
                    if (i == startWordFrom)
                        continue;

                    var isEmptyChar = sentence[i] == ' ';

                    if (isEmptyChar || i == sentence.Length - 1)
                    {
                        if (i - startWordFrom >= 5)
                        {
                            ReverseWordUnsafe(sentence, startWordFrom, isEmptyChar && i > 0 ? i - 1 : i);
                        }
                        startWordFrom = i + 1;
                    }
                }
            }

            return sentence;
        }

        private static unsafe void ReverseWordUnsafe(string sentence, int fromIndex, int toIndex)
        {
            if (sentence.Length > 0)
            {
                // remember the word as it is
                for (var i = fromIndex; i <= toIndex; i++)
                {
                    _reusableCharList.Add(sentence[i]);
                }

                unsafe
                {
                    fixed (char* cSentence = sentence)
                    {
                        for (int i = 0; i < _reusableCharList.Count; i++)
                        {
                            cSentence[fromIndex + i] = _reusableCharList[_reusableCharList.Count - i - 1];
                        }
                    }
                }

                _reusableCharList.Clear();
            }
        }
    }
}
