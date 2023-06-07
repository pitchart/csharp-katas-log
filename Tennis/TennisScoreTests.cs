using FluentAssertions;
using Tennis.ScoresHandler;
using Xunit;

namespace Tennis
{
    public class TennisScoreTests
    {
        private readonly Player Federer = new("Roger Federer");

        private readonly Player Nadal = new("Rafael Nadal");

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

        [Fact]
        public void fifteen_love()
        {
            var game = NadalVsFederer();

            game.PointTo(Nadal);

            game.Score().Should()
                .Be("Fifteen-Love");
        }

        [Fact]
        public void thirty_love()
        {
            var game = NadalVsFederer();

            game.PointTo(Nadal);
            game.PointTo(Nadal);

            game.Score().Should()
                .Be("Thirty-Love");
        }
    }

    public record Player(string Name);

    public class Game
    {
        internal IScoreState _score;
        
        public Game(Player server, Player receiver)
        {
            _score = new Points(0, 0);
        }

        public string Score()
        {
            return _score.Score();
        }

        public void PointTo(Player player)
        {
            _score.PointTo(player, this);
        }
    }

    public class Points : IScoreState
    {
        private readonly Point _point1;

        private readonly Point _point2;

        public Points(Point point1, Point point2)
        {
            _point1 = point1;
            _point2 = point2;
        }

        public void PointTo(Player player, Game game)
        {
            game._score = new Points(_point1+1, Point.Love);
        }

        public string Score()
        {
            if (_point1 > 0)
            {
                return $"{_point1}-{_point2}";
            }

            return $"{_point1}-All";
        }
    }

    public enum Point
    {
        Love,
        Fifteen
    }

    internal interface IScoreState
    {
        void PointTo(Player player, Game game);
        string Score();
    }
}
