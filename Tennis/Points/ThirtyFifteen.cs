namespace Tennis.Points
{

    public class ThirtyFifteen : IPoint
    {
        public string GetScore(string _ = "")
        {
            return "Thirty-Fifteen";
        }

        public IPoint ScoreP1()
        {
            return new FortyFifteen();
        }

        public IPoint ScoreP2()
        {
            return new ThirtyAll();
        }
    }
}
