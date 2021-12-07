namespace Tennis.Tennis3
{
    public class EqualityScore : IScore
    {
        private readonly IScore _nextCaseScore;

        public EqualityScore(IScore nextCaseScore)
        {
            _nextCaseScore = nextCaseScore;
        }

        public string GetScore(int playerOneScore, int playerTwoScore, string playerName)
        {
            if (playerOneScore == playerTwoScore)
            {
                if (playerOneScore + playerTwoScore < 6)
                    return Scores.GetScore(playerOneScore) + "-All";
                return "Deuce";
            }

            return _nextCaseScore.GetScore(playerOneScore, playerTwoScore, playerName);
        }
    }
}

