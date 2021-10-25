namespace Tennis.Points
{

    public class Deuce: IPoint
    {
        public string GetScore(string _ = "")
        {
            return "Deuce";
        }

        public IPoint ScoreP1()
        {
            return new Advantage(Player.Pé1);
        }

        public IPoint ScoreP2()
        {
            return new Advantage(Player.Pé2);
        }
    }

}
