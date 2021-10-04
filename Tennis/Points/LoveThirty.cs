namespace Tennis.Points
{
    internal class LoveThirty : IPoint
    {
        public string GetScore(string _ = "")
        {
            return "Love-Thirty";
        }

        public IPoint ScoreP1()
        {
            return new FifteenThirty();
        }

        public IPoint ScoreP2()
        {
            return new LoveForty();
        }
    }
}
