using Xunit;

namespace MarsRover.Tests
{
    public class MarsRoverAcceptanceTests
    {
        [Fact]
        public void RoverShouldMoveEverywhereOnMars()
        {
            var command = "FFLFRRFFRF";
            var rover = RoverBuilder.Create().LandingAt(2, 2).Facing('N').Build();

            var result = rover.Move(command);

            Assert.Equal("3:3:S", result);
        }

        [Fact]
        public void RoverShouldWrappedAtEdgies()
        {
            var command = "FLFLFLFLF";
            var rover = RoverBuilder.Create().LandingAt(0, 0).Facing('W').Build();

            var result = rover.Move(command);

            Assert.Equal("4:0:W", result);
        }

        [Fact]
        public void RoverShouldStopWhenObstacleDetected()
        {
            var command = "FFF";
            var obstacle = new Obstacle(3, 0);
            var mars = MapBuilder.Create().WithObstacle(obstacle).Build();
            var rover = RoverBuilder.Create().LandingAt(0, 0).Facing('E').NavigatingOn(mars).Build();

            var result = rover.Move(command);

            Assert.Equal("O:2:0:E", result);
        }
    }
}
