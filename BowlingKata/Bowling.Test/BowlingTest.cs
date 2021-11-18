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

        [Fact]
        public void Should_score_18_when_one_strike_then_next_2_rolls_knocks_4_combined_pins()
        {
            // strike
            game.Roll(10);

            // x2
            game.Roll(1);
            game.Roll(3);

            for (int i = 0; i < 16; i++)
                game.Roll(0);

            var score = game.Score();

            Assert.Equal(18, score);
        }

        [Fact]
        public void Should_score_60_For_3_strikes_in_a_row_then_only_gutter_rolls()
        {
            // 3x strike
            game.Roll(10);
            game.Roll(10);
            game.Roll(10);

            for (int i = 0; i < 14; i++)
                game.Roll(0);

            var score = game.Score();

            Assert.Equal(60, score);
        }

        [Fact]
        public void Should_score_300_for_only_strike_rolls()
        {
            for (int i = 0; i < 12; i++)
                game.Roll(10);

            var score = game.Score();

            Assert.Equal(300, score);
        }
    }

}
