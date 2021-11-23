using Tennis.ScoresHandler;

namespace Tennis.ScoresHandler
{
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
}

