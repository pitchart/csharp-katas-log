using System;
using Xunit;

namespace Tennis.Tests
{

    public class Tennis3Tests : TennisTestCases
    {
        public Tennis3Tests() : base(new TennisGame3("player1", "player2"))
        {}

        [Fact]
        public void Should_IncrementFirstPlayerScore_WhenFirstPlayerScores()
        {
            TennisGame3 tennisGame3 = new TennisGame3("Roger", "Rafael");

            tennisGame3.WonPoint("Roger");

            var score = tennisGame3.GetScore();

            Assert.Equal("Fifteen-Love", score);
        }

        [Fact]
        public void Should_IncrementSecondPlayerScore_WhenSecondPlayerScores()
        {
            TennisGame3 tennisGame3 = new TennisGame3("Roger", "Rafael");

            tennisGame3.WonPoint("Rafael");

            var score = tennisGame3.GetScore();

            Assert.Equal("Love-Fifteen", score);
        }

        [Fact]
        public void Should_NotIncrementScore_WhenAnotherPlayerScores()
        {
            TennisGame3 tennisGame3 = new TennisGame3("Roger", "Rafael");

            tennisGame3.WonPoint("Novak");

            var score = tennisGame3.GetScore();

            Assert.Equal("Love-All", score);
        }

        [Fact]
        public void Should_NotPlayAGame_WhenPlayersHaveTheSameName()
        {
            Assert.Throws<ArgumentException>(() => new TennisGame3("Williams", "Williams"));
        }

        [Fact]
        public void Should_AnnounceWinnerName_WhenFirstPlayerWins()
        {
            TennisGame3 tennisGame3 = new TennisGame3("Roger", "Rafael");

            tennisGame3.WonPoint("Roger");
            tennisGame3.WonPoint("Roger");
            tennisGame3.WonPoint("Roger");
            tennisGame3.WonPoint("Roger");

            var score = tennisGame3.GetScore();
            Assert.Equal("Win for Roger", score);
        }
    }

}
