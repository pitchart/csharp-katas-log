using System.Collections.Generic;
using System.Linq;

namespace Bowling
{
    internal class BonusTurn : ITurn
    {

        private readonly List<int> _rolls = new List<int>(2);
        public int GetFirstRollScore()
        {
            return _rolls.FirstOrDefault();
        }

        public int GetStrikeBonus()
        {
            return GetTotalScore();
        }

        public int GetTotalScore()
        {
            return _rolls.Sum();
        }

        public int GetTotalScoreRec(int currentScore)
        {
            return currentScore;
        }

        public void Roll(int fallenPins)
        {
            _rolls.Add(fallenPins);
        }
    }
}