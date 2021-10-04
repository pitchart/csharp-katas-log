namespace Tennis.Points
{

    public class FifteenLove : IPoint
    {
        public string GetScore(string _ = "")
        {
            return "Fifteen-Love";
        }

        public IPoint ScoreP1()
        {
            return new ThirtyLove();
        }

        public IPoint ScoreP2()
        {
            return new FifteenAll();
        }
    }

}
