using System;
using System.Collections.Generic;
using System.Linq;

namespace Bowling
{

    public class Bowling
    {
        private const int regularThrowLimit = 20;
        private const int maxScorePerTurn = 10;
        private const int throwCountPerTurn = 2;
        private List<int> throwsHistory = new List<int>();
        public void Roll(int fallenPins)
        {
            throwsHistory.Add(fallenPins);
            
            if (TurnIsAStrike(fallenPins) && throwsHistory.Count%2 == 1)
                throwsHistory.Add(0);
        }

        public int GetScore()
        {
            int score = 0;

            for (int i = 0; i < regularThrowLimit; i+= throwCountPerTurn)
            {
                int turnScore = throwsHistory[i] + throwsHistory[i+1];
                score += turnScore;

                if (TurnIsASpare(throwsHistory[i], throwsHistory[i + 1]))
                {
                    score += throwsHistory[i+2];
                }

                if (TurnIsAStrike(throwsHistory[i]))
                {
                    score += throwsHistory[i+2];
                    score += TurnIsAStrike(throwsHistory[i+2]) ? throwsHistory[i+4] : throwsHistory[i+3];
                }
            }

            return score;
        }

        private bool TurnIsAStrike(int firstThrow)
        {
            return firstThrow == maxScorePerTurn;
        }

        private bool TurnIsASpare(int firstThrow, int secondThrow)
        {
            return firstThrow < maxScorePerTurn && firstThrow + secondThrow == maxScorePerTurn;
        }
    }
}
