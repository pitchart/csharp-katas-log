using System;
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

        private readonly ThirtyFifteen _thirtyFifteen = new ThirtyFifteen();

        private readonly FortyFifteen _fortyFifteen = new FortyFifteen();

        private readonly FortyThirty _fortyThirty = new FortyThirty();

        private readonly FifteenThirty _fifteenThirty = new FifteenThirty();

        private readonly FifteenForty _fifteenForty = new FifteenForty();

        private readonly ThirtyForty _thirtyForty = new  ThirtyForty();

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

            if (_p1Point == 2 && _p2Point == 1) currentScore = _thirtyFifteen;
            if (_p1Point == 3 && _p2Point == 1) currentScore = _fortyFifteen;
            if (_p1Point == 3 && _p2Point == 2) currentScore = _fortyThirty;
            
            if (_p2Point == 2 && _p1Point == 1) currentScore = _fifteenThirty;
            if (_p2Point == 3 && _p1Point == 1) currentScore = _fifteenForty;
            if (_p2Point == 3 && _p1Point == 2) currentScore = _thirtyForty;

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

            return currentScore?.GetScore(WhoLeads()) ?? string.Empty;
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

