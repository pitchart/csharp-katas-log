namespace Tennis.Tennis3
{
    public interface IScore
    {
        string GetScore(int playerOneScore, int playerTwoScore, string playerName);

        IScore SetNext(IScore score);
    }
}
