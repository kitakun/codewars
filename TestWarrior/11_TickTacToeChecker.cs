namespace TestWarrior
{
    using System;

    using CodeWarrior.Wars;

    using NUnit.Framework;

    [TestFixture]
    public class TicTacToeTest
    {
        [Test]
        public void X_SHOULD_WON1()
        {
            int[,] board = new int[,] { { 1, 1, 1 }, { 0, 2, 2 }, { 0, 0, 0 } };
            Assert.AreEqual(1, new TickTacToeChecker_11().IsSolved(board));
        }

        [Test]
        public void X_SHOULD_WON2()
        {
            int[,] board = new int[,] {
                { 2, 1, 1 },
                { 0, 1, 2 },
                { 1, 0, 0 }
            };
            Assert.AreEqual(1, new TickTacToeChecker_11().IsSolved(board));
        }

        [Test]
        public void X_SHOULD_WON3()
        {
            int[,] board = new int[,] {
                { 2, 1, 2 },
                { 1, 1, 1 },
                { 1, 2, 0 }
            };
            Assert.AreEqual(1, new TickTacToeChecker_11().IsSolved(board));
        }

        [Test]
        public void X_SHOULD_WON4()
        {
            int[,] board = new int[,] {
                { 2, 1, 2 },
                { 1, 2, 1 },
                { 1, 1, 1 }
            };
            Assert.AreEqual(1, new TickTacToeChecker_11().IsSolved(board));
        }

        [Test]
        public void NOT_FINISHED()
        {
            int[,] board = new int[,] {
                { 0, 0, 2 },
                { 0, 0, 0 },
                { 1, 0, 1 }
            };
            Assert.AreEqual(-1, new TickTacToeChecker_11().IsSolved(board));
        }
    }
}
