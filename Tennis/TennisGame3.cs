using System;
using Tennis.Tennis3;

namespace Tennis
{
    public class TennisGame3 : ITennisGame
    {
        private int _playerTwoScore;
        private int _playerOneScore;
        private string _playerOneName;
        private string _playerTwoName;

        private NonEqualityScore _nonEqualityScore;

        public TennisGame3(string player1Name, string player2Name)
        {
            if (player1Name == player2Name)
            {
                throw new ArgumentException("Players cannot have the same name !");
            }
            _playerOneName = player1Name;
            _playerTwoName = player2Name;

            _nonEqualityScore = new NonEqualityScore(new EqualityScore(new AvantageScore(new WinScore())));
        }

        public string GetScore()
        {
            return _nonEqualityScore.GetScore(_playerOneScore, _playerTwoScore, GetLeadingPlayer());
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
    }
}

