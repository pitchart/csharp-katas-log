namespace Tennis.ScoreTennis3
{
    public class NonEqualityScore : IScore
    {
        private readonly IScore _next;

        public NonEqualityScore(IScore next)
        {
            _next = next;
        }

        public string GetScore(int playerOnePoint, int playerTwoPoint, string playerName)
        {
            if (playerOnePoint < 4 && playerTwoPoint < 4 && playerOnePoint != playerTwoPoint)
            {
                return TennisScore.Get(playerOnePoint) + "-" + TennisScore.Get(playerTwoPoint);
            }

            return _next.GetScore(playerOnePoint, playerTwoPoint, playerName);
        }
    }
}
