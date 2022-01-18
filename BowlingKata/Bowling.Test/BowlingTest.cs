using System;
using Xunit;

namespace Bowling.Test
{
    public class BowlingTest
    {
        [Fact]
        public void Score_should_be_zero_when_all_missing_tries()
        {
            Bowling bowling = new Bowling();

            for (int i = 0; i < 20; i++)
            {
                bowling.Roll(0);
            }

            var score = bowling.Score();

            Assert.Equal(0, score);
        }

        [Fact]
        public void Score_should_be_tweenty_pins_all_rolls_hits_one_pin()
        {
            Bowling bowling = new Bowling();

            for (int i = 0; i < 20; i++)
            {
                bowling.Roll(1);
            }

            var score = bowling.Score();

            Assert.Equal(20, score);
        }

        [Fact]
        public void Score_should_have_bonus_for_spare()
        {
            Bowling bowling = new Bowling();

            bowling.Roll(3);
            bowling.Roll(7);

            for (int i = 0; i < 18; i++)
            {
                bowling.Roll(1);
            }

            var score = bowling.Score();

            Assert.Equal(29, score);
        }

        [Fact]
        public void Score_should_have_bonus_for_strike()
        {
            Bowling bowling = new Bowling();

            bowling.Roll(10);

            for (int i = 0; i < 18; i++)
            {
                bowling.Roll(1);
            }

            var score = bowling.Score();

            Assert.Equal(30, score);
        }

        [Fact]
        public void Score_should_have_bonus_for_successive_strikes()
        {
            Bowling bowling = new Bowling();

            bowling.Roll(10);
            bowling.Roll(10);

            for (int i = 0; i < 16; i++)
            {
                bowling.Roll(1);
            }

            var score = bowling.Score();

            Assert.Equal(49, score);
        }

        [Fact]
        public void Score_should_have_spare_bonus_when_striking_10_pins_on_second_roll_turn()
        {
            Bowling bowling = new Bowling();

            bowling.Roll(0);
            bowling.Roll(10);

            for (int i = 0; i < 18; i++)
            {
                bowling.Roll(1);
            }

            var score = bowling.Score();

            Assert.Equal(29, score);
        }

        [Fact]
        public void Score_should_have_bonus_roll_when_scoring_spare_on_last_turn()
        {
            Bowling bowling = new Bowling();

            for (int i = 0; i < 18; i++)
            {
                bowling.Roll(1);
            }

            bowling.Roll(0);
            bowling.Roll(10);
            bowling.Roll(1);

            var score = bowling.Score();

            Assert.Equal(29, score);
        }

        [Fact]
        public void Score_should_have_bonus_rolls_when_scoring_strike_on_last_turn()
        {
            Bowling bowling = new Bowling();

            for (int i = 0; i < 12; i++)
            {
                bowling.Roll(10);
            }
            
            var score = bowling.Score();

            Assert.Equal(300, score);
        }
    }
}
