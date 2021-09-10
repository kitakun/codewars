namespace CodeWarrior.Benchmark
{
    using BenchmarkDotNet.Attributes;

    using CodeWarrior.Wars;

    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text.RegularExpressions;

    [MemoryDiagnoser]
    [Orderer(BenchmarkDotNet.Order.SummaryOrderPolicy.FastestToSlowest)]
    [RankColumn]
    public class TelephoneWarBenchmarks
    {
        public IEnumerable<int[]> ValuesForTest => new[] {
            //new int[] { },
            //new int[] { 1 },
            //new int[] { 1, 2 },
            //new int[] { 1, 2, 3 },
            //new int[] { 1, 2, 3, 4 },
            //new int[] { 1, 2, 3, 4, 5 },
            //new int[] { 1, 2, 3, 4, 5, 6 },
            //new int[] { 1, 2, 3, 4, 5, 6, 7 },
            //new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 },
            new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 0 },
        };

        [ParamsSource(nameof(ValuesForTest))]
        public int[] PhoneNumber { get; set; }

        [Benchmark]
        public void Benchmark_MyImplementation()
        {
            try
            {
                var r = TelephoneWar.CreatePhoneNumber(PhoneNumber);
            }
            catch
            {

            }
        }

        [Benchmark]
        public void Benchmark_MyImplementation_unsafe()
        {
            try
            {
                var r = TelephoneWar.CreatePhoneNumber_unsafe(PhoneNumber);
            }
            catch
            {

            }
        }

        [Benchmark(Baseline = true)]
        public void Benchmark_MyImplementation_spam()
        {
            try
            {
                var r = TelephoneWar.CreatePhoneNumber_span(PhoneNumber);
            }
            catch
            {

            }
        }

        #region Other users solutions
        //[Benchmark]
        public void Benchmark_OtherImplementation_1()
        {
            try
            {
                var r = long.Parse(string.Concat(PhoneNumber)).ToString("(000) 000-0000");
            }
            catch { }
        }
        [Benchmark]
        public void Benchmark_OtherImplementation_2()
        {
            try
            {
                var n = PhoneNumber;
                var r = "(" + n[0] + n[1] + n[2] + ") " + n[3] + n[4] + n[5] + "-" + n[6] + n[7] + n[8] + n[9]; ;
            }
            catch { }
        }
       // [Benchmark]
        public void Benchmark_OtherImplementation_3()
        {
            try
            {
                var r = new Regex("(...)(...)(....)").Replace(String.Concat(PhoneNumber), "($1) $2-$3");
            }
            catch { }
        }
        //[Benchmark]
        public void Benchmark_OtherImplementation_4()
        {
            try
            {
                var r = string.Format("({0}{1}{2}) {3}{4}{5}-{6}{7}{8}{9}", PhoneNumber.Select(x => x.ToString()).ToArray());
            }
            catch { }
        }
        //[Benchmark]
        public void Benchmark_OtherImplementation_5()
        {
            try
            {
                var numbers = PhoneNumber;
                var r = String.Format("({0}) {1}-{2}",
                      numbers.Take(3).Select(n => n.ToString()).Aggregate((a, b) => a + b),
                      numbers.Skip(3).Take(3).Select(n => n.ToString()).Aggregate((a, b) => a + b),
                      numbers.Skip(6).Take(4).Select(n => n.ToString()).Aggregate((a, b) => a + b));
            }
            catch { }
        }
        #endregion
    }
}
