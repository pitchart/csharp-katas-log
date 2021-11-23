using Tennis.ScoresHandler;

namespace Tennis
{
    internal class Deuce : IScore
    {
        public string Handle(int playerOnePoint, int playerTwoPoint)
        {
            return "Deuce";
        }

        public bool Support(int playerOnePoint, int playerTwoPoint)
        {
            return playerOnePoint == playerTwoPoint && playerOnePoint > 2;
        }
    }
}

