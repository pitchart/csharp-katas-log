using System.Collections.Generic;
using Tennis.ScoresHandler;

namespace Tennis
{
    public class TennisGame2 : ITennisGame
    {
        private int playerOnePoint;
        private int playerTwoPoint;

        private string playerOneScore = "";
        private string playerTwoScore = "";
        private string firstPlayerName;
        private string secondPlayerName;
        private List<IScore> _scores = new List<IScore>() { new EqualityScore(), new Deuce(), new OnlyPlayerOneScore() };

        public TennisGame2(string player1Name, string player2Name)
        {
            firstPlayerName = player1Name;
            playerOnePoint = 0;
            secondPlayerName = player2Name;
        }

        public string GetScore()
        {
            foreach (var score in _scores)
            {
                if (score.Support(playerOnePoint, playerTwoPoint))
                {
                    return score.Handle(playerOnePoint, playerTwoPoint);
                }
            }
            var scoreFinal = "";

            if (playerTwoPoint > 0 && playerTwoPoint < 4 && playerOnePoint == 0)
            {
                return OnlyPlayerTwoScore();
            }

            if (playerOnePoint > playerTwoPoint && playerOnePoint < 4)
            {
                return PlayerOneDominatingScore();
            }
            if (playerTwoPoint > playerOnePoint && playerTwoPoint < 4)
            {
                return PlayerTwoDominatingScore();
            }

            if ((playerOnePoint - playerTwoPoint) == 1 && playerTwoPoint >= 3)
            {
                return "Advantage player1";
            }

            if ((playerTwoPoint - playerOnePoint) == 1 && playerOnePoint >= 3)
            {
                return "Advantage player2";
            }

            if (playerOnePoint >= 4 && (playerOnePoint - playerTwoPoint) >= 2)
            {
                return "Win for player1";
            }
            if (playerTwoPoint >= 4 && (playerTwoPoint - playerOnePoint) >= 2)
            {
                return "Win for player2";
            }
            return scoreFinal;
        }

        private string PlayerTwoDominatingScore()
        {
            string score;
            if (playerTwoPoint == 2)
                playerTwoScore = "Thirty";
            if (playerTwoPoint == 3)
                playerTwoScore = "Forty";
            if (playerOnePoint == 1)
                playerOneScore = "Fifteen";
            if (playerOnePoint == 2)
                playerOneScore = "Thirty";
            score = playerOneScore + "-" + playerTwoScore;
            return score;
        }

        private string PlayerOneDominatingScore()
        {
            string score;
            if (playerOnePoint == 2)
                playerOneScore = "Thirty";
            if (playerOnePoint == 3)
                playerOneScore = "Forty";
            if (playerTwoPoint == 1)
                playerTwoScore = "Fifteen";
            if (playerTwoPoint == 2)
                playerTwoScore = "Thirty";
            score = playerOneScore + "-" + playerTwoScore;
            return score;
        }

        private string OnlyPlayerTwoScore()
        {
            string score;
            if (playerTwoPoint == 1)
                playerTwoScore = "Fifteen";
            if (playerTwoPoint == 2)
                playerTwoScore = "Thirty";
            if (playerTwoPoint == 3)
                playerTwoScore = "Forty";

            playerOneScore = "Love";
            score = playerOneScore + "-" + playerTwoScore;
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
            playerOnePoint++;
        }

        private void P2Score()
        {
            playerTwoPoint++;
        }

        public void WonPoint(string player)
        {
            if (player == "player1")
                P1Score();
            else
                P2Score();
        }

    }

    internal class OnlyPlayerOneScore : IScore
    {
        public string Handle(int playerOnePoint, int playerTwoPoint)
        {
            string score;
            string playerOneScore = string.Empty;
            string playerTwoScore;
            if (playerOnePoint == 1)
                playerOneScore = "Fifteen";
            if (playerOnePoint == 2)
                playerOneScore = "Thirty";
            if (playerOnePoint == 3)
                playerOneScore = "Forty";

            playerTwoScore = "Love";
            score = playerOneScore + "-" + playerTwoScore;
            return score;
        }

        public bool Support(int playerOnePoint, int playerTwoPoint)
        {
            return playerOnePoint > 0 && playerOnePoint < 4 && playerTwoPoint == 0;
        }
    }

    internal class Deuce : IScore
    {
        public string Handle(int playerOnePoint, int playerTwoPoint)
        {
            return "Deuce";
        }

        public bool Support(int playerOnePoint, int playerTwoPoint)
        {
            return playerOnePoint == playerTwoPoint && playerOnePoint > 2;
        }
    }

    public class EqualityScore : IScore
    {
        public string Handle(int playerOnePoint, int playerTwoPoint)
        {
            string score = string.Empty;
            if (playerOnePoint == 0)
                score = "Love";
            if (playerOnePoint == 1)
                score = "Fifteen";
            if (playerOnePoint == 2)
                score = "Thirty";
            score += "-All";
            return score;
        }

        public bool Support(int playerOnePoint, int playerTwoPoint)
        {
            return playerOnePoint == playerTwoPoint && playerOnePoint < 3;
        }
    }
}

