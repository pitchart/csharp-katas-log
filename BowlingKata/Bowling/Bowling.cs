using System;

namespace Bowling
{

    public class Bowling
    {
        private int _playerScore = 0;

        public void Roll(int i)
        {
            _playerScore += i;
        }

        public int GetScore()
        {
            return _playerScore;
        }
    }

}
