using Tennis.ScoresHandler;

namespace Tennis.ScoresHandler
{
    internal class OnlyPlayerTwoScore : IScore
    {
        public string Handle(int playerOnePoint, int playerTwoPoint)
        {
            string score;
            string playerTwoScore = string.Empty;
            if (playerTwoPoint == 1)
                playerTwoScore = "Fifteen";
            if (playerTwoPoint == 2)
                playerTwoScore = "Thirty";
            if (playerTwoPoint == 3)
                playerTwoScore = "Forty";
            string playerOneScore = "Love";
            score = playerOneScore + "-" + playerTwoScore;
            return score;
        }

        public bool Support(int playerOnePoint, int playerTwoPoint)
        {
            return playerTwoPoint > 0 && playerTwoPoint < 4 && playerOnePoint == 0;
        }
    }
}

