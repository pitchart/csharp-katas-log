using Tennis.Tennis3;

namespace Tennis
{
    public class WinScore : ScoreHandler
    {
        public override string GetScore(int playerOneScore, int playerTwoScore, string playerName)
        {
            return "Win for " + playerName;
        }
    }
}

