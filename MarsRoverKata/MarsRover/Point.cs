namespace MarsRover
{
    internal class Point
    {
        private const int PlanBorder = 5;
        public readonly int x;
        public readonly int y;

        

        public Point(int x, int y)
        {
            this.x = x;
            this.y = y;
        }

        internal Point GenerateNextPosition(DirectionEnum direction)
        {
            return direction switch
            {
                DirectionEnum.E => new Point(x + 1, y),
                DirectionEnum.W => new Point(x - 1, y),
                DirectionEnum.N => new Point(x, (y + 1) % PlanBorder),
                DirectionEnum.S => new Point(x, y - 1),
                _ => new Point(x, y),
            };
        }
    }
}
