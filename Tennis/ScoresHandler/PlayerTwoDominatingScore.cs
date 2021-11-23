using Tennis.ScoresHandler;

namespace Tennis.ScoresHandler
{
    internal class PlayerTwoDominatingScore : IScore
    {
        public string Handle(int playerOnePoint, int playerTwoPoint)
        {
            string score;
            string playerTwoScore = string.Empty;
            string playerOneScore = string.Empty;
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

        public bool Support(int playerOnePoint, int playerTwoPoint)
        {
            return playerTwoPoint > playerOnePoint && playerTwoPoint < 4;
        }
    }

}

