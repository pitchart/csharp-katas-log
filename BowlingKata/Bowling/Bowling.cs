using System;
using System.Collections.Generic;
using System.Linq;

namespace Bowling
{
    public class Bowling
    {
        private List<int> _scores = new List<int>();

        public void Roll(int pins)
        {
            _scores.Add(pins);

            if (pins == 10)
            {
                _scores.Add(0);
            }
        }

        public int Score()
        {
            int score = 0;
            for (int i = 0; i < 20; i += 2)
            {
                score += _scores[i] + _scores[i + 1];

                if (IsStrike(i))
                {
                    score += _scores[i + 2] + _scores[i + 3];
                }
                else if (IsSpare(i))
                {
                    score += _scores[i + 2];
                }
            }
            return score;
        }

        private bool IsStrike(int i)
        {
            return _scores[i] == 10;
        }

        private bool IsSpare(int turn)
        {
            return (_scores[turn] + _scores[turn + 1]) == 10;
        }
    }

}
