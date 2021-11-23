using Tennis.ScoresHandler;

namespace Tennis
{
    internal class AdvantagePlayerTwo : IScore
    {
        public string Handle(int _, int __)
        {
            return "Advantage player2";
        }

        public bool Support(int playerOnePoint, int playerTwoPoint)
        {
            return (playerTwoPoint - playerOnePoint) == 1 && playerOnePoint >= 3;
        }
    }
}

