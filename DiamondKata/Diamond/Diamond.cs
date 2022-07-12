using System;
using System.Collections.Generic;
using System.Linq;

namespace Diamond
{
    public class Diamond
    {
        public static string Display(char letter)
        {
            IEnumerable<char> diamond = Pyramid(letter);
            diamond = diamond.Concat(diamond.Reverse().Skip(1));
            return String.Join(Environment.NewLine, diamond);
        }

        private static IEnumerable<char> Pyramid(char letter)
        {
            return Enumerable.Range((int)'A', (int)letter - (int)'A' + 1).Select(i => (char)i);
        }
    }
}
