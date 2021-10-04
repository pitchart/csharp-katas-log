namespace Tennis.Points
{

    public class WinP1 : IPoint
    {
        public string GetScore(string name)
        {
            return $"Win for {name}";
        }

        public IPoint ScoreP1()
        {
            return this;
        }

        public IPoint ScoreP2()
        {
            return this;
        }
    }

}
