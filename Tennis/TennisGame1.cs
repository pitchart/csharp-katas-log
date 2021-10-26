using System;

namespace Tennis
{
    class TennisGame1 : ITennisGame
    {
        private int _mScore1;
        private int _mScore2;
        private readonly string _player1Name;
        private readonly string _player2Name;

        public TennisGame1(string player1Name, string player2Name)
        {
            if (player1Name == player2Name)
            {
                throw new ArgumentException("Players cannot have the same name !");
            }

            _player1Name = player1Name;
            _player2Name = player2Name;
        }

        public void WonPoint(string playerName)
        {
            if (playerName == _player1Name)
                _mScore1 += 1;
            else if (playerName == _player2Name) _mScore2 += 1;
        }

        public string GetScore()
        {
            if (ThereIsEquality())
            {
                return EqualityScore();
            }
            if (ThereIsAdvantageOrVictory())
            {
                return AdvantageOrVictory();
            }
            
            return OthersScore();
        }

        private string OthersScore()
        {
            return ScoreToString(_mScore1) + "-" + ScoreToString(_mScore2);
        }

        private static string ScoreToString(int tempScore)
        {
            switch (tempScore)
            {
                case 0:
                    return "Love";
                case 1:
                    return "Fifteen";
                case 2:
                    return "Thirty";
                case 3:
                    return "Forty";
                default:
                    throw new ArgumentException("Score should not be more than 3");
            }
        }

        private bool ThereIsAdvantageOrVictory()
        {
            return _mScore1 >= 4 || _mScore2 >= 4;
        }

        private string AdvantageOrVictory()
        {
            string score;
            var minusResult = _mScore1 - _mScore2;
            if (minusResult == 1) score = "Advantage player1";
            else if (minusResult == -1) score = "Advantage player2";
            else if (minusResult >= 2) score = "Win for player1";
            else score = "Win for player2";
            return score;
        }

        private bool ThereIsEquality()
        {
            return _mScore1 == _mScore2;
        }

        private string EqualityScore()
        {
            string score;
            switch (_mScore1)
            {
                case 0:
                    score = "Love-All";
                    break;
                case 1:
                    score = "Fifteen-All";
                    break;
                case 2:
                    score = "Thirty-All";
                    break;
                default:
                    score = "Deuce";
                    break;
            }

            return score;
        }
    }
}

