using System.Collections.Generic;
using System.Linq;

namespace Bowling
{

    internal class Frame
    {
        private readonly List<int> _scores = new List<int>();

        private readonly Frame _next;

        private Frame()
        {
        }

        private Frame(Frame next)
        {
            _next = next;
        }

        private bool IsComplete => _scores.Count == 2 || IsStrike; // 1

        private int Pins => _scores.Sum(); // 1

        private bool IsSpare => (Pins == 10) && _scores.Count == 2; // 1

        private bool IsStrike => First == 10; // 1

        private int First => _scores.FirstOrDefault(); // 1

        internal static Frame Init(int number)
        {
            return number > 1 ? new Frame(Frame.Init(number - 1)) : new Frame(); // 4 + 5
        }

        internal void Score(int pins)
        {
            if (IsComplete) // 4
            {
                _next.Score(pins); // 2
            }
            else
            {
                _scores.Add(pins); // 2
            }
        }

        internal int GetScore()
        {
            var bonus = (IsSpare, IsStrike) switch
            {
                (true, false) => _next.First, // 4
                (false, true) => _next.Pins, // 4
                _ => 0
            };

            return Pins + bonus + (_next?.GetScore() ?? 0); // 2
        }
    }
}
