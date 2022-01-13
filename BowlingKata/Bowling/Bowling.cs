using System;
using System.Collections.Generic;
using System.Linq;

namespace Bowling
{

    public class Bowling
    {
        private const int RegularThrowLimit = 20;
        private const int ThrowCountPerTurn = 2;

        private Turn _firstTurn;
        private readonly List<Turn> _turns = new List<Turn>();

        public Bowling()
        {
            _firstTurn = Turn.BuildDefault();
        }

        public void Roll(int fallenPins)
        {
            //TODO: Refactorisez avec _firstTurn.Roll
            if(!_turns.Any() || _turns.LastOrDefault()?.IsComplete == true)
            {
                _turns.Add(new Turn());
            }

            _turns.Last().Roll(fallenPins);
            
        }

        public int GetScore()
        {

            int score = 0;
            int newScore = _firstTurn.GetTotalScore();


            for (int i = 0; i < RegularThrowLimit; i+= ThrowCountPerTurn)
            {
                Turn currentTurn = _turns[i/2];
                int turnScore = currentTurn.GetScore();
                score += turnScore;

                if (currentTurn.IsASpare())
                {
                    score += _turns[i/2+1].GetFirstRollScore();
                    continue;
                }

                if (currentTurn.IsAStrike())
                {
                    score += _turns[i/2+1].GetScore();
                    score += _turns[i/2+1].IsAStrike() ? _turns[i/2+2].GetFirstRollScore() : 0;
                }
            }

            return score;
        }

    }
}
