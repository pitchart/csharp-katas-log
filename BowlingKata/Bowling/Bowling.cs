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
            _rounds = new Rounds(MAX_NON_BONUS_ROUNDS_PER_MATCH);
		}

        public void Roll(int pins)
        {
			_rounds.AddRound(pins);
        }

        public int GetScore()
        {
            int total = 0;
			while(!_rounds.IsEndOfGame())
			{
                total += _rounds.GetCurrentRound().GetScore(_rounds.GetNextRound(), _rounds.GetNextNextRound());
				_rounds.AdvanceNextRound();
            }

            return total;
        }
	}

	public class Rounds
	{
		private List<Round> _rounds;
		private int _currentRound;
		private int _maxRounds;

		public Rounds(int maxRounds)
		{
			_rounds = new List<Round>();
			_currentRound = 0;
			_maxRounds = maxRounds;

		}

		public void AddRound(int pins)
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

		private Round GetRound(int index)
		{
			return _rounds.ElementAtOrDefault(index);
		}

		public Round GetCurrentRound()
		{
			return GetRound(_currentRound);
		}

		public Round GetNextRound()
		{
			return GetRound(_currentRound + 1);
		}

		public Round GetNextNextRound()
		{
			return GetRound(_currentRound + 2);
		}

		public void AdvanceNextRound()
		{
			_currentRound++;
		}

		public bool IsEndOfGame()
		{
			return _currentRound >= _maxRounds;
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
