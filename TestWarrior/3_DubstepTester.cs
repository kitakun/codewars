using CodeWarrior.Wars;

using NUnit.Framework;

namespace TestWarrior
{
    public class DubstepTester
    {
        [TestFixture]
        public class DubstepTests
        {
            [Test]
            public void Test1()
            {
                Assert.AreEqual("ABC", DubstepWarrior.SongDecoder("WUBWUBABCWUB"));
            }

            [Test]
            public void Test2()
            {
                Assert.AreEqual("R L", DubstepWarrior.SongDecoder("RWUBWUBWUBLWUB"));
            }
        }
    }
}