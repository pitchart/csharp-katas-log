namespace Tennis.Points
{

    public interface IPoint
    {
        string GetScore(string name = "");
        IPoint ScoreP1();
        IPoint ScoreP2();
    }

}
