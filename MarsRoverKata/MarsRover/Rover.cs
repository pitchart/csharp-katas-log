using System;
using System.Collections;
using System.Collections.Generic;

namespace MarsRover
{

    public class Rover
    {
        internal Point Position { get; private set; }

        private bool EncounterObstacle { get; set; }

        private DirectionEnum _direction;

        private Map _map;

        private const string NotifyObstaclePrefix = "O:";
        private const string ErrorPrefix = "E:";


        public Rover(int x, int y, char direction, Map map)
        {
            this.Position = new Point(x, y);
            Enum.TryParse(direction.ToString(), out _direction);
            _map = map;
            EncounterObstacle = false;
        }

        public string Move(string command)
        {
            var commands = command.ToCharArray();

            foreach (var move in commands)
            {
                if (move.Equals('R'))
                {
                    MoveRight();
                }
                else if (move.Equals('L'))
                {
                    MoveLeft();
                }
                else if (move.Equals('F'))
                {
                    MoveForward();
                }
                else
                {
                    return CreateOutputMessage(ErrorPrefix);
                }
            }

            return EncounterObstacle ? CreateOutputMessage(NotifyObstaclePrefix): CreateOutputMessage(string.Empty);
        }

        private string CreateOutputMessage(string prefix)
        {
            return string.Concat(prefix, $"{Position.x}:{Position.y}:{_direction}");
        }

        private void MoveLeft()
        {
            if (_direction == DirectionEnum.N)
            {
                _direction = DirectionEnum.W;
            }
            else
            {
                _direction = _direction - 1;
            }
        }

        private void MoveRight()
        {
            if (_direction == DirectionEnum.W)
            {
                _direction = DirectionEnum.N;
            }
            else
            {
                _direction = _direction + 1;
            }
        }

        private void MoveForward()
        {
            var newPosition = this.Position.GenerateNextPosition(_direction);
            if (!_map.HasObstacleAt(newPosition))
                this.Position = newPosition;
            else
                EncounterObstacle = true;
        }
    }
}
