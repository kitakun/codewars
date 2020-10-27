namespace TestWarrior
{
    using CodeWarrior.Wars;

    using NUnit.Framework;

    [TestFixture]
    public class SpinWordsTester
    {
        [Test]
        public static void Test1()
        {
            Assert.AreEqual("emocleW", SpinWordsWarrior.SpinWords("Welcome"));
        }

        [Test]
        public static void Test2()
        {
            Assert.AreEqual("Hey wollef sroirraw", SpinWordsWarrior.SpinWords("Hey fellow warriors"));
        }

        [Test]
        public static void Test3()
        {
            Assert.AreEqual("This is a test", SpinWordsWarrior.SpinWords("This is a test"));
        }

        [Test]
        public static void Test4()
        {
            Assert.AreEqual("This is rehtona test", SpinWordsWarrior.SpinWords("This is another test"));
        }

        [Test]
        public static void Test5()
        {
            Assert.AreEqual("You are tsomla to the last test", SpinWordsWarrior.SpinWords("You are almost to the last test"));
        }

        [Test]
        public static void Test6()
        {
            Assert.AreEqual("Just gniddik ereht is llits one more", SpinWordsWarrior.SpinWords("Just kidding there is still one more"));
        }
    }
}