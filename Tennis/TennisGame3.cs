using Tennis.ScoreTennis3;

namespace Tennis
{
    public class TennisGame3 : ITennisGame
    {
        private int _player2Point;
        private int _player1Point;
        private readonly string _player1Name;
        private readonly string _player2Name;

        private NonEqualityScore _nonEqualityScore;

        public TennisGame3(string player1Name, string player2Name)
        {
            this._player1Name = player1Name;
            this._player2Name = player2Name;
            _nonEqualityScore = new NonEqualityScore(new Equality(new Advantage(new Win())));
        }

        public string GetScore()
        {
            return _nonEqualityScore.GetScore(_player1Point, _player2Point, GetLeadingPlayer());
        }

        private string GetLeadingPlayer()
        {
            return _player1Point > _player2Point ? _player1Name : _player2Name;
        }

        public void WonPoint(string playerName)
        {
            if (playerName == _player1Name)
                this._player1Point += 1;
            else if (playerName == _player2Name)
                this._player2Point += 1;
        }
    }
}

