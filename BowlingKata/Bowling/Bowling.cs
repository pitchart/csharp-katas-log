﻿using System;
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
        }

        public int GetScore()
        {
            int score = 0;

            for (int i = 0; i < regularThrowLimit; i+= throwCountPerTurn)
            {
                int turnScore = throwsHistory[i] + throwsHistory[i+1];
                score += turnScore;

                if(turnScore == maxScorePerTurn)
                {
                    score += throwsHistory[i+2];
                }
            }

            return score;
        }
    }
}
