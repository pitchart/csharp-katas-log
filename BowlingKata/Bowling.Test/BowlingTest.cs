using Xunit;

namespace Bowling.Test
{

    public class BowlingTest
    {
        private readonly Bowling game;

        public BowlingTest()
        {
            game = new Bowling();
        }

        [Fact]
        public void Should_score_zero_when_all_rolls_go_to_the_gutter()
        {
            for (int i = 0; i < 20; i++)
                game.Roll(0);

            var score = game.Score();

            Assert.Equal(0, score);
        }

        [Fact]
        public void Should_score_40_when_all_rolls_knocks_two_pins()
        {
            for (int i = 0; i < 20; i++)
                game.Roll(2);

            var score = game.Score();

            Assert.Equal(40, score);
        }
    }

}
