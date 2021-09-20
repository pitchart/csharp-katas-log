namespace Tennis.Points
{

    public class Advantage:IPoint
    {
        public string GetScore(string name)
        {
            return $"Advantage {name}";
        }
    }

}
