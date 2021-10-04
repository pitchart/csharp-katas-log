namespace Tennis.Points
{

    public class FifteenThirty : IPoint
    {
        public string GetScore(string _ = "")
        {
            return "Fifteen-Thirty";
        }

        public IPoint ScoreP1()
        {
            return new ThirtyAll();
        }

        public IPoint ScoreP2()
        {
            return new FifteenForty();
        }
    }

}
