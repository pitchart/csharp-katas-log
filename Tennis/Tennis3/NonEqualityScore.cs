namespace Tennis.Tennis3
{
    public class NonEqualityScore : IScore
    {
        private readonly IScore _nextCaseScore;

        public NonEqualityScore(IScore nextCaseScore)
        {
            _nextCaseScore = nextCaseScore;
        }

        public string GetScore(int playerOneScore, int playerTwoScore, string playerName)
        {
            if ((playerOneScore < 4 && playerTwoScore < 4) && (playerOneScore != playerTwoScore))
            {
                return Scores.GetScore(playerOneScore) + "-" + Scores.GetScore(playerTwoScore);
            }

            return _nextCaseScore.GetScore(playerOneScore, playerTwoScore, playerName);
        }
    }
}

