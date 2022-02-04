using System;
using System.Collections.Generic;
using System.Linq;

namespace Bowling
{

	public class Bowling
	{
        readonly List<int> rolls;

		public Bowling ()
		{
			rolls = new List<int>();
		}

		public void Roll(int v)
		{
			rolls.Add(v);
		}

		public int GetScore()
		{
			int total = rolls.Sum();

            

            return total;
		}
	}

}
