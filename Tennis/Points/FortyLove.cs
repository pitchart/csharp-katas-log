namespace Tennis.Points
{

    public class FortyLove : IPoint
    {
        public string GetScore(string _ = "")
        {
            return "Forty-Love";
        }

        public IPoint ScoreP1()
        {
            return new Win(Player.Pé1);
        }

        public IPoint ScoreP2()
        {
            return new FortyFifteen();
        }
    }

}
