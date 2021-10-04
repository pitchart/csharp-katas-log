namespace Tennis.Points
{

    public class FifteenForty : IPoint
    {
        public string GetScore(string name = "")
        {
            return "Fifteen-Forty";
        }

        public IPoint ScoreP1()
        {
            return new ThirtyForty();
        }

        public IPoint ScoreP2()
        {
            return new WinP2();
        }
    }

}
