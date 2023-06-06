using FluentAssertions;
using Xunit;

namespace Tennis
{
    public class TennisScoreTests
    {
        private readonly Player Federer = new Player("Roger Federer");

        private readonly Player Nadal = new Player("Rafael Nadal");

        private Game NadalVsFederer()
        {
            return new Game(Nadal, Federer);
        }

        [Fact]
        public void love_all()
        {
            var game = NadalVsFederer();

            game.Score().Should()
                .Be("Love-All");
        }
    }

    public record Player(string Name);

    public class Game
    {
        public Game(Player server, Player receiver)
        {

        }

        public string Score()
        {
            return "Love-All";
        }
    }


}
