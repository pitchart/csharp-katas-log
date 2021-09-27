using Tennis.Points;

namespace Tennis
{

    public class TennisGame2 : ITennisGame
    {
        private int _p1Point;
        private int _p2Point;
        private string _player1Name;
        private string _player2Name;

        private readonly LoveAll _loveAll = new LoveAll();

        private readonly Advantage _advantage = new Advantage();

        private readonly Deuce _deuce = new Deuce();

        private readonly ThirtyAll _thirtyAll = new ThirtyAll();

        private readonly FifteenAll _fifteenAll = new FifteenAll();

        private readonly Win _win = new Win();

        private readonly FifteenLove _fifteenLove = new FifteenLove();

        private readonly ThirtyLove _thirtyLove = new ThirtyLove();

        private readonly FortyLove _fortyLove = new FortyLove();

        private readonly LoveFifteen _loveFifteen = new LoveFifteen();

        private readonly LoveForty _loveForty = new LoveForty();

        private readonly LoveThirty _loveThirty = new LoveThirty();

        public TennisGame2(string player1Name, string player2Name)
        {
            this._player1Name = player1Name;
            this._player2Name = player2Name;
        }

        public string GetScore()
        {
            IPoint currentScore = null;

            if (_p1Point == _p2Point && _p1Point < 3)
            {
                if (_p1Point == 0)
                    currentScore = _loveAll;
                if (_p1Point == 1)
                    currentScore = _fifteenAll;
                if (_p1Point == 2)
                    currentScore = _thirtyAll;
            }

            if (_p1Point > 0 && _p2Point == 0)
            {
                if (_p1Point == 1) currentScore = _fifteenLove;
                if (_p1Point == 2) currentScore = _thirtyLove;
                if (_p1Point == 3) currentScore = _fortyLove;
            }

            if (_p2Point > 0 && _p1Point == 0)
            {
                if (_p2Point == 1) currentScore = _loveFifteen;
                if (_p2Point == 2) currentScore = _loveThirty;
                if (_p2Point == 3) currentScore = _loveForty;
            }

            if (_p1Point == _p2Point && _p1Point > 2)
                currentScore = _deuce;

            if (_p1Point > _p2Point && _p2Point >= 3)
            {
                currentScore = _advantage;
            }

            if (_p2Point > _p1Point && _p1Point >= 3)
            {
                currentScore = _advantage;
            }

            if (_p1Point >= 4 && _p2Point >= 0 && (_p1Point - _p2Point) >= 2)
            {
                currentScore = _win;
            }
            if (_p2Point >= 4 && _p1Point >= 0 && (_p2Point - _p1Point) >= 2)
            {
                currentScore = _win;
            }

            if (currentScore != null) return currentScore.GetScore(WhoLeads());

            //Good
            //-----------------------------
            //Bad 

            string p1res = "";
            string p2res = "";
            var score = "";



            if (_p1Point > _p2Point && _p1Point < 4)
            {
                if (_p1Point == 2)
                    p1res = "Thirty";
                if (_p1Point == 3)
                    p1res = "Forty";
                if (_p2Point == 1)
                    p2res = "Fifteen";
                if (_p2Point == 2)
                    p2res = "Thirty";
                score = p1res + "-" + p2res;
            }
            if (_p2Point > _p1Point && _p2Point < 4)
            {
                if (_p2Point == 2)
                    p2res = "Thirty";
                if (_p2Point == 3)
                    p2res = "Forty";
                if (_p1Point == 1)
                    p1res = "Fifteen";
                if (_p1Point == 2)
                    p1res = "Thirty";
                score = p1res + "-" + p2res;
            }

            return score;
        }

        private string WhoLeads()
        {
            if (_p1Point > _p2Point)
            {
                return _player1Name;
            }
            if (_p1Point < _p2Point)
            {
                return _player2Name;
            }
            return "";
        }

        public void SetP1Score(int number)
        {
            for (int i = 0; i < number; i++)
            {
                P1Score();
            }
        }

        public void SetP2Score(int number)
        {
            for (var i = 0; i < number; i++)
            {
                P2Score();
            }
        }

        private void P1Score()
        {
            _p1Point++;
        }

        private void P2Score()
        {
            _p2Point++;
        }

        public void WonPoint(string player)
        {
            if (player == _player1Name)
                P1Score();
            else if (player == _player2Name)
                P2Score();
        }

    }

}

