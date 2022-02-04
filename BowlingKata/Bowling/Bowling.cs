using System;
using System.Collections.Generic;
using System.Linq;

namespace Bowling
{

	public class Bowling
	{
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
            for (int i = 0; i < rolls.Count; i += 2)
            {
                int scoreRound = rolls[i] + rolls[i+1];
                if (scoreRound == 10)
                {
                    scoreRound += rolls[i+2];
                }
                total += scoreRound;
            }

            return total;
		}
	}

}
