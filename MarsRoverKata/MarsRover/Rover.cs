using System;

namespace MarsRover
{

    public class Rover
    {
        internal Point Position { get; private set; }

        private readonly DirectionEnum _direction;

        public Rover(int x, int y, char direction)
        {
            this.Position = new Point(x, y);
            Enum.TryParse(direction.ToString(), out _direction);
        }

        public string Move(string command)
        {
            var commands = command.ToCharArray();

            foreach (var move in commands)
            {
                MoveForward();
            }

            return $"{Position.x}:{Position.y}:{_direction}";
        }

        private void MoveForward()
        {
            switch (_direction)
            {
                case DirectionEnum.E:
                    this.Position = new Point(this.Position.x+1, this.Position.y);
                    break;
                case DirectionEnum.W:
                    this.Position = new Point(this.Position.x-1, this.Position.y);
                    break;
                case DirectionEnum.N:
                    this.Position = new Point(this.Position.x, this.Position.y+1);
                    break;
                case DirectionEnum.S:
                    this.Position = new Point(this.Position.x, this.Position.y-1);
                    break;
            }
        }
    }
}
