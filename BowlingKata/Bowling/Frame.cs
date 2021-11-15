using System.Collections.Generic;
using System.Linq;

namespace Bowling
{

    internal class Frame
    {
        private readonly List<int> _scores = new List<int>();

        private readonly Frame _next;

        private Frame()
        { }

        private Frame(Frame next)
        {
            _next = next;
        }

        private bool IsComplete => _scores.Count == 2; // 1

        private int Pins => _scores.Sum(); // 1

        private bool IsSpare => Pins == 10; // 1

        private int First => _scores.FirstOrDefault(); // 1

        internal static Frame Init(int number)
        {
            return number > 1 ? new Frame(Frame.Init(number - 1)) : new Frame(); // 4
        }

        internal void Score(int pins)
        {
            if (IsComplete) // 4
            {
                _next.Score(pins);
            }
            else
            {
                _scores.Add(pins);
            }
        }

        internal int GetScore()
        {
            var bonus = 0;
            if (IsSpare)// 4
            {
                bonus = _next.First; // 2
            }
            return Pins + bonus + (_next?.GetScore() ?? 0); // 1
        }
    }

}
