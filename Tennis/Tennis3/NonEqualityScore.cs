namespace Tennis.Tennis3
{
    public class NonEqualityScore : ScoreHandler
    {
        public override string GetScore(int playerOneScore, int playerTwoScore, string playerName)
        {
            if ((playerOneScore < 4 && playerTwoScore < 4) && (playerOneScore != playerTwoScore))
            {
                return Scores.GetScore(playerOneScore) + "-" + Scores.GetScore(playerTwoScore);
            }

            return base.GetScore(playerOneScore, playerTwoScore, playerName);
        }
    }
}

