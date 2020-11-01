using CodeWarrior.Wars;

using NUnit.Framework;

namespace TestWarrior
{
    [TestFixture]
    public class SumOfDigitsTester
    {
        private SumOfDigits _num;

        [SetUp]
        public void SetUp()
        {
            _num = new SumOfDigits();
        }

        [TearDown]
        public void TearDown()
        {
            _num = null;
        }

        [Test]
        public void Tests()
        {
            Assert.AreEqual(7, _num.DigitalRoot(16));
            Assert.AreEqual(6, _num.DigitalRoot(456));
        }
    }
}
