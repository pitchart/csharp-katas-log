namespace Tennis.Points
{
    internal class LoveForty : IPoint
    {
        public string GetScore(string name = "")
        {
            return "Love-Forty";
        }

        public IPoint ScoreP1()
        {
            return new FifteenForty();
        }

        public IPoint ScoreP2()
        {
            return new WinP2();
        }
    }
}
