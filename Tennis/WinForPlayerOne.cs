using Tennis.ScoresHandler;

namespace Tennis
{
    internal class WinForPlayerOne : IScore
    {
        public string Handle(int _, int __)
        {
            return "Win for player1";
        }

        public bool Support(int playerOnePoint, int playerTwoPoint)
        {
            return playerOnePoint >= 4 && (playerOnePoint - playerTwoPoint) >= 2;
        }
    }
}

