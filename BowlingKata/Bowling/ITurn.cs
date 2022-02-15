using System.Collections.Generic;

namespace Bowling
{
    public interface ITurn
    {
        void Roll(int pins);

        bool IsComplete();

        bool IsStrike();

        List<int> Rolls { get; }

        int GetScore();
    }
}
