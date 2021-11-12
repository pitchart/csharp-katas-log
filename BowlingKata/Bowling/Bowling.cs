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
            int score = 0; // 1
            for (int i = 0; i < 20; i = i + 2)// 6
            {
                int frameScore = scores[i] + scores[i + 1]; // 1 + 3
                score += frameScore; // 7
                if (frameScore == 10) // 4
                {
                    score += scores[i + 2]; // 7
                }
            }
            return score; // 1
        }
    }

}
