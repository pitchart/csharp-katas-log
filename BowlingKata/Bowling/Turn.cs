using System;
using System.Collections.Generic;
using System.Linq;

namespace Bowling
{
    internal class Turn
    {
        public bool IsComplete => rolls.Count == 2 || IsAStrike();

        internal bool IsAStrike()
        {
            return rolls.FirstOrDefault() == 10;
        }

        private List<int> rolls = new List<int>();

        internal void Roll(int fallenPins)
        {
            rolls.Add(fallenPins);
        }

        internal int GetScore()
        {
            return rolls.Sum();
        }

        internal bool IsASpare()
        {
            return GetScore() == 10 && !IsAStrike();
        }
    }
}