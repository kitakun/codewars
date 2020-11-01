using System;
using System.Text;

namespace CodeWarrior.Wars
{
    public class SplitStrings : IWar
    {
        public void Launch()
        {
            Console.WriteLine($"{string.Join(",", Solution("abc"))} should be = [ab, c_]");
            Console.WriteLine($"{string.Join(",", Solution("abcdef"))} should be = [ab, cd, ef]");
            Console.WriteLine($"{string.Join(",", Solution("VANDYGQPZ"))} should be = [VA, ND, YG, QP, Z_]");
        }

        public static string[] Solution(string str)
        {
            var resultArraySize = (int)Math.Ceiling(str.Length / 2f);
            var resultArray = new string[resultArraySize];
            var sb = new StringBuilder();
            var arrayIndex = 0;
            for (var i = 0; i < str.Length; i++)
            {
                sb.Append(str[i]);
                if (i != 0 && i % 2 == 1)
                {
                    resultArray[arrayIndex++] = sb.ToString();
                    sb.Clear();
                }
            }
            if(sb.Length > 0)
            {
                sb.Append('_');
                resultArray[arrayIndex++] = sb.ToString();
            }

            return resultArray;
        }
    }
}
