namespace Tennis
{
    public class TennisGame2 : ITennisGame
    {
        private int _p1Point;
        private int _p2Point;
        private string _player1Name;
        private string _player2Name;

        public TennisGame2(string player1Name, string player2Name)
        {
            this._player1Name = player1Name;
            _p1Point = 0;
            this._player2Name = player2Name;
        }

        public string GetScore()
        {
            string p1res = "";
            string p2res = "";
            var score = "";

            if (_p1Point == _p2Point && _p1Point < 3)
            {
                if (_p1Point == 0)
                    score = "Love";
                if (_p1Point == 1)
                    score = "Fifteen";
                if (_p1Point == 2)
                    score = "Thirty";
                score += "-All";
            }
            if (_p1Point == _p2Point && _p1Point > 2)
                score = "Deuce";

            if (_p1Point > 0 && _p2Point == 0)
            {
                if (_p1Point == 1)
                    p1res = "Fifteen";
                if (_p1Point == 2)
                    p1res = "Thirty";
                if (_p1Point == 3)
                    p1res = "Forty";

                p2res = "Love";
                score = p1res + "-" + p2res;
            }
            if (_p2Point > 0 && _p1Point == 0)
            {
                if (_p2Point == 1)
                    p2res = "Fifteen";
                if (_p2Point == 2)
                    p2res = "Thirty";
                if (_p2Point == 3)
                    p2res = "Forty";

                p1res = "Love";
                score = p1res + "-" + p2res;
            }

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

            if (_p1Point > _p2Point && _p2Point >= 3)
            {
                score = $"Advantage {_player1Name}";
            }

            if (_p2Point > _p1Point && _p1Point >= 3)
            {
                score = $"Advantage {_player2Name}";
            }

            if (_p1Point >= 4 && _p2Point >= 0 && (_p1Point - _p2Point) >= 2)
            {
                score = $"Win for {_player1Name}";
            }
            if (_p2Point >= 4 && _p1Point >= 0 && (_p2Point - _p1Point) >= 2)
            {
                score = $"Win for {_player2Name}";
            }
            return score;
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

