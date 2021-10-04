namespace Tennis.Points
{

    public class AdvantageP1:IPoint
    {
        public string GetScore(string name)
        {
            return $"AdvantageP1 {name}";
        }

        public IPoint ScoreP1()
        {
            return new Win();
        }

        public IPoint ScoreP2()
        {
            return new Deuce();
        }
    }

}
