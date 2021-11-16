namespace Tennis.ScoresHandler
{
    public interface IScore
    {
        string Handle(int playerOnePoint, int playerTwoPoint);

        bool Support(int playerOnePoint, int playerTwoPoint);
    }
}

