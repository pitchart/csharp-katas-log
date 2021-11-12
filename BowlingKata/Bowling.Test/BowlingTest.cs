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

        [Fact]
        public void Should_score_20_when_one_spare_then_next_roll_knocks_5_pins()
        {
            //spare
            game.Roll(6);
            game.Roll(4);

            //x2
            game.Roll(5);

            for (int i = 0; i < 17; i++)
                game.Roll(0);

            var score = game.Score();

            Assert.Equal(20, score);
        }
    }

}
