namespace Tennis.Points
{

    public class FortyThirty : IPoint
    {
        public string GetScore(string _ = "")
        {
            return "Forty-Thirty";
        }

        public IPoint ScoreP1()
        {
            return new WinP1();
        }

        public IPoint ScoreP2()
        {
            return new Deuce();
        }
    }
}
