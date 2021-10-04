namespace Tennis.Points
{

    public class FifteenAll : IPoint
    {
        public string GetScore(string _ = "")
        {
            return "Fifteen-All";
        }

        public IPoint ScoreP1()
        {
            return new ThirtyFifteen();
        }

        public IPoint ScoreP2()
        {
            return new FifteenThirty();
        }
    }

}
