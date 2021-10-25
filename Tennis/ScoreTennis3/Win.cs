namespace Tennis.ScoreTennis3
{

    public class Win: IScore
    {
        public string GetScore(int _, int __, string playerName)
        {
            return $"Win for {playerName}"; 
        }
    }

}
