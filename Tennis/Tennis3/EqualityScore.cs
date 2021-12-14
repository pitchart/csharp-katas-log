namespace Tennis.Tennis3
{
    public class EqualityScore : ScoreHandler
    {
        public override string GetScore(int playerOneScore, int playerTwoScore, string playerName)
        {
            if (playerOneScore == playerTwoScore)
            {
                if (playerOneScore + playerTwoScore < 6)
                    return Scores.GetScore(playerOneScore) + "-All";
                return "Deuce";
            }

            return base.GetScore(playerOneScore, playerTwoScore, playerName);
        }
    }
}

