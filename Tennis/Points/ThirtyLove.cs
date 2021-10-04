namespace Tennis.Points
{

    public class ThirtyLove : IPoint
    {
        public string GetScore(string _ = "")
        {
            return "Thirty-Love";
        }

        public IPoint ScoreP1()
        {
            return new FortyLove();
        }

        public IPoint ScoreP2()
        {
            return new ThirtyFifteen();
        }
    }

}
