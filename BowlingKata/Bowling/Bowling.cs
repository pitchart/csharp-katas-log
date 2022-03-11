using System.Collections.Generic;
using System.Linq;

namespace Bowling
{
	public class Bowling
	{
		private const int MAX_NON_BONUS_ROUNDS_PER_MATCH = 10;
        private readonly Rounds _rounds;

        public Bowling ()
		{
            _rounds = new Rounds();
		}

        public void Roll(int pins)
        {
			_rounds.addRound(pins);
        }

        public int GetScore()
        {
            int total = 0;
            for (int currentRoundIndex = 0; currentRoundIndex < MAX_NON_BONUS_ROUNDS_PER_MATCH; currentRoundIndex += 1)
            {
                Round currentRound = _rounds.getRound(currentRoundIndex);
                Round nextRound = _rounds.getRound(currentRoundIndex + 1);
                Round nextNextRound = _rounds.getRound(currentRoundIndex + 2);

                int scoreRound = currentRound.GetScore(nextRound, nextNextRound);

                total += scoreRound;
            }

            return total;
        }
	}

	public class Rounds
	{
		private List<Round> _rounds;

		public Rounds()
		{
			_rounds = new List<Round>();
		}

		public void addRound(int pins)
		{
			if (!_rounds.LastOrDefault()?.SecondRoll.HasValue == true && !_rounds.LastOrDefault()?.IsStrike == true)
			{
				_rounds.Last().SecondRoll = pins;
			}
			else
			{
				_rounds.Add(new Round
                {
                    FirstRoll = pins
                });
			}
		}

		public Round getRound(int index)
		{
			return _rounds.ElementAtOrDefault(index);
		}
	}

	public class Round
	{
		private const int MAX_SCORE_PER_ROUND = 10;
		public int FirstRoll { get; set; }
		public int? SecondRoll { get; set; }
		public bool IsSpare
		{ 
			get
			{
				return (FirstRoll != MAX_SCORE_PER_ROUND) && (FirstRoll + SecondRoll == MAX_SCORE_PER_ROUND);
			} 
		}
		public bool IsStrike 
		{
			get
			{
				return FirstRoll == MAX_SCORE_PER_ROUND;
			} 
		}

		public int IntermediateScore
		{
			get
			{
				return FirstRoll + (SecondRoll ?? 0);
			} 
		}

        public int GetScore(Round nextRound, Round nextNextRound)
        {
            int score = IntermediateScore;

            if (IsSpare)
            {
                score += nextRound.FirstRoll;
            }
            if (IsStrike)
            {
                score += nextRound.FirstRoll;
                score += nextRound.IsStrike ? nextNextRound.FirstRoll : nextRound.SecondRoll.Value;
            }

            return score;
        }
	}
}
