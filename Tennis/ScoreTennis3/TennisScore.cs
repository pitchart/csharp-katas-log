using System.Collections.Generic;

namespace Tennis.ScoreTennis3
{

    public static class TennisScore
    {
        private static readonly Dictionary<int, string> Scores = new()
        {
            { 0, "Love" },
            { 1, "Fifteen" },
            { 2, "Thirty" },
            { 3, "Forty" },
        };

        public static string Get(int playerPoint)
        {
            return Scores[playerPoint];
        }
    }

}
