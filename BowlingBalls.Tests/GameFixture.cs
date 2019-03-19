using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BowlingBall.Tests
{
    [TestClass]
    public class GameFixture
    {
        [TestMethod]
        public void GetScores_WhenCombinationOfPins_ComboOne_ExpectCorrectScore()
        {
            var game = new Game(10, 10);
            var pins = new int[] { 10, 9, 1, 5, 5, 7, 2, 10, 10, 10, 9, 0, 8, 2, 9, 1, 10 };
            foreach (var item in pins)
            {
                game.Roll(item);
            }
            Assert.AreEqual(187, game.GetScore());
        }

        [TestMethod]
        public void GetScores_WhenCombinationOfPins_ComboTwo_ExpectCorrectScore()
        {
            var game = new Game(10, 10);
            var pins = new int[] { 4, 2, 2, 7, 9, 1, 10, 3, 6, 7, 3, 2, 4, 4, 6, 4, 4, 5, 5, 9 };
            foreach (var item in pins)
            {
                game.Roll(item);
            }
            Assert.AreEqual(122, game.GetScore());
        }

        [TestMethod]
        public void GetScores_WhenCombinationOfPins_ComboThree_ExpectCorrectScore()
        {
            var game = new Game(10, 10);
            var pins = new int[] { 10, 9, 1, 3, 7, 5, 5, 10, 4, 6, 10, 5, 5, 10, 3, 7, 3 };
            foreach (var item in pins)
            {
                game.Roll(item);
            }
            Assert.AreEqual(181, game.GetScore());
        }

        [TestMethod]
        public void GetScores_WhenCombinationOfPins_ComboFour_ExpectCorrectScore()
        {
            var game = new Game(10, 10);
            var pins = new int[] { 10, 9, 1, 8, 2, 7, 0, 2, 6, 10, 3, 0, 4, 6, 0, 10, 8, 2, 10};
            foreach (var item in pins)
            {
                game.Roll(item);
            }
            Assert.AreEqual(134, game.GetScore());
        }

        [TestMethod]
        public void GetScores_WhenAllStrikes_ComboOneWithExtraRolls_ExpectCorrectScore()
        {
            var game = new Game(10, 10);
            Roll(game, 10, 15);
            Assert.AreEqual(300, game.GetScore());
        }

        [TestMethod]
        public void GetScores_WhenAllStrikes_ComboOne_ExpectCorrectScore()
        {
            var game = new Game(10, 10);
            var pins = new int[] { 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10 };
            foreach (var item in pins)
            {
                game.Roll(item);
            }
            Assert.AreEqual(300, game.GetScore());
        }


        [TestMethod]
        public void GetScores_WhenAllSpares_ExpectCorrectScore()
        {
            var game = new Game(10, 10);
            var pins = new int[] { 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5 };
            foreach (var item in pins)
            {
                game.Roll(item);
            }
            Assert.AreEqual(150, game.GetScore());
        }

        [TestMethod]
        public void GetScores_WhenAllGutters_ExpectCorrectScore()
        {
            var game = new Game(10, 10);
            Roll(game, 0, 30);
            Assert.AreEqual(0, game.GetScore());
        }

        #region helpers
        private void Roll(Game game, int pins, int times)
        {
            for (int i = 0; i < times; i++)
            {
                game.Roll(pins);
            }
        }
        #endregion
    }
}
