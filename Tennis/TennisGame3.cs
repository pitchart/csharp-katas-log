using System;

namespace Tennis
{
    public class TennisGame3 : ITennisGame
    {
        private int _playerTwoScore;
        private int _playerOneScore;
        private string _playerOneName;
        private string _playerTwoName;
        private string[] _p = { "Love", "Fifteen", "Thirty", "Forty" };

        public TennisGame3(string player1Name, string player2Name)
        {
            if (player1Name == player2Name)
            {
                throw new ArgumentException("Players cannot have the same name !");
            }
            _playerOneName = player1Name;
            _playerTwoName = player2Name;
        }

        public string GetScore()
        {
            if ((_playerOneScore < 4 && _playerTwoScore < 4) && (_playerOneScore != _playerTwoScore))
            {
                return NonEqualityScore();
            }

            if (_playerOneScore == _playerTwoScore)
            {
                return EqualityScore();
            }

            if ((_playerOneScore - _playerTwoScore) * (_playerOneScore - _playerTwoScore) == 1)
            {
                return AvantageScore();
            }
            return WinScore();
        }

        private string WinScore()
        {
            return "Win for " + GetLeadingPlayer();
        }

        private string AvantageScore()
        {
            return "Advantage " + GetLeadingPlayer();
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
            if (playerName == _playerOneName)
                _playerOneScore += 1;
            else if (playerName == _playerTwoName)
                _playerTwoScore += 1;
        }

        private string NonEqualityScore()
        {
            return _p[_playerOneScore] + "-" + _p[_playerTwoScore];
        }

        private string EqualityScore()
        {
            if (_playerOneScore + _playerTwoScore < 6)
                return _p[_playerOneScore] + "-All";
            return "Deuce";
        }
    }
}

