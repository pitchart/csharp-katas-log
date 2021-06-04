using System;
using System.Linq;

namespace Diamond
{

    public class DiamondTddVersion
    {
        public string Print(char letter)
        {
            if(!char.IsLetter(letter))
                return string.Empty;
            
            letter = char.ToUpper(letter);
            var compare = letter.CompareTo('A');
            var diamond = new string[(compare) + 1];

            var current = 'A';
            for (int i = 0; i < (compare)+1; i++)
            {
                diamond[i] = current.ToString();
                current++;
            }

            diamond = diamond.Concat(diamond.Reverse().Skip(1)).ToArray();

            return string.Join(Environment.NewLine, diamond);
        }
    }

}
