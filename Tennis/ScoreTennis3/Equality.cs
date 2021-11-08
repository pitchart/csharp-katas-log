namespace Tennis.ScoreTennis3
{

    public class Equality : IScore
    {
        private readonly IScore _next;

        public Equality(IScore next)
        {
            _next = next;
        }

        public string GetScore(int playerOnePoint, int playerTwoPoint, string playerName)
        {
            if (playerOnePoint == playerTwoPoint && playerOnePoint + playerTwoPoint < 6)
                return TennisScore.Get(playerOnePoint) + "-All";

            if (playerOnePoint == playerTwoPoint)
                return "Deuce";

            return _next.GetScore(playerOnePoint, playerTwoPoint, playerName);
        }
    }

}
