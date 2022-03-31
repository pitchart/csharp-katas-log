using System;
using System.Collections.Generic;
using System.Linq;

namespace Diamond
{
    public class Diamond
    {
        private char startChar = 'A';

        public string Draw(char c)
        {
            if( !char.IsLetter(c))
            {
                throw new ArgumentException();
            }

            List<string> lines = new List<string>();

            char letter = startChar;
            int lineIndex = startChar;
            string outer;
            string inner = " ";
            while (letter.CompareTo(c) <= 0)
            {
                outer = string.Empty.PadRight(c - lineIndex);
                string tempLetter = outer + letter;
                if (!letter.Equals(startChar))
                {
                    tempLetter += inner + letter;
                    inner += "  ";
                }
                tempLetter += outer;
                lines.Add(tempLetter);
                letter++;
                lineIndex++;
            }

            lines = lines.Concat(lines.ToArray().Reverse().Skip(1)).ToList();
            
            return string.Join(Environment.NewLine, lines);
        }
    }
}
