using Tennis.ScoresHandler;

namespace Tennis.ScoresHandler
{
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

