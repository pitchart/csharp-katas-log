using System;
using System.Collections.Generic;
using System.Linq;

namespace Bowling
{
	public class Bowling
	{
        private const int MAX_SCORE_PER_ROUND = 10;
        private const int LAUNCH_NUMBER_PER_ROUND = 2;
		private const int MAX_NON_BONUS_LAUNCH_PER_MATCH = 20;
        private readonly List<int> _rolls;
		private readonly List<Round> _rounds;

		public Bowling ()
		{
			_rolls = new List<int>();
			_rounds = new List<Round>();
		}

		public void Roll(int pins)
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

		// public void Roll(int v)
		// {
		// 	_rolls.Add(v);
		// }

		public int GetScore()
		{			
			int total = 0;
			foreach(var round in _rounds)
			{
				total += round.IntermediateScore; 
			}

			return total;
		}

		// public int GetScore()
		// {
		// 	int total = 0;
        //     for (int i = 0; i < MAX_NON_BONUS_LAUNCH_PER_MATCH; i += LAUNCH_NUMBER_PER_ROUND)
        //     {
        //         int scoreRound = _rolls[i] + _rolls[i+1];
        //         if (IsSpare(_rolls[i], _rolls[i+1]))
        //         {
        //             scoreRound += _rolls[i+2];
        //         }
		// 		if(IsStrike(_rolls[i]))
		// 		{
		// 			scoreRound += _rolls[i+2];
		// 			scoreRound += _rolls[i+2] == MAX_SCORE_PER_ROUND && (i+2) != MAX_NON_BONUS_LAUNCH_PER_MATCH ? _rolls[i+4] : _rolls[i+3];
		// 		}
        //         total += scoreRound;
        //     }

        //     return total;
		// }

		private bool IsSpare(int firstRoll, int secondRoll)
		{
			return (firstRoll != MAX_SCORE_PER_ROUND) && (firstRoll + secondRoll == MAX_SCORE_PER_ROUND);
		}

		private bool IsStrike(int firstRoll)
		{
			return firstRoll == MAX_SCORE_PER_ROUND;
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
				return FirstRoll + SecondRoll ?? 0;
			} 
		}
	}
}
