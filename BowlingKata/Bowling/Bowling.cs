using System;
using System.Collections.Generic;
using System.Linq;

namespace Bowling
{
    public class Bowling
    {
        private List<int> _scores = new List<int>();
        private List<Turn> _turns = new List<Turn>();

        public void Roll(int pins)
        {
            var turn = _turns.FirstOrDefault(turn => !turn.IsComplete());
            if(turn is null)
            {
                turn = new Turn(_turns.Count());
                _turns.Add(turn);
            }
            turn.Roll(pins);

            _scores.Add(pins);

            if (pins == 10 && IsFirstRollOfATurn(_scores.Count - 1))
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
                    score += _scores[i + 2] + (IsStrike(i + 2) ? _scores[i + 4] : _scores[i + 3]);
                }

                if (IsSpare(i))
                {
                    score += _scores[i + 2];
                }
            }
            return score;
        }

        private bool IsStrike(int i)
        {
            return _scores[i] == 10 && IsFirstRollOfATurn(i);
        }

        private static bool IsFirstRollOfATurn(int i)
        {
            return i % 2 == 0;
        }

        private bool IsSpare(int turn)
        {
            return (_scores[turn] + _scores[turn + 1]) == 10 && _scores[turn] != 10;
        }
    }

}
