using Tennis.Tennis3;

namespace Tennis
{
    public class WinScore : IScore
    {
        public string GetScore(int playerOneScore, int playerTwoScore, string playerName)
        {
            return "Win for " + playerName;
        }
    }
}

