using System;

namespace MarsRover
{

    public class Rover
    {
        private int _x;
        private int _y;
        private readonly DirectionEnum _direction;

        public Rover(int x, int y, char direction)
        {
            this._x = x;
            this._y = y;
            Enum.TryParse(direction.ToString(), out _direction);
        }

        public object Move(string command)
        {
            var commands = command.ToCharArray();

            foreach (var move in commands)
            {
                switch (_direction)
                {
                    case DirectionEnum.E:
                        _x++;
                        break;
                    case DirectionEnum.W:
                        _x--;
                        break;
                    case DirectionEnum.N:
                        _y++;
                        break;
                    case DirectionEnum.S:
                        _y--;
                        break;
                }
            }

            return $"{_x}:{_y}:{_direction}";
        }
    }

    public enum DirectionEnum
    {
        N,
        E,
        S,
        W
    }
}
