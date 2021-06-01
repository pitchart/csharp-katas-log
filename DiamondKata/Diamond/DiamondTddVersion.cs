using System;

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
            var diamond = new string[(compare * 2) + 1];

            for (int i = 0; i < (compare*2)+1; i++)
            {
                diamond[i] = "A";
            }

            return string.Join(Environment.NewLine, diamond);
        }
    }

}
