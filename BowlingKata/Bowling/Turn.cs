using System;
using System.Collections.Generic;
using System.Linq;

namespace Bowling
{
    public class Turn : ITurn
    {
        private readonly int _turnNumber;
        List<int> rolls = new List<int>(2);

        public List<int> Rolls => rolls;

        public Turn(int turnNumber)
        {
            if (turnNumber < 0 || turnNumber > 10)
            {
                throw new ArgumentException();
            }
            _turnNumber = turnNumber;
        }

        public int GetScore()
        {
            return rolls.Sum();
        }

        public bool IsComplete()
        {
            if (_turnNumber == 10)
            {
                return (IsStrike() || IsSpare()) && rolls.Count == 3 || (!IsStrike() && !IsSpare() && rolls.Count == 2);
            }
            return IsStrike() || rolls.Count == 2;
        }

        public bool IsSpare()
        {
            return rolls.Take(2).Sum() == 10 && !IsStrike();
        }

        public bool IsStrike()
        {
            return rolls.FirstOrDefault() == 10;
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

        public int Bonus(ITurn secondTurn, ITurn thirdTurn)
        {
            if (secondTurn is null && thirdTurn is null)
            {
                return 0;
            }
            if (IsStrike() && secondTurn.IsStrike())
            {
                if (thirdTurn is null)
                {
                    return secondTurn.Rolls.Take(2).Sum();
                }
                return secondTurn.Rolls.FirstOrDefault() + thirdTurn.Rolls.FirstOrDefault();
            }
            if (IsSpare())
            {
                return secondTurn.Rolls.FirstOrDefault();
            }
            if (IsStrike())
            {
                return secondTurn.Rolls.Sum();
            }

            return 0;
        }
    }
}
