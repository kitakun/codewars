
using CodeWarrior.Wars;

using NUnit.Framework;

namespace TestWarrior
{
    [TestFixture]
    public class BitCountingTester
    {
        [Test]
        public void CountBits()
        {
            Assert.AreEqual(0, BitCountingWarrior.CountBits(0));
            Assert.AreEqual(1, BitCountingWarrior.CountBits(4));
            Assert.AreEqual(3, BitCountingWarrior.CountBits(7));
            Assert.AreEqual(2, BitCountingWarrior.CountBits(9));
            Assert.AreEqual(2, BitCountingWarrior.CountBits(10));
        }
    }
}
