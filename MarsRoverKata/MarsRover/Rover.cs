using System;

namespace MarsRover
{

    public class Rover
    {
        internal Point Position { get; private set; }

        private DirectionEnum _direction;

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
                if (move.Equals('R'))
                {
                    if (_direction == DirectionEnum.E)
                    {
                        _direction = _direction + 1;
                    }
                    else
                    {
                        _direction = _direction + 1;
                    }
                }
                else
                {
                    MoveForward();
                }
            }
            return $"{Position.x}:{Position.y}:{_direction}";
        }

        private void MoveForward()
        {
            this.Position = this.Position.GenerateNextPosition(_direction);
        }
    }
}
