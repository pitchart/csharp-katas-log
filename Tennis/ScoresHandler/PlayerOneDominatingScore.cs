using Tennis.ScoresHandler;

namespace Tennis.ScoresHandler
{
    internal class PlayerOneDominatingScore : IScore
    {
        public string Handle(int playerOnePoint, int playerTwoPoint)
        {
            string score;
            string playerOneScore = string.Empty;
            string playerTwoScore = string.Empty;
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

        public bool Support(int playerOnePoint, int playerTwoPoint)
        {
            return playerOnePoint > playerTwoPoint && playerOnePoint < 4;
        }
    }
}

