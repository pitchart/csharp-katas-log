using System;

namespace Tennis
{
    class TennisGame1 : ITennisGame
    {
        private const string Love = "Love";

        private const string Fifteen = "Fifteen";

        private const string Thirty = "Thirty";

        private const string Forty = "Forty";

        private const string Deuce = "Deuce";

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
                0 => Love,
                1 => Fifteen,
                2 => Thirty,
                3 => Forty,
                _ => throw new ArgumentOutOfRangeException(nameof(playerScore), playerScore, null)
            };
        }

        private string GetScoreForAdvantageOrWin()
        {
            return GetGap() switch
            {
                1 => $"Advantage {GetLeadingPlayerName()}",
                _ => $"Win for {GetLeadingPlayerName()}"
            };
        }

        private int GetGap()
        {
            return Math.Abs(_player1Score - _player2Score);
        }

        private string GetLeadingPlayerName()
        {
            if (_player1Score == _player2Score) throw new Exception();
            return _player1Score - _player2Score < 0 ? _player2Name : _player1Name;
        }

        private string GetScoreForEquality()
        {
            return _player1Score switch
            {
                0 or 1 or 2 => GetPlayerScore(_player1Score) + "-All",
                _ => Deuce
            };
        }
    }
}

