using System;
using System.Linq;

namespace Diamond
{

    public class DiamondTddVersion
    {
        public string Print(char letter)
        {
            if (!char.IsLetter(letter))
                return string.Empty;

            letter = char.ToUpper(letter);
            var compare = letter.CompareTo('A');
            var diamond = new string[(compare) + 1];

            var current = 'A';
            for (int i = 0; i < (compare) + 1; i++)
            {
                diamond[i] = string.Empty.PadRight(compare - i, ' ');

                diamond[i] += current.ToString();

                if (current != 'A')
                {
                    diamond[i] += string.Empty.PadRight((2 * i) - 1, ' ');
                    diamond[i] += current.ToString();
                }

                diamond[i] += string.Empty.PadRight(compare - i, ' ');

                current++;
            }

            diamond = diamond.Concat(diamond.Reverse().Skip(1)).ToArray();

            return string.Join(Environment.NewLine, diamond);
        }
    }

}
