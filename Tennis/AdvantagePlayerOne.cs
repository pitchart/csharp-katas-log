using Tennis.ScoresHandler;

namespace Tennis
{
    internal class AdvantagePlayerOne : IScore
    {
        public string Handle(int _, int __)
        {
            return "Advantage player1";
        }

        public bool Support(int playerOnePoint, int playerTwoPoint)
        {
            return (playerOnePoint - playerTwoPoint) == 1 && playerTwoPoint >= 3;
        }
    }
}

