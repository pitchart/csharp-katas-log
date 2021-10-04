namespace Tennis.Points
{

    public class AdvantageP2 : IPoint
    {
        public string GetScore(string name)
        {
            return $"Advantage {name}";
        }

        public IPoint ScoreP1()
        {
            return new Deuce();
        }

        public IPoint ScoreP2()
        {
            return new WinP2();
        }
    }

}
