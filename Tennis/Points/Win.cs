namespace Tennis.Points
{

    public class Win : IPoint
    {
        public string GetScore(string name)
        {
            return $"Win for {name}";
        }
    }

}
