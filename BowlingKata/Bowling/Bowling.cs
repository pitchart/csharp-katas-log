using System.Collections.Generic;
using System.Linq;

namespace Bowling
{

    public class Bowling
    {
        private readonly Frame _frames;

        public Bowling()
        {
            _frames = new Frame(); // 1
            for (int i = 0; i < 9; i++) // 6
            {
                _frames.SetNext(new Frame()); // 1
            }
        }

        public void Roll(int pins)
        {
            _frames.Score(pins); // 5
        }

        public int Score()
        {
            return _frames.GetScore(); // 5
        }
    }

    internal class Frame
    {
        private int? _first;

        private int? _second;

        private Frame _next;

        public bool IsComplete()
        {
            return _first.HasValue && _second.HasValue; // 1
        }

        public Frame Score(int pins)
        {
            if (IsComplete()) // 4
            {
                _next.Score(pins);
            }
            else if (!_first.HasValue)// 4
            {
                _first = pins;
            }
            else
            {
                _second = pins;
            }

            return this;
        }

        public int GetScore()
        {
            var bonus = 0;
            if (IsSpare())// 4
            {
                bonus = _next?.First() ?? 0; // 2
            }
            return Pins() + bonus + (_next?.GetScore() ?? 0); // 1
        }

        private int Pins()
        {
            return (_first ?? 0) + (_second ?? 0); // 1
        }

        public bool IsSpare()
        {
            return Pins() == 10; // 1
        }

        public int First()
        {
            return _first ?? 0; // 1
        }

        public void SetNext(Frame frame)
        {
            if (_next == null) // 4
            {
                _next = frame;
            }
            else
            {
                _next.SetNext(frame);
            }
        }
    }

}
