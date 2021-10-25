namespace Tennis
{

    public class TennisPlayer
    {
        private readonly string _playerName;

        private int _points;

        public TennisPlayer(string playerName)
        {
            _playerName = playerName;
            _points = 0;
        }

        public string Name => _playerName;

        public int GetPoints()
        {
            return _points;
        }

        public void Score()
        {
            _points++;
        }
    }

}
