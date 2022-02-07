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
            var firstPart = CreateFisrtPart(c);
            var lastPart = CreateLastPart(firstPart);            
            return firstPart.Concat( lastPart);
        }

        private IEnumerable<string> CreateLastPart(IEnumerable<string> firstPart)
        {
            
            return firstPart.Reverse().Skip(1);
        }

        private IEnumerable<string> CreateFisrtPart(char   c)
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
        }
    }

}
