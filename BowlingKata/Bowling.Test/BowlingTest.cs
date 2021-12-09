using FluentAssertions;
using Xunit;

namespace Bowling.Test
{

    public class BowlingTest
    {
        [Fact]
        public void Should_score_0_when_twenty_rolls_in_gutter()
        {
            //Arrange
            Bowling bowling = new Bowling();
            
            //Act
            for (int i = 0; i < 20; i++)
            {
                bowling.Roll(0);
            }

            int score = bowling.GetScore();

            //Assert
            score.Should().Be(0);
        }

        [Fact]
        public void Should_score_20_when_each_roll_is_1_pin()
        {
            //Arrange
            Bowling bowling = new Bowling();

            //Act
            for (int i = 0; i < 20; i++)
            {
                bowling.Roll(1);
            }

            int score = bowling.GetScore();

            //Assert
            score.Should().Be(20);
        }
    }

}
