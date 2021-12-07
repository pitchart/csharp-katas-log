using System.Collections.Generic;

namespace Tennis.Tennis3
{
    public static class Scores
    {
        private static Dictionary<int, string> _scores = new Dictionary<int, string> { { 0, "Love" }, { 1, "Fifteen" }, { 2, "Thirty" }, { 3, "Forty" } };

        public static string GetScore(int playerScore)
        {
            return _scores[playerScore];
        }
    }
}
