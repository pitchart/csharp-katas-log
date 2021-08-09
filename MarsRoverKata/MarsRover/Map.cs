using System;

namespace MarsRover
{
    public class Map
    {
        private Obstacle obstacle;

        public Map()
        {
        }

        public Map(Obstacle obstacle)
        {
            this.obstacle = obstacle;
        }

        internal bool HasObstacleAt(Point newPosition)
        {
            return obstacle.Position.Equals(newPosition);
        }
    }
}
