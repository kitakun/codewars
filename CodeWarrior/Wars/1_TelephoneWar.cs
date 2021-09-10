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

        public unsafe static string CreatePhoneNumber_unsafe(int[] numbers)
        {
            int ind = 0;

            const int REQUIRED_NUMERS_TO_PRING = 10;
            const int REQUIRED_ADDITIONAL_SYMBOLS_COUNT = 4;
            const int ASCII_OFFSET_TO_NUMBERS = 48;

            var resultString = new string('0', REQUIRED_NUMERS_TO_PRING + REQUIRED_ADDITIONAL_SYMBOLS_COUNT);

            fixed (char* ptr = resultString)
            {
                ptr[0] = '(';
                ptr[1] = (char)(numbers[ind++] + ASCII_OFFSET_TO_NUMBERS);
                ptr[2] = (char)(numbers[ind++] + ASCII_OFFSET_TO_NUMBERS);
                ptr[3] = (char)(numbers[ind++] + ASCII_OFFSET_TO_NUMBERS);
                ptr[4] = ')';
                ptr[5] = ' ';
                ptr[6] = (char)(numbers[ind++] + ASCII_OFFSET_TO_NUMBERS);
                ptr[7] = (char)(numbers[ind++] + ASCII_OFFSET_TO_NUMBERS);
                ptr[8] = (char)(numbers[ind++] + ASCII_OFFSET_TO_NUMBERS);
                ptr[9] = '-';
                ptr[10] = (char)(numbers[ind++] + ASCII_OFFSET_TO_NUMBERS);
                ptr[11] = (char)(numbers[ind++] + ASCII_OFFSET_TO_NUMBERS);
                ptr[12] = (char)(numbers[ind++] + ASCII_OFFSET_TO_NUMBERS);
                ptr[13] = (char)(numbers[ind++] + ASCII_OFFSET_TO_NUMBERS);
            }

            return resultString;
        }

        public static string CreatePhoneNumber_span(int[] numbers)
        {
            int ind = 0;

            const int required_numbers_to_print = 10;
            const int required_additional_symbols_count = 4;
            const int ASCII_OFFSET_TO_NUMBERS = 48;

            Span<char> resultSpan = stackalloc char[required_numbers_to_print + required_additional_symbols_count];
            resultSpan[0] = '(';
            resultSpan[1] = (char)(numbers[ind++] + ASCII_OFFSET_TO_NUMBERS);
            resultSpan[2] = (char)(numbers[ind++] + ASCII_OFFSET_TO_NUMBERS);
            resultSpan[3] = (char)(numbers[ind++] + ASCII_OFFSET_TO_NUMBERS);
            resultSpan[4] = ')';
            resultSpan[5] = ' ';
            resultSpan[6] = (char)(numbers[ind++] + ASCII_OFFSET_TO_NUMBERS);
            resultSpan[7] = (char)(numbers[ind++] + ASCII_OFFSET_TO_NUMBERS);
            resultSpan[8] = (char)(numbers[ind++] + ASCII_OFFSET_TO_NUMBERS);
            resultSpan[9] = '-';
            resultSpan[10] = (char)(numbers[ind++] + ASCII_OFFSET_TO_NUMBERS);
            resultSpan[11] = (char)(numbers[ind++] + ASCII_OFFSET_TO_NUMBERS);
            resultSpan[12] = (char)(numbers[ind++] + ASCII_OFFSET_TO_NUMBERS);
            resultSpan[13] = (char)(numbers[ind++] + ASCII_OFFSET_TO_NUMBERS);

            return new string(resultSpan);
        }

    }
}
