namespace Tennis.Points
{

    public class ThirtyForty : IPoint
    {
        public string GetScore(string name = "")
        {
            return "Thirty-Forty";
        }

        public IPoint ScoreP1()
        {
            return new Deuce();
        }

        public IPoint ScoreP2()
        {
            return new Win(Player.Pé2);
        }
    }

}
