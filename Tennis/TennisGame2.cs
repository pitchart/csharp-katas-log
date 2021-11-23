using System.Collections.Generic;
using Tennis.ScoresHandler;

namespace Tennis
{
    public partial class TennisGame2 : ITennisGame
    {
        private int playerOnePoint;
        private int playerTwoPoint;
        private string firstPlayerName;
        private string secondPlayerName;
        private List<IScore> _scores = new List<IScore>() { new EqualityScore(), new Deuce(), new OnlyPlayerOneScore(), new OnlyPlayerTwoScore(),
            new PlayerOneDominatingScore(), new PlayerTwoDominatingScore(), new AdvantagePlayerOne(), new AdvantagePlayerTwo(), new WinForPlayerOne(), new WinForPlayerTwo()};

        public TennisGame2(string player1Name, string player2Name)
        {
            firstPlayerName = player1Name;
            playerOnePoint = 0;
            secondPlayerName = player2Name;
        }

        public string GetScore()
        {
            foreach (var score in _scores)
            {
                if (score.Support(playerOnePoint, playerTwoPoint))
                {
                    return score.Handle(playerOnePoint, playerTwoPoint);
                }
            }
            return string.Empty;
        }

        public void WonPoint(string player)
        {
            if (player == "player1")
                playerOnePoint++;
            else
                playerTwoPoint++;
        }
    }
}

