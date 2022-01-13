using System;
using Xunit;

namespace Tennis.Tests
{

    public abstract class TennisTestCases
    {
        private readonly ITennisGame _game;

        protected TennisTestCases(ITennisGame game)
        {
            this._game = game;
        }

        [Theory]
        [ClassData(typeof(TestDataGenerator))]
        public void TennisGameTest(int p1, int p2, string expected)
        {
            CheckAllScores(p1, p2, expected);
        }

        private void CheckAllScores(int player1Score, int player2Score, string expectedScore)
        {
            var highestScore = Math.Max(player1Score, player2Score);
            for (var i = 0; i < highestScore; i++)
            {
                if (i < player1Score)
                    _game.WonPoint("player1");
                if (i < player2Score)
                    _game.WonPoint("player2");
            }

            Assert.Equal(expectedScore, _game.GetScore());
        }
    }

}
