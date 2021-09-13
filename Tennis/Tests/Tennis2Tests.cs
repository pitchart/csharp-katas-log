using FluentAssertions;
using Xunit;

namespace Tennis.Tests
{

    public class Tennis2Tests : TennisTestCases
    {
        public Tennis2Tests() : base(new TennisGame2("player1", "player2"))
        { }
        [Fact]
        public void ShouldDoNothingWhenUnknownPlayerAddPoint()
        {
            _game.WonPoint("UnknownPlayer");

            _game.GetScore().Should().Be("Love-All");
        }

        [Fact]
        public void ShouldAddPointWhenPlayerOneWonPoint()
        {
            var game = new TennisGame2("PlayerOne", "PlayerTwo");

            game.WonPoint("PlayerOne");

            game.GetScore().Should().Be("Fifteen-Love");
        }

        [Fact]
        public void ShouldPlayerOneTakeAdvantage()
        {
            var game = new TennisGame2("PlayerOne", "PlayerTwo");

            game.WonPoint("PlayerOne");
            game.WonPoint("PlayerOne");
            game.WonPoint("PlayerOne");

            game.WonPoint("PlayerTwo");
            game.WonPoint("PlayerTwo");
            game.WonPoint("PlayerTwo");

            game.WonPoint("PlayerOne");

            game.GetScore().Should().Be("Advantage PlayerOne");
        }

        [Fact]
        public void ShouldPlayerTwoTakeAdvantage()
        {
            var game = new TennisGame2("PlayerOne", "PlayerTwo");

            game.WonPoint("PlayerOne");
            game.WonPoint("PlayerOne");
            game.WonPoint("PlayerOne");

            game.WonPoint("PlayerTwo");
            game.WonPoint("PlayerTwo");
            game.WonPoint("PlayerTwo");

            game.WonPoint("PlayerTwo");

            game.GetScore().Should().Be("Advantage PlayerTwo");
        }

        [Fact]
        public void ShouldPlayerOneWin()
        {
            var game = new TennisGame2("PlayerOne", "PlayerTwo");

            game.WonPoint("PlayerOne");
            game.WonPoint("PlayerOne");
            game.WonPoint("PlayerOne");

            game.WonPoint("PlayerTwo");
            game.WonPoint("PlayerTwo");
            game.WonPoint("PlayerTwo");

            game.WonPoint("PlayerOne");
            game.WonPoint("PlayerOne");

            game.GetScore().Should().Be("Win for PlayerOne");
        }

        [Fact]
        public void ShouldPlayerTwoWin()
        {
            var game = new TennisGame2("PlayerOne", "PlayerTwo");

            game.WonPoint("PlayerOne");
            game.WonPoint("PlayerOne");
            game.WonPoint("PlayerOne");

            game.WonPoint("PlayerTwo");
            game.WonPoint("PlayerTwo");
            game.WonPoint("PlayerTwo");

            game.WonPoint("PlayerTwo");
            game.WonPoint("PlayerTwo");

            game.GetScore().Should().Be("Win for PlayerTwo");
        }
    }

}
