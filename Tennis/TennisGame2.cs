using Tennis.Points;

namespace Tennis
{

    public class TennisGame2 : ITennisGame
    {
        private Player _player1;
        private Player _player2;

        private IPoint _currentScore;

        public TennisGame2(string player1Name, string player2Name)
        {
            _player1 = new Player(player1Name);
            _player2 = new Player(player2Name);
            _currentScore = new LoveAll();
        }

        public string GetScore()
        {
            return _currentScore?.GetScore(WhoLeads()) ?? string.Empty;
        }

        private string WhoLeads()
        {
            if (_player1.GetPoints() > _player2.GetPoints())
            {
                return _player1.Name;
            }
            if (_player1.GetPoints() < _player2.GetPoints())
            {
                return _player2.Name;
            }
            return "";
        }

        private void P1Score()
        {
            _currentScore = _currentScore.ScoreP1();
            _player1.Score();
        }

        private void P2Score()
        {
            _currentScore = _currentScore.ScoreP2();
            _player2.Score();
        }

        public void WonPoint(string player)
        {
            if (player == _player1.Name)
                P1Score();
            else if (player == _player2.Name)
                P2Score();
        }
    }

}

