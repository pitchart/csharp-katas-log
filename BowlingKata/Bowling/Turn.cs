using System.Collections.Generic;
using System.Linq;

namespace Bowling
{
    //Todo : Make an interface to handle bonus turn
    internal class Turn
    {
        private const int MaximumPinsByTurn = 10;

        internal bool IsAStrike()
        {
            return _rolls.FirstOrDefault() == MaximumPinsByTurn;
        }

        private readonly List<int> _rolls = new List<int>(2);
        private readonly Turn _nextTurn;

        internal static Turn Build(int turnsNumber)
        {
            if (turnsNumber == 0)
            {
                return new Turn(null);
            }
            return new Turn(Build(turnsNumber - 1));
        }

        public Turn(Turn turn = null)
        {
            _nextTurn = turn;
        }

        internal int GetTotalScore() {
            return GetTotalScoreRec(0);
        }
        
        private int GetTotalScoreRec(int currentScore)
        {
            if (_nextTurn == null)
            {
                return currentScore;
            }
            int currentTurnScore = currentScore + GetScore() + GetBonus();
            return _nextTurn.GetTotalScoreRec(currentTurnScore);
        }

        private int GetBonus()
        {
            if (IsASpare())
            {
                return _nextTurn.GetFirstRollScore();
            }

            if (IsAStrike())
            {
                return _nextTurn.GetStrikeBonus();
            }

            return 0;
        }

        private int GetStrikeBonus()
        {
            return GetScore() + (IsAStrike() ? _nextTurn.GetFirstRollScore() : 0);
        }

        private int GetFirstRollScore()
        {
            return _rolls.FirstOrDefault();
        }

        private int GetScore()
        {
            return _rolls.Sum();
        }

        private bool IsASpare()
        {
            return GetScore() == MaximumPinsByTurn && !IsAStrike();
        }

        internal void Roll(int fallenPins)
        {
            if ((_rolls.Count == 2 || IsAStrike()) && _nextTurn != null)
            {
                _nextTurn.Roll(fallenPins);
                return;
            }

            _rolls.Add(fallenPins);
        }
    }
}
