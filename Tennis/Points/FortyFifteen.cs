namespace Tennis.Points
{

    public class FortyFifteen : IPoint
    {
        public string GetScore(string _ = "")
        {
            return "Forty-Fifteen";
        }

        public IPoint ScoreP1()
        {
            return new Win(Player.Pé1);
        }

        public IPoint ScoreP2()
        {
            return new FortyThirty();
        }
    }

}
