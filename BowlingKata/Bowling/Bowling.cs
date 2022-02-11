using System;
using System.Collections.Generic;
using System.Linq;

namespace Bowling
{

    public class Bowling
    {
        private List<int> _rolls = new List<int>();

        public void Roll(int pins)
        {
            _rolls.Add(pins);

            if (pins == 10)
            {
                _rolls.Add(0);
            }
        }

        public int Score()
        {
            var total = 0;

            for (int i = 0; i < _rolls.Count; i += 2)
            {
                var turnScore = _rolls[i] + _rolls[i + 1];

                total += turnScore;

                if (_rolls[i] == 10)
                {
                    total += _rolls[i + 2] + _rolls[i + 3];
                }
                else if (TurnIsSpare(turnScore))
                {
                    total += _rolls[i + 2];
                }
            }

            return total;
        }

        private bool TurnIsSpare(int turnScore)
        {
            return turnScore == 10;
        }
    }

}
