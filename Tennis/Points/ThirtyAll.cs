namespace Tennis.Points
{

    public class ThirtyAll : IPoint
    {
        public string GetScore(string _ = "")
        {
            return "Thirty-All";
        }

        public IPoint ScoreP1()
        {
            return new FortyThirty();
        }

        public IPoint ScoreP2()
        {
            return new ThirtyForty();
        }
    }

}
