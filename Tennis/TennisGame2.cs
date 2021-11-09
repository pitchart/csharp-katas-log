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

        public TennisGame2(string player1Name, string player2Name)
        {
            firstPlayerName = player1Name;
            playerOnePoint = 0;
            secondPlayerName = player2Name;
        }

        public string GetScore()
        {
            var score = "";
            if (playerOnePoint == playerTwoPoint && playerOnePoint < 3)
            {
                return EqualityScore(score);
            }
            if (playerOnePoint == playerTwoPoint && playerOnePoint > 2)
                return "Deuce";

            if (playerOnePoint > 0 && playerTwoPoint == 0)
            {
                score = OnlyPlayerOneScore();
            }
            if (playerTwoPoint > 0 && playerOnePoint == 0)
            {
                score = OnlyPlayerTwoScore();
            }

            if (playerOnePoint > playerTwoPoint && playerOnePoint < 4)
            {
                score = PlayerOneDominatingScore();
            }
            if (playerTwoPoint > playerOnePoint && playerTwoPoint < 4)
            {
                score = PlayerTwoDominatingScore();
            }

            if (playerOnePoint > playerTwoPoint && playerTwoPoint >= 3)
            {
                score = "Advantage player1";
            }

            if (playerTwoPoint > playerOnePoint && playerOnePoint >= 3)
            {
                score = "Advantage player2";
            }

            if (playerOnePoint >= 4 && playerTwoPoint >= 0 && (playerOnePoint - playerTwoPoint) >= 2)
            {
                score = "Win for player1";
            }
            if (playerTwoPoint >= 4 && playerOnePoint >= 0 && (playerTwoPoint - playerOnePoint) >= 2)
            {
                score = "Win for player2";
            }
            return score;
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

        private string OnlyPlayerOneScore()
        {
            string score;
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

        private string EqualityScore(string score)
        {
            if (playerOnePoint == 0)
                score = "Love";
            if (playerOnePoint == 1)
                score = "Fifteen";
            if (playerOnePoint == 2)
                score = "Thirty";
            score += "-All";
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
}

