namespace Tennis.Tennis3
{
    public class AvantageScore : ScoreHandler
    {
        public override string GetScore(int playerOneScore, int playerTwoScore, string playerName)
        {
            if ((playerOneScore - playerTwoScore) * (playerOneScore - playerTwoScore) == 1)
            {
                return "Advantage " + playerName;
            }

            return base.GetScore(playerOneScore, playerTwoScore, playerName);
        }
    }
}

