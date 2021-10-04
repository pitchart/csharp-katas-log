using Tennis.Points;

namespace Tennis
{

    public class TennisGame2 : ITennisGame
    {
        private int _p1Point;
        private int _p2Point;
        private string _player1Name;
        private string _player2Name;

        private IPoint _currentScore;

        public TennisGame2(string player1Name, string player2Name)
        {
            this._player1Name = player1Name;
            this._player2Name = player2Name;

            _currentScore = new LoveAll();
        }

        public string GetScore()
        {
            return _currentScore?.GetScore(WhoLeads()) ?? string.Empty;
        }

        private string WhoLeads()
        {
            if (_p1Point > _p2Point)
            {
                return _player1Name;
            }
            if (_p1Point < _p2Point)
            {
                return _player2Name;
            }
            return "";
        }

        private void P1Score()
        {
            _currentScore = _currentScore.ScoreP1();
            _p1Point++;
        }

        private void P2Score()
        {
            _currentScore = _currentScore.ScoreP2();
            _p2Point++;
        }

        public void WonPoint(string player)
        {
            if (player == _player1Name)
                P1Score();
            else if (player == _player2Name)
                P2Score();
        }
    }

}

