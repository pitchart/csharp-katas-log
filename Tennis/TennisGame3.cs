namespace Tennis
{
    public class TennisGame3 : ITennisGame
    {
        private int _playerTwoScore;
        private int _playerOneScore;
        private string _playerOneName;
        private string _playerTwoName;

        public TennisGame3(string player1Name, string player2Name)
        {
            _playerOneName = player1Name;
            _playerTwoName = player2Name;
        }

        public string GetScore()
        {
            if ((_playerOneScore < 4 && _playerTwoScore < 4) && (_playerOneScore + _playerTwoScore < 6))
            {
                string[] p = { "Love", "Fifteen", "Thirty", "Forty" };
                if ((_playerOneScore == _playerTwoScore))
                {
                    return p[_playerOneScore] + "-All";
                }

                return p[_playerOneScore] + "-" + p[_playerTwoScore];
            }

            if (_playerOneScore == _playerTwoScore)
                return "Deuce";
            
            if ((_playerOneScore - _playerTwoScore) * (_playerOneScore - _playerTwoScore) == 1)
            {
                return "Advantage " + GetLeadingPlayer();
            }
            return "Win for " + GetLeadingPlayer();
        }

        private string GetLeadingPlayer()
        {
            string s;
            if (_playerOneScore > _playerTwoScore)
            {
                s = _playerOneName;
            }
            else
            {
                s = _playerTwoName;
            }

            return s;
        }

        public void WonPoint(string playerName)
        {
            if (playerName == "player1")
                _playerOneScore += 1;
            else
                _playerTwoScore += 1;
        }

    }
}

