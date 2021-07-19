using Xunit;

namespace MarsRover.Tests
{

    public class RoverTests
    {
        [Theory]
        [InlineData("F", 'E', "3:2:E")]
        [InlineData("FF", 'E', "4:2:E")]
        [InlineData("FF", 'S', "2:0:S")]
        [InlineData("FF", 'N', "2:4:N")]
        [InlineData("FF", 'W', "0:2:W")]
        public void ShouldMoveForward(string command, char direction, string expectedResult)
        {
            var rover = new Rover(2, 2, direction);

            var result = rover.Move(command);

            Assert.Equal(expectedResult, result);
        }


        [Theory]
        [InlineData('E', "2:2:S")]
        [InlineData('S', "2:2:W")]
        public void ShouldTurnRight(char direction, string expectedResult)
        {
            ///Arrange
            var rover = new Rover(2, 2, direction);


            ///Act
            var result = rover.Move("R");


            ///Assert
            Assert.Equal(expectedResult, result);
        }
    }

}
