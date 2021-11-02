using System;
using Xunit;

namespace Tennis.Tests
{

    public class Tennis1Tests : TennisTestCases
    {
        public Tennis1Tests() : base(new TennisGame1("player1", "player2"))
        { }

        [Fact]
        public void Should_IncrementFirstPlayerScore_WhenFirstPlayerScores()
        {
            TennisGame1 tennisGame1 = new TennisGame1("Roger", "Rafael");

            tennisGame1.WonPoint("Roger");

            var score = tennisGame1.GetScore();

            Assert.Equal("Fifteen-Love", score);
        }

        [Fact]
        public void Should_IncrementSecondPlayerScore_WhenSecondPlayerScores()
        {
            TennisGame1 tennisGame1 = new TennisGame1("Roger", "Rafael");

            tennisGame1.WonPoint("Rafael");

            var score = tennisGame1.GetScore();

            Assert.Equal("Love-Fifteen", score);
        }

        [Fact]
        public void Should_NotIncrementScore_WhenAnotherPlayerScores()
        {
            TennisGame1 tennisGame1 = new TennisGame1("Roger", "Rafael");

            tennisGame1.WonPoint("Novak");

            var score = tennisGame1.GetScore();

            Assert.Equal("Love-All", score);
        }

        [Fact]
        public void Should_NotPlayAGame_WhenPlayersHaveTheSameName()
        {
            Assert.Throws<ArgumentException>(() => new TennisGame1("Williams", "Williams"));
        }

        [Fact]
        public void Should_AnnounceWinnerName_WhenFirstPlayerWins()
        {
            TennisGame1 tennisGame1 = new TennisGame1("Roger", "Rafael");

            tennisGame1.WonPoint("Roger");
            tennisGame1.WonPoint("Roger");
            tennisGame1.WonPoint("Roger");
            tennisGame1.WonPoint("Roger");

            var score = tennisGame1.GetScore();
            Assert.Equal("Win for Roger", score);
        }
    }

}
