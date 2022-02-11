using System;
using Xunit;

namespace Bowling.Test
{

    public class BowlingTest
    {
        private readonly Bowling _bowling = new Bowling();

        [Fact]
        public void ScoreShouldBeZeroWhenAllRollsGoesToGutter()
        {


            // ACT
            for (int i = 1; i <= 20; i++)
            {
                _bowling.Roll(0);
            }

            // ASSERT
            Assert.Equal(0, _bowling.Score());
        }

        [Fact]
        public void ScoreShouldBeTheSumOfAllPinsWhenNoBonus()
        {

            // ACT
            for (int i = 1; i <= 20; i++)
            {
                _bowling.Roll(2);
            }

            // ASSERT
            Assert.Equal(40, _bowling.Score());
        }

        [Fact]
        public void ScoreShouldBeTheSumOfAllPinsAndBonusWhenOneSpareHasBeenHit()
        {

            // ACT

            _bowling.Roll(2);
            _bowling.Roll(8);

            for (int i = 3; i <= 20; i++)
            {
                _bowling.Roll(2);
            }

            // ASSERT
            Assert.Equal(48, _bowling.Score());
        }


        [Fact]
        public void ScoreShouldBeTheSumOfAllPinsAndBonusWhenOneStrikeHasBeenHit()
        {

            // ACT

            _bowling.Roll(10);

            for (int i = 3; i <= 20; i++)
            {
                _bowling.Roll(2);
            }

            // ASSERT
            Assert.Equal(50, _bowling.Score());
        }
    }

}
