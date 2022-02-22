using System;
using System.Collections.Generic;
using System.Linq;

namespace Bowling
{
    public class Turn : BaseTurn, ITurn 
    {
        private readonly int _turnNumber;

        public List<int> Rolls => rolls;

        public Turn(int turnNumber)
        {
            if (turnNumber < 0 || turnNumber >= 10)
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
            return IsStrike() || rolls.Count == 2;
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

        public int Bonus(Turn secondTurn, ITurn thirdTurn)
        {
            if (secondTurn is null || thirdTurn is null)
            {
                return 0;
            }
            if (IsSpare())
            {
                return secondTurn.Rolls.FirstOrDefault();
            }
            if (IsStrike())
            {
                if(secondTurn.IsStrike())
                {
                    return secondTurn.Rolls.FirstOrDefault() + thirdTurn.Rolls.FirstOrDefault();
                }
                return secondTurn.Rolls.Sum();
            }

            return 0;
        }

        public int Bonus(LastTurn lastTurn)
        {
            if (lastTurn is null)
            {
                throw new ArgumentNullException();
            }

            if (IsStrike())
            {
                return lastTurn.Rolls.Take(2).Sum();
            }

            if (IsSpare())
            {
                return lastTurn.Rolls.FirstOrDefault();
            }

            return 0;
        }
    }
}
