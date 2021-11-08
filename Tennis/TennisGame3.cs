using System.Collections.Generic;
using Tennis.ScoreTennis3;

namespace Tennis
{
    public class TennisGame3 : ITennisGame
    {
        private int _player2Point;
        private int _player1Point;
        private readonly string _player1Name;
        private readonly string _player2Name;

        public TennisGame3(string player1Name, string player2Name)
        {
            this._player1Name = player1Name;
            this._player2Name = player2Name;
        }

        public string GetScore()
        {
            if (_player1Point < 4 && _player2Point < 4 &&  _player1Point != _player2Point)
            {
                return TennisScore.Get(_player1Point) + "-" + TennisScore.Get(_player2Point);
            }

            return new Equality(new Advantage(new Win())).GetScore(_player1Point, _player2Point, GetLeadingPlayer());
        }

        private string GetLeadingPlayer()
        {
            return _player1Point > _player2Point ? _player1Name : _player2Name;
        }

        public void WonPoint(string playerName)
        {
            if (playerName == _player1Name)
                this._player1Point += 1;
            else if(playerName == _player2Name)
                this._player2Point += 1;
        }

    }

    public class Equality : IScore
    {
        private readonly IScore _next;
        
        public Equality(IScore next)
        {
            _next = next;
        }

        public string GetScore(int playerOnePoint, int playerTwoPoint, string playerName)
        {
            if (playerOnePoint == playerTwoPoint && playerOnePoint + playerTwoPoint < 6) 
                return TennisScore.Get(playerOnePoint) + "-All";

            if (playerOnePoint == playerTwoPoint)
                return "Deuce";

            return _next.GetScore(playerOnePoint, playerTwoPoint, playerName);
        }
    }

    public static class TennisScore
    {
        private static readonly Dictionary<int, string> Scores = new()
        {
            {0, "Love"},
            {1, "Fifteen"},
            {2, "Thirty"},
            {3, "Forty"},
        };
        
        public static string Get(int playerPoint)
        {
            return Scores[playerPoint];
        }
    }

    public interface IScore
    {
        string GetScore(int playerOnePoint, int playerTwoPoint, string playerName);
    }

}

