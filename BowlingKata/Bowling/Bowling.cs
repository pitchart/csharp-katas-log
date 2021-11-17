using System.Collections.Generic;
using System.Linq;

namespace Bowling
{

    public class Bowling
    {
        private readonly Frame _frames;

        public Bowling()
        {
            _frames = Frame.Init(10); // 1
        }

        public void Roll(int pins)
        {
            _frames.Score(pins); // 2
        }

        public int Score()
        {
            return _frames.GetScore(); // 2
        }
    }

}
