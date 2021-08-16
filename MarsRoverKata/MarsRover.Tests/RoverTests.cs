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
            var map = MapBuilder.Create().Build();
            var rover = RoverBuilder.Create().LandingAt(2, 2).Facing(direction).NavigatingOn(map).Build();

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
            var rover = RoverBuilder.Create().LandingAt(2, 2).Facing(direction).Build();


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
            var rover = RoverBuilder.Create().LandingAt(2, 2).Facing(direction).Build();


            ///Act
            var result = rover.Move("L");


            ///Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public void ShouldOnlyAcceptValidCommand()
        {
            ///Arrange
            var rover = RoverBuilder.Create().LandingAt(2, 2).Facing('N').Build();

            ///Act
            var result = rover.Move("A");

            ///Assert
            Assert.Equal("E:2:2:N", result);
        }

        [Theory]
        [InlineData(4, 4, 'N', "4:0:N")]
        [InlineData(4, 4, 'E', "0:4:E")]
        [InlineData(0, 0, 'S', "0:4:S")]
        [InlineData(0, 0, 'W', "4:0:W")]
        public void ShouldMoveForwardToEdgies(int x, int y, char direction, string expectedResult)
        {
            var rover = RoverBuilder.Create().LandingAt(x, y).Facing(direction).Build();

            var result = rover.Move("F");

            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public void ShouldStopWhenEncounterAnObstacle()
        {
            var command = "FFF";
            var obstacle = new Obstacle(3, 0);
            var mars = new Map(obstacle);
            var rover = RoverBuilder.Create().LandingAt(0, 0).Facing('E').NavigatingOn(mars).Build();

            var result = rover.Move(command);

            Assert.EndsWith("2:0:E", result);
        }

        [Fact]
        public void ShouldStopWhenEncounterAnObstacleAndNotifyInResponse()
        {
            var command = "FFF";
            var obstacle = new Obstacle(3, 0);
            var mars = new Map(obstacle);
            var rover = RoverBuilder.Create().LandingAt(0, 0).Facing('E').NavigatingOn(mars).Build();

            var result = rover.Move(command);

            Assert.StartsWith("O:", result);
        }
    }
}
