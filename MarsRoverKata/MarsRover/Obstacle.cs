namespace MarsRover
{
    public class Obstacle
    {
        public Point Position { get; }

        public Obstacle(int x, int y)
        {
            this.Position = new Point(x, y);
        }
    }
}
