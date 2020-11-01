using CodeWarrior.Wars;

using NUnit.Framework;

namespace TestWarrior
{
    [TestFixture]
    public class SplitStringsTester
    {
        [Test]
        public void BasicTests()
        {
            Assert.AreEqual(new string[] { "ab", "c_" }, SplitStrings.Solution("abc"));
            Assert.AreEqual(new string[] { "ab", "cd", "ef" }, SplitStrings.Solution("abcdef"));
            Assert.AreEqual(new string[] { "cd", "ab", "ef", "g_" }, SplitStrings.Solution("cdabefg"));
            Assert.AreEqual(new string[] { "ab", "cd" }, SplitStrings.Solution("abcd"));
            Assert.AreEqual(new string[] { "TN" }, SplitStrings.Solution("TN"));
            Assert.AreEqual(new string[] { "VA", "ND", "YG", "QP", "Z_" }, SplitStrings.Solution("VANDYGQPZ"));
        }
    }
}
