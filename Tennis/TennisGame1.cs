using System;

namespace Tennis
{
    class TennisGame1 : ITennisGame
    {
        private int _player1Score = 0;
        private int _player2Score = 0;
        private readonly string _player1Name;
        private readonly string _player2Name;

        public TennisGame1(string player1Name, string player2Name)
        {
            this._player1Name = player1Name;
            this._player2Name = player2Name;
        }

        public void WonPoint(string playerName)
        {
            if (playerName == _player1Name)
                _player1Score += 1;
            else if(playerName == _player2Name)
                _player2Score += 1;
        }

        public string GetScore()
        {
            if (_player1Score == _player2Score) //Equality score
            {
                return GetScoreForEquality();
            }

            if (_player1Score >= 4 || _player2Score >= 4) //Advantage or Win
            {
                return GetScoreForAdvantageOrWin();
            }

            return GetOtherScore();
        }

        private string GetOtherScore()
        {
            return $"{GetPlayerScore(_player1Score)}-{GetPlayerScore(_player2Score)}";
        }

        private static string GetPlayerScore(int playerScore)
        {
            return playerScore switch
            {
                0 => "Love",
                1 => "Fifteen",
                2 => "Thirty",
                3 => "Forty",
                _ => throw new ArgumentOutOfRangeException(nameof(playerScore), playerScore, null)
            };
        }

        private string GetScoreForAdvantageOrWin()
        {
            return (_player1Score - _player2Score) switch
            {
                1 => $"Advantage {_player1Name}",
                -1 => $"Advantage {_player2Name}",
                >= 2 => $"Win for {_player1Name}",
                _ => $"Win for {_player2Name}"
            };
        }

        private string GetScoreForEquality()
        {
            return _player1Score switch
            {
                0 => "Love-All",
                1 => "Fifteen-All",
                2 => "Thirty-All",
                _ => "Deuce"
            };
        }
    }
}

