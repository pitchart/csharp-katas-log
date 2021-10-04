namespace Tennis.Points
{
    internal class LoveFifteen : IPoint
    {
        public string GetScore(string _ = "")
        {
            return "Love-Fifteen";
        }

        public IPoint ScoreP1()
        {
            return new FifteenAll();
        }

        public IPoint ScoreP2()
        {
            return new LoveThirty();
        }
    }
}
