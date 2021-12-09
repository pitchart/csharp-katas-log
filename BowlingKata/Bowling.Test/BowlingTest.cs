using FluentAssertions;
using Xunit;

namespace Bowling.Test
{

    public class BowlingTest
    {
        [Theory]
        [InlineData(0,0)]
        [InlineData(1, 20)]
        public void Should_score_total_fallen_pins_when_twenty_rolls_with_neither_strikes_nor_spares(int fallenPinsPerRoll, int expectedScore)
        {
            //Arrange
            Bowling bowling = new Bowling();
            
            //Act
            for (int i = 0; i < 20; i++)
            {
                bowling.Roll(fallenPinsPerRoll);
            }

            int score = bowling.GetScore();

            //Assert
            score.Should().Be(expectedScore);
        }

        [Fact]
        public void Should_score_total_fallen_pins_and_bonuses_when_twenty_rolls_with_one_spare_at_first_throw()
        {
            //Arrange
            Bowling bowling = new Bowling();


            //Act
            bowling.Roll(5);
            bowling.Roll(5);


            for (int i = 2; i < 20; i++)
            {
                bowling.Roll(1);
            }

            int score = bowling.GetScore();

            //Assert
            score.Should().Be(29);
        }


    }

}
