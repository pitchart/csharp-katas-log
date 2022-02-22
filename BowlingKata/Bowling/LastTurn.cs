using System;
using System.Collections.Generic;
using System.Linq;

namespace Bowling
{
    public class LastTurn : BaseTurn, ITurn
    {
        public List<int> Rolls => rolls;

        public bool IsComplete()
        {
            return Rolls.Count == 3 || (!IsStrike() && !IsSpare() && Rolls.Count == 2);
        }

        public void Roll(int pins)
        {
            if (pins < 0 || pins > 10)
            {
                throw new ArgumentException();
            }
            if (IsComplete())
            {
                throw new NotAllowRollException();
            }

            rolls.Add(pins);
        }

        public int GetScore()
        {
            return Rolls.Sum();
        }
    }
}
