using System;
using System.Collections.Generic;
using System.Linq;

namespace Diamond
{

    public class Diamond
    {
        private char startChar = 'A';

        public string Print(char c)
        {
            if (!char.IsLetter(c))
            {
                throw new ArgumentException("Character should be a letter");
            }

            c = char.ToUpper(c);

            char letter = startChar;
            List<string> lines = new List<string>();
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

                lines.Add(line);
                letter++;
            }

            lines = lines.Concat(lines.ToArray().Reverse().Skip(1)).ToList();

            return string.Join(Environment.NewLine, lines);
        }
    }

}
