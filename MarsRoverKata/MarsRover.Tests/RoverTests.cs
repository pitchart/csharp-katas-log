using Xunit;

namespace MarsRover.Tests
{

    public class RoverTests
    {
        [Fact]
        public void ShouldMoveForward()
        {
            var command = "F";
            var rover = new Rover(2, 2, 'N');

            var result = rover.Move(command);

            Assert.Equal("3:2:N", result);
        }
    }

}
