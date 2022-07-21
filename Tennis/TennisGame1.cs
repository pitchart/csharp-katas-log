using System;

namespace Tennis
{

    // TODO:
    // - Rationnaliser le lien entre le score et le joueur (DataClumps)
    // - Multiple responsabilités de score dans la méthode GetScore qui renvoie et le score actuel et le résultat du jeu
    // - Refactoriser le switch des égalités
    // - Expliciter et faire ressortir des méthodes pour les cas des avantages et du jeu courant
    class TennisGame1 : ITennisGame
    {
        private const int MinScoreToWin = 4;

        private int _playerOneScore;

        private int _playerTwoScore;

        private string _playerOneName;
        private string _playerTwoName;

        public TennisGame1(string player1Name, string player2Name)
        {
            _playerOneName = player1Name;
            _playerTwoName = player2Name;
        }

        public void WonPoint(string playerName)
        {
            if (playerName == _playerOneName)
                _playerOneScore += 1;
            else
                _playerTwoScore += 1;
        }

        public string GetScore()
        {
            string score = "";

            if (AreScoresEquals())
            {
                score = HandleEqualityCase();
            }
            else if (IsWin())
            {
                score = HandleWin();
            }
            else if (IsAdvantage())
            {
                score = HandleAdvantage();
            }
            else
            {
                score = HandleOnGoingScore();
            }

            return score;
        }

        private string HandleOnGoingScore()
        {
            return $"{(ScoreLabel)_playerOneScore}-{(ScoreLabel)_playerTwoScore}";
        }

        private bool AreScoresEquals()
        {
            return _playerOneScore == _playerTwoScore;
        }

        private string HandleWin()
        {
            string score;
            score = GetScoreDifference() switch
            {
                >= 2 => "Win for player1",
                _ => "Win for player2"
            };

            return score;
        }

        private int GetScoreDifference()
        {
            return _playerOneScore - _playerTwoScore;
        }

        private bool IsWin()
        {
            return (PlayerOneHasTheMinimumScoreToWin() || PlayerTwoHasTheMinimumScoreToWin()) &&
                   IsPointDifferenceReached();
        }

        private bool IsPointDifferenceReached()
            => Math.Abs(_playerOneScore - _playerTwoScore) >= 2;

        private bool PlayerTwoHasTheMinimumScoreToWin()
            => _playerTwoScore >= MinScoreToWin;

        private bool PlayerOneHasTheMinimumScoreToWin()
            => _playerOneScore >= MinScoreToWin;

        private string HandleAdvantage()
        {
            string score;
            score = GetScoreDifference() switch
            {
                1 => "Advantage player1",
                _ => "Advantage player2",
            };

            return score;
        }

        private bool IsAdvantage()
        {
            return (_playerOneScore >= MinScoreToWin || _playerTwoScore >= MinScoreToWin) && Math.Abs(GetScoreDifference()) == 1;
        }

        private string HandleEqualityCase()
        {
            return _playerOneScore switch
            {
                0 => "Love-All",
                1 => "Fifteen-All",
                2 => "Thirty-All",
                _ => "Deuce"
            };
        }
    }

}
