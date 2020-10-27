namespace TestWarrior
{
    using CodeWarrior.Wars;

    using NUnit.Framework;

    [TestFixture]
    public class BinaryAdditionTester
    {
        [Test]
        public void TestExample()
        {
            Assert.AreEqual("11", BinaryAdditionWarrior.AddBinary(1, 2), "Should return \"11\" for 1 + 2");
        }
    }
}
