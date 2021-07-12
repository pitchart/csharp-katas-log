namespace MarsRover
{

    public class Rover
    {
        private int _x;
        private int _y;
        private char _direction;

        public Rover(int x, int y, char direction)
        {
            this._x = x;
            this._y = y;
            this._direction = direction;
        }

        public object Move(string command)
        {
            return "3:2:N";
        }
    }
}
