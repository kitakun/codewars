using CodeWarrior.Wars;

using NUnit.Framework;

namespace TestWarrior
{
    [TestFixture]
    public class RomanNumeralsDecoderTester
    {
        [TestCase(1, "I")]
        [TestCase(2, "II")]
        [TestCase(5, "V")]
        [TestCase(7, "VII")]
        [TestCase(10, "X")]
        [TestCase(15, "XV")]
        [TestCase(50, "L")]
        [TestCase(55, "LV")]
        [TestCase(100, "C")]
        [TestCase(105, "CV")]
        [TestCase(155, "CLV")]
        [TestCase(500, "D")]
        [TestCase(1000, "M")]
        public void Test(int expected, string roman)
        {
            Assert.AreEqual(expected, RomanNumeralsDecoder.Solution(roman));
        }
    }
}
