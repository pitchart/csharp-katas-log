using System.Collections.Generic;
using System.Linq;

namespace Bowling
{
    public class Bowling
    {
        private List<ITurn> _turns = new List<ITurn>();

        public void Roll(int pins)
        {
            var turn = _turns.FirstOrDefault(turn => !turn.IsComplete());
            if(turn is null)
            {
                turn = _turns.Count() + 1 == 10 ? (ITurn)new LastTurn() : new Turn(_turns.Count() + 1);
                _turns.Add(turn);
            }
            turn.Roll(pins);
        }

        public int Score()
        {
            int tempScore = 0;
            foreach (ITurn turn in _turns)
            {
                int currentIndex = _turns.IndexOf(turn);

                tempScore += turn switch
                {
                    LastTurn lastTurn => lastTurn.GetScore(),
                    Turn currentTurn when _turns[currentIndex + 1] is LastTurn => currentTurn.GetScore() +
                        currentTurn.Bonus(_turns[currentIndex + 1], null),
                    _ => turn.GetScore() +
                         (turn as Turn).Bonus(_turns[currentIndex + 1], _turns[currentIndex + 2])
                };
            }
            return tempScore;
        }
    }
}
