using FluentAssertions;
using Xunit;

namespace Bowling.Test
{

    public class BowlingTest
    {
        [Fact]
        public void Bowling_WhenPlayingTheEntireGameWithOnlyGutter_ShouldReturnAScoreOf0()
        {
            //Arrange
            const int fullGame = 20;
            const int expectedScore = 0;
            Bowling bowling = new Bowling();
            
            //Act
            for (int i = 0; i < fullGame; i++)
            {
                bowling.Roll(0);
            }

            int score = bowling.GetScore();

            //Assert
            score.Should().Be(expectedScore);
        }
    }

}
