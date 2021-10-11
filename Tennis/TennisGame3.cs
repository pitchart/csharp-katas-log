using System;

namespace Tennis
{
    public class TennisGame3 : ITennisGame
    {
        private int _player2Point;
        private int _player1Point;
        private string _player1Name;
        private string _player2Name;

        private readonly string[] _tennisScore = { "Love", "Fifteen", "Thirty", "Forty" };

        public TennisGame3(string player1Name, string player2Name)
        {
            this._player1Name = player1Name;
            this._player2Name = player2Name;
        }

        public string GetScore()
        {
            if (_player1Point < 4 && _player2Point < 4 && _player1Point + _player2Point < 6)
            {
                var player1Score = _tennisScore[_player1Point];
                return _player1Point == _player2Point ? 
                    player1Score + "-All" : 
                    player1Score + "-" + _tennisScore[_player2Point];
            }

            if (_player1Point == _player2Point)
                return "Deuce";

            var advantagePlayerName = _player1Point > _player2Point ? _player1Name : _player2Name;

            return Math.Abs(_player1Point - _player2Point) == 1 ? 
                "Advantage " + advantagePlayerName : 
                "Win for " + advantagePlayerName;
        }

        public void WonPoint(string playerName)
        {
            if (playerName == _player1Name)
                this._player1Point += 1;
            else if(playerName == _player2Name)
                this._player2Point += 1;
        }

    }
}

