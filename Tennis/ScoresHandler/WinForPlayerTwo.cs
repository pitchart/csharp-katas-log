using Tennis.ScoresHandler;

namespace Tennis.ScoresHandler
{
    internal class WinForPlayerTwo : IScore
    {
        public string Handle(int _, int __)
        {
            return "Win for player2";
        }

        public bool Support(int playerOnePoint, int playerTwoPoint)
        {
            return playerTwoPoint >= 4 && (playerTwoPoint - playerOnePoint) >= 2;
        }
    }
}

