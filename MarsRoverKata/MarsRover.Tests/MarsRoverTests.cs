using Xunit;

namespace MarsRover.Tests
{
    public class MarsRoverTests
    {
        [Fact]
        public void RoverShouldMoveEverywhereOnMars()
        {
            var command = "FFLFRRFFRF";
            var rover = new Rover(2,2,'N');

            var result = rover.Move(command);

            Assert.Equal("3:3:S", result);
        }

        [Fact]
        public void RoverShouldWrappedAtEdgies()
        {
            var command = "FLFLFLFLF";
            var rover = new Rover(0, 0, 'W');

            var result = rover.Move(command);

            Assert.Equal("4:0:W", result);
        }
    }
}
