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

    public class WinScore : IScore
    {
        public string GetScore(int playerOneScore, int playerTwoScore, string playerName)
        {
            return "Win for " + playerName;
        }
    }

    public class AvantageScore : IScore
    {
        private readonly IScore _nextCaseScore;

        public AvantageScore(IScore nextCaseScore)
        {
            _nextCaseScore = nextCaseScore;
        }

        public string GetScore(int playerOneScore, int playerTwoScore, string playerName)
        {
            if ((playerOneScore - playerTwoScore) * (playerOneScore - playerTwoScore) == 1)
            {
                return "Advantage " + playerName;
            }

            return _nextCaseScore.GetScore(playerOneScore, playerTwoScore, playerName);
        }
    }

    public class EqualityScore : IScore
    {
        private string[] _p = { "Love", "Fifteen", "Thirty", "Forty" };

        private readonly IScore _nextCaseScore;

        public EqualityScore(IScore nextCaseScore)
        {
            _nextCaseScore = nextCaseScore;
        }

        public string GetScore(int playerOneScore, int playerTwoScore, string playerName)
        {
            if (playerOneScore == playerTwoScore)
            {
                if (playerOneScore + playerTwoScore < 6)
                    return _p[playerOneScore] + "-All";
                return "Deuce";
            }

            return _nextCaseScore.GetScore(playerOneScore, playerTwoScore, playerName);
        }
    }

    public class NonEqualityScore : IScore
    {
        private string[] _p = { "Love", "Fifteen", "Thirty", "Forty" };

        private readonly IScore _nextCaseScore;

        public NonEqualityScore(IScore nextCaseScore)
        {
            _nextCaseScore = nextCaseScore;
        }
        
        public string GetScore(int playerOneScore, int playerTwoScore, string playerName)
        {
            if ((playerOneScore < 4 && playerTwoScore < 4) && (playerOneScore != playerTwoScore))
            {
                return _p[playerOneScore] + "-" + _p[playerTwoScore];
            }

            return _nextCaseScore.GetScore(playerOneScore, playerTwoScore, playerName);
        }
    }
}

