using System.Collections.Generic;
using System.Linq;

namespace Bowling
{
    //Todo : Make an interface to handle bonus turn
    public class Turn : ITurn
    {
        private const int MaximumPinsByTurn = 10;

        public bool IsAStrike()
        {
            return _rolls.FirstOrDefault() == MaximumPinsByTurn;
        }

        private readonly List<int> _rolls = new List<int>(2);
        private readonly ITurn _nextTurn;

        public static ITurn Build(int turnsNumber)
        {
            if (turnsNumber == 0)
            {
                return new BonusTurn();
            }
            return new Turn(Build(turnsNumber - 1));
        }

        public Turn(ITurn turn = null)
        {
            _nextTurn = turn;
        }

        public int GetTotalScore()
        {
            return GetTotalScoreRec(0);
        }

        public int GetTotalScoreRec(int currentScore)
        {
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

        public int GetStrikeBonus()
        {
            return GetScore() + (IsAStrike() ? _nextTurn.GetFirstRollScore() : 0);
        }

        public int GetFirstRollScore()
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

        public void Roll(int fallenPins)
        {
            if (_rolls.Count == 2 || IsAStrike())
            {
                _nextTurn.Roll(fallenPins);
                return;
            }

            _rolls.Add(fallenPins);
        }
    }
}
