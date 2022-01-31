using System;
using System.Collections.Generic;
using System.Linq;

namespace Diamond
{
    public class Diamond2
    {
        private char startChar = 'A';

        public string Print(char c)
        {
            if (!char.IsLetter(c))
            {
                throw new ArgumentException("Character should be a letter");
            }

            if (char.ToUpper(c) == 'A')
            {
                return "A";
            }

            return string.Join(Environment.NewLine, BuildDiamond(char.ToUpper(c)));
        }      

        private IEnumerable<string> BuildDiamond(char c)
        {
            char letter = startChar;
            string outer = string.Empty.PadRight(c - startChar + 1);
            string inner = " ";

            while (letter.CompareTo(c) <= 0)
            {
                outer = outer[1..];
                string line = outer + letter;
                if (letter != startChar)
                {
                    line += inner + letter;
                    inner += "  ";
                }

                line += outer; 

                yield return line;
                letter++;
            }

            letter--;
            letter--;
            inner = inner[2..];
            
            while (letter.CompareTo(startChar) >= 0)
            {
                outer += " ";
                string line = outer + letter;
                if (letter != startChar)
                {
                    inner = inner[2..];
                    line += inner + letter;
                }

                line += outer; 

                yield return line;
                letter--;
            }
        }
    }

}
