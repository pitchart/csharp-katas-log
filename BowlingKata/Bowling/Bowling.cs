using System.Collections.Generic;
using System.Linq;

namespace Bowling
{

    public class Bowling
    {
        private readonly List<int> scores = new List<int>(); // 1

        public void Roll(int pins)
        {
            scores.Add(pins); // 3
        }

        public int Score()
        {
            return scores.Sum(); // 3
        }
    }

}
