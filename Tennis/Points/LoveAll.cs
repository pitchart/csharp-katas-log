namespace Tennis.Points
{

    public class LoveAll: IPoint
    {
        
        public string GetScore(string _ = "")
        {
            return "Love-All";
        }

        public IPoint ScoreP1()
        {
            return new FifteenLove();
        }

        public IPoint ScoreP2()
        {
            return new LoveFifteen();
        }
    }

}
