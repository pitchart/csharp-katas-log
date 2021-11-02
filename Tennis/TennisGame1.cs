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
                    return Scores.Love;
                case 1:
                    return Scores.Fifteen;
                case 2:
                    return Scores.Thirty;
                case 3:
                    return Scores.Forty;
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
            var minusResult = _mScore1 - _mScore2;

            var leadingPlayer = GetLeadingPlayer();

            return Math.Abs(minusResult) == 1 ? $"Advantage {leadingPlayer}" : $"Win for {leadingPlayer}";
        }

        private string GetLeadingPlayer()
        {
            var minusResult = _mScore1 - _mScore2;
            if (minusResult > 0)
            {
                return _player1Name;
            }

            if (minusResult < 0)
            {
                return _player2Name;
            }

            throw new InvalidOperationException("Nobody is leading");
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
                    score = string.Concat(Scores.Love, '-', Scores.All);
                    break;
                case 1:
                    score = string.Concat(Scores.Fifteen, '-', Scores.All);
                    break;
                case 2:
                    score = string.Concat(Scores.Thirty, '-', Scores.All);
                    break;
                default:
                    score = Scores.Deuce;
                    break;
            }

            return score;
        }
    }
}

