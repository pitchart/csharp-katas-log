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
        [InlineData('W', "2:2:N")]
        [InlineData('N', "2:2:E")]
        public void ShouldTurnRight(char direction, string expectedResult)
        {
            ///Arrange
            var rover = new Rover(2, 2, direction);


            ///Act
            var result = rover.Move("R");


            ///Assert
            Assert.Equal(expectedResult, result);
        }

        [Theory]
        [InlineData('N', "2:2:W")]
        [InlineData('E', "2:2:N")]
        [InlineData('S', "2:2:E")]
        [InlineData('W', "2:2:S")]
        public void ShouldTurnLeft(char direction, string expectedResult)
        {
            ///Arrange
            var rover = new Rover(2, 2, direction);


            ///Act
            var result = rover.Move("L");


            ///Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public void ShouldOnlyAcceptValidCommand()
        {
            ///Arrange
            var rover = new Rover(2, 2, 'N');

            ///Act
            var result = rover.Move("A");

            ///Assert
            Assert.Equal("E:2:2:N", result);
        }

    }

    public class RoverBuilder
    {
        private int x = 2;
        private int y = 2;
        private char direction = 'N';

        public Rover Build()
        {
            return new Rover(x, y, direction);
        }

        public RoverBuilder LandingAt(int x, int y)
        {
            this.x = x;
            this.y = y;
            return this;
        }

        public RoverBuilder Facing(char direction)
        {
            this.direction = direction;
            return this;
        }

        public static RoverBuilder Create()
        {
            return new RoverBuilder();
        }
    }

}
