using System;

namespace Tennis.ScoreTennis3
{

    public class Advantage : IScore
    {
        private readonly IScore _next;

        public Advantage(IScore next)
        {
            _next = next;
        }

        public string GetScore(int playerOnePoint, int playerTwoPoint, string playerName)
        {
            if (Math.Abs(playerOnePoint - playerTwoPoint) == 1)
                return "Advantage " + playerName;
            
            return _next.GetScore( playerOnePoint, playerTwoPoint, playerName);
        }
    }

}
