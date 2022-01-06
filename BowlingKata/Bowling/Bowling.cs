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

        private List<Turn> turns = new List<Turn>();

        
        public void Roll(int fallenPins)
        {
            if(!turns.Any() || turns.LastOrDefault()?.IsComplete == true)
            {
                turns.Add(new Turn());
            }

            turns.Last().Roll(fallenPins);
            
            throwsHistory.Add(fallenPins);
            
            if (TurnIsAStrike(fallenPins) && throwsHistory.Count%2 == 1)
                throwsHistory.Add(0);
        }

        public int GetScore()
        {

            int score = 0;

            for (int i = 0; i < regularThrowLimit; i+= throwCountPerTurn)
            {
                Turn currentTurn = turns[i/2];
                int turnScore = currentTurn.GetScore();/*  throwsHistory[i] + throwsHistory[i+1]; */
                score += turnScore;

                if (currentTurn.IsASpare())
                {
                    score += throwsHistory[i+2];
                }

                if (currentTurn.IsAStrike())
                {
                    score += throwsHistory[i+2];
                    score += turns[i/2+1].IsAStrike() ? throwsHistory[i+4] : throwsHistory[i+3];
                }
            }

            return score;
        }

        private bool TurnIsAStrike(int firstThrow)
        {
            return firstThrow == maxScorePerTurn;
        }
    }
}
