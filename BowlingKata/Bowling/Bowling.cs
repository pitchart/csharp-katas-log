using System;
using System.Collections.Generic;
using System.Linq;

namespace Bowling
{
	public class Bowling
	{
        private const int MAX_SCORE_PER_ROUND = 10;
        private const int LAUNCH_NUMBER_PER_ROUND = 2;
		private const int MAX_LAUNCH_PER_MATCH = 20;
        readonly List<int> rolls;

		public Bowling ()
		{
			rolls = new List<int>();
		}

		public void Roll(int v)
		{
			rolls.Add(v);
		}

		public int GetScore()
		{
			int total = 0;
            for (int i = 0; i < MAX_LAUNCH_PER_MATCH; i += LAUNCH_NUMBER_PER_ROUND)
            {
                int scoreRound = rolls[i] + rolls[i+1];
                if (IsSpare(rolls[i], rolls[i+1]))
                {
                    scoreRound += rolls[i+2];
                }
				if(IsStrike(rolls[i]))
				{
					scoreRound += rolls[i+2];
					scoreRound += rolls[i+2] == MAX_SCORE_PER_ROUND && (i+2) != MAX_LAUNCH_PER_MATCH ? rolls[i+4] : rolls[i+3];
				}
                total += scoreRound;
            }

            return total;
		}

		private bool IsSpare(int firstRoll, int secondRoll)
		{
			return (firstRoll != MAX_SCORE_PER_ROUND) && (firstRoll + secondRoll == MAX_SCORE_PER_ROUND);
		}

		private bool IsStrike(int firstRoll)
		{
			return firstRoll == MAX_SCORE_PER_ROUND;
		}
	}

}
