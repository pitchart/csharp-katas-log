namespace MarsRover
{
    public class Point
    {
        private const int PlanBorder = 5;
        public readonly int x;
        public readonly int y;

        public Point(int x, int y)
        {
            this.x = x;
            this.y = y;
        }

        public override bool Equals(object obj)
        {
            return obj is Point point &&
                   x == point.x &&
                   y == point.y;
        }

        internal Point GenerateNextPosition(DirectionEnum direction)
        {
            return direction switch
            {
                //TODO: refector this
                DirectionEnum.E => new Point((x + 1) % PlanBorder, y),
                DirectionEnum.W => new Point((x - 1 + PlanBorder) % PlanBorder, y),
                DirectionEnum.N => new Point(x, (y + 1) % PlanBorder),
                DirectionEnum.S => new Point(x, (y - 1 + PlanBorder) % PlanBorder),
                _ => new Point(x, y),
            };
        }
    }
}
