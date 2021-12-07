namespace Tennis.Tennis3
{
    public class AvantageScore : IScore
    {
        private readonly IScore _nextCaseScore;

        public AvantageScore(IScore nextCaseScore)
        {
            _nextCaseScore = nextCaseScore;
        }

        public string GetScore(int playerOneScore, int playerTwoScore, string playerName)
        {
            if ((playerOneScore - playerTwoScore) * (playerOneScore - playerTwoScore) == 1)
            {
                return "Advantage " + playerName;
            }

            return _nextCaseScore.GetScore(playerOneScore, playerTwoScore, playerName);
        }
    }
}

