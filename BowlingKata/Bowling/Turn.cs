using System;
using System.Collections.Generic;
using System.Linq;

namespace Bowling
{
    internal class Turn
    {
        public bool IsComplete => _rolls.Count == 2 || IsAStrike();

        internal bool IsAStrike()
        {
            return _rolls.FirstOrDefault() == 10;
        }

        private readonly List<int> _rolls = new List<int>(2);
        private readonly Turn _nextTurn;

        internal static Turn BuildDefault()
        {
            return Build(10);
        }

        private static Turn Build(int turnsNumber)
        {
            if (turnsNumber == 1)
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
                return _nextTurn.GetCompleteStrikeBonus();
            }

            return 0;
        }

        private int GetCompleteStrikeBonus()
        {
            return GetScore() + (IsAStrike() ? _nextTurn.GetFirstRollScore() : 0);
        }

        internal int GetFirstRollScore()
        {
            return _rolls.FirstOrDefault();
        }

        internal void Roll(int fallenPins)
        {
            _rolls.Add(fallenPins);
        }

        internal int GetScore()
        {
            return _rolls.Sum();
        }

        internal bool IsASpare()
        {
            return GetScore() == 10 && !IsAStrike();
        }

        internal int GetStrikeBonus()
        {
            return GetScore();
        }
    }
}