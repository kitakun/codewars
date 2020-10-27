using System;
using System.Text;

namespace CodeWarrior.Wars
{
    public class TelephoneWar : IWar
    {
        public void Launch()
        {
            Console.WriteLine(CreatePhoneNumber(new int[] { }));
            Console.WriteLine(CreatePhoneNumber(new int[] { 1 }));
            Console.WriteLine(CreatePhoneNumber(new int[] { 1, 2 }));
            Console.WriteLine(CreatePhoneNumber(new int[] { 1, 2, 3 }));
            Console.WriteLine(CreatePhoneNumber(new int[] { 1, 2, 3, 4 }));
            Console.WriteLine(CreatePhoneNumber(new int[] { 1, 2, 3, 4, 5 }));
            Console.WriteLine(CreatePhoneNumber(new int[] { 1, 2, 3, 4, 5, 6 }));
            Console.WriteLine(CreatePhoneNumber(new int[] { 1, 2, 3, 4, 5, 6, 7 }));
            Console.WriteLine(CreatePhoneNumber(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 }));
            Console.WriteLine(CreatePhoneNumber(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 0 }));
        }

        public static string CreatePhoneNumber(int[] numbers)
        {
            if (numbers != null && numbers.Length > 9)
            {
                int ind = 0;
                return $"({numbers[ind++]}{numbers[ind++]}{numbers[ind++]}) {numbers[ind++]}{numbers[ind++]}{numbers[ind++]}-{numbers[ind++]}{numbers[ind++]}{numbers[ind++]}{numbers[ind++]}";
            }
            else if (numbers != null && numbers.Length > 0)
            {
                var sb = new StringBuilder("(");
                for (var i = 0; i < numbers.Length && i < 10; i++)
                {
                    sb.Append(numbers[i]);
                    if (i <= 2)
                    {
                        if (i == 2)
                        {
                            sb.Append(") ");
                        }
                    }
                    else if (i >= 3 && i <= 5)
                    {
                        if (i == 5)
                        {
                            sb.Append("-");
                        }
                    }
                }
                return sb.ToString();
            }

            return string.Empty;
        }
    }
}
