using System.Collections.Generic;
using System.Linq;

namespace Bowling
{
    public class BaseTurn
    {
        protected List<int> rolls = new List<int>(2);

        public bool IsSpare()
        {
            return rolls.Take(2).Sum() == 10 && !IsStrike();
        }

        public bool IsStrike()
        {
            return rolls.FirstOrDefault() == 10;
        }
        
    }
}
