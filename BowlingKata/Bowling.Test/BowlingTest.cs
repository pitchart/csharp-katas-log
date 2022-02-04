using System;
using Xunit;

namespace Bowling.Test
{
    public class BowlingTest
    {
        [Fact]
        public void WhenNoPinShot_ShouldReturnZero()
        {
            // Arrange
            Bowling bowling = new Bowling();

            // Act
            for (int i = 0; i < 20; i++)
            {
                bowling.Roll(0);
            }

            int total = bowling.GetScore();

            // Assert
            Assert.Equal(total, 0);
        }
    }
}
