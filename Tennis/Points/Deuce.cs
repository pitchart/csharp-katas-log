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
            return new AdvantageP1();
        }

        public IPoint ScoreP2()
        {
            return new AdvantageP2();
        }
    }

}
