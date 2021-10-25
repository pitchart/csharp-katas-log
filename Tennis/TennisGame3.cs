using Tennis.ScoreTennis3;

namespace Tennis
{
    public class TennisGame3 : ITennisGame
    {
        private int _player2Point;
        private int _player1Point;
        private readonly string _player1Name;
        private readonly string _player2Name;

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
                if (_player1Point == _player2Point)
                    return player1Score + "-All";
                
                return player1Score + "-" + _tennisScore[_player2Point];
            }

            if (_player1Point == _player2Point)
                return "Deuce";

            string advantagePlayerName;
            if (_player1Point > _player2Point)
                advantagePlayerName = _player1Name;
            else
                advantagePlayerName = _player2Name;

            return new Advantage(new Win()).GetScore(_player1Point, _player2Point, advantagePlayerName);
        }

        public void WonPoint(string playerName)
        {
            if (playerName == _player1Name)
                this._player1Point += 1;
            else if(playerName == _player2Name)
                this._player2Point += 1;
        }

    }

    public interface IScore
    {
        string GetScore(int playerOnePoint, int playerTwoPoint, string playerName);
    }

}

