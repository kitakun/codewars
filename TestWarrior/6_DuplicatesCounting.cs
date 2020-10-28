using CodeWarrior.Wars;

using NUnit.Framework;

namespace TestWarrior
{
    [TestFixture]
    public class DuplicatesCountingTester
    {
        [Test]
        public void KataTests()
        {
            Assert.AreEqual(0, DuplicatesCounting.DuplicateCount(""));
            Assert.AreEqual(0, DuplicatesCounting.DuplicateCount("abcde"));
            Assert.AreEqual(2, DuplicatesCounting.DuplicateCount("aabbcde"));
            Assert.AreEqual(2, DuplicatesCounting.DuplicateCount("aabBcde"), "should ignore case");
            Assert.AreEqual(1, DuplicatesCounting.DuplicateCount("Indivisibility"));
            Assert.AreEqual(2, DuplicatesCounting.DuplicateCount("Indivisibilities"), "characters may not be adjacent");
        }
    }
}
