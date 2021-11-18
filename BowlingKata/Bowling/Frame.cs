using System;
using System.Collections.Generic;
using System.Linq;

namespace Bowling
{
    internal interface IFrame
    {
        int StrikeBonus { get; }

        int First { get; }

        void Score(int pins);
        int GetScore();
    }

    internal class Frame : IFrame
    {
        private readonly List<int> _scores = new List<int>();

        private readonly IFrame _next;

        private Frame(IFrame next)
        {
            _next = next;
        }

        private bool IsComplete => _scores.Count == 2 || IsStrike; // 1

        private int Pins => _scores.Sum(); // 1

        public int StrikeBonus => IsStrike ? Pins + _next.First : Pins;

        private bool IsSpare => (Pins == 10) && _scores.Count == 2; // 1

        private bool IsStrike => First == 10; // 1

        public int First => _scores.FirstOrDefault(); // 1

        internal static Frame Init(int number)
        {
            return number > 1 ? new Frame(Frame.Init(number - 1)) : new Frame(new BonusFrame()); // 4 + 5
        }

        public void Score(int pins)
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

        public int GetScore()
        {
            var bonus = (IsSpare, IsStrike) switch
            {
                (true, false) => _next.First, // 4
                (false, true) => _next.StrikeBonus, // 4
                _ => 0
            };

            return Pins + bonus + _next.GetScore(); // 2
        }
    }

    internal class BonusFrame : IFrame
    {
        private readonly List<int> _scores = new List<int>();

        public int StrikeBonus => _scores.Take(2).Sum();

        public int First => _scores.FirstOrDefault();

        public void Score(int pins)
        {
            _scores.Add(pins);
        }

        public int GetScore() => 0;
    }
}
