namespace MarsRover.Tests
{
    public class MapBuilder
    {
        private Obstacle obstacle;

        public static MapBuilder Create()
        {
            return new MapBuilder();
        }

        public Map Build()
        {
            return new Map(obstacle);
        }

        public MapBuilder WithObstacle(Obstacle obstacle)
        {
            this.obstacle = obstacle;
            return this;
        }
    }
}
