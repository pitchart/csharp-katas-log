namespace MarsRover.Tests
{
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
