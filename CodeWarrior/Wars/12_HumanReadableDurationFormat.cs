namespace CodeWarrior.Wars
{
    using System;
    using System.Text;

    /// <summary>
    /// formatDuration (62)    // returns "1 minute and 2 seconds"
    /// formatDuration (3662)  // returns "1 hour, 1 minute and 2 seconds"
    /// 4 kyu
    /// </summary>
    public sealed class HumanReadableDurationFormat_12 : IWar
    {
        const string YEAR_STRING = "year";
        const string DAY_STRING = "day";
        const string HOUR_STRING = "hour";
        const string MINUTE_STRING = "minute";
        const string SECONDS_STRING = "second";

        const string multipleDatePostfix = "s";
        const string lastDatePreposition = "and";
        const string nowDateString = "now";

        const string spaceSymbol = "_";

        public void Launch()
        {
            Console.WriteLine(formatDuration(205851834));
        }

        public static string formatDuration(int seconds)
        {
            if (seconds == 0)
            {
                return nowDateString;
            }

            const long secondsInMinute = 60;
            const long secondsInHour = secondsInMinute * 60;
            const long secondsInDay = secondsInHour * 24;
            const long secondsInYear = 365 * secondsInDay;

            var builder = new StringBuilder();

            long remainingSeconds = seconds;
            string lastString = null;

            void formatDate(long inputValue, string singleDate)
            {
                if (inputValue <= remainingSeconds)
                {
                    var dateDiff = remainingSeconds / inputValue;
                    var dateValue = (int)MathF.Floor(dateDiff);
                    var parsedValue = dateValue * inputValue;
                    remainingSeconds -= parsedValue;

                    if (builder.Length > 0)
                    {
                        builder.Append(spaceSymbol);
                    }
                    lastString = $"{dateValue} {(dateValue == 1 ? singleDate : $"{singleDate}{multipleDatePostfix}")}";
                    builder.Append(lastString);
                }
            }

            formatDate(secondsInYear, YEAR_STRING);
            formatDate(secondsInDay, DAY_STRING);
            formatDate(secondsInHour, HOUR_STRING);
            formatDate(secondsInMinute, MINUTE_STRING);
            formatDate(1, SECONDS_STRING);
            
            if (builder.Length != lastString.Length)
            {
                builder.Replace(lastString, $"{lastDatePreposition} {lastString}");
            }

            builder.Replace($"{spaceSymbol}{lastDatePreposition}", $" {lastDatePreposition}");
            builder.Replace(spaceSymbol, ", ");

            return builder.ToString();
        }
    }
}
