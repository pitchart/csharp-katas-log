using System;
using System.Collections.Generic;
using System.Linq;

namespace Diamond
{

    public class Diamond
    {
        private  char startChar = 'A';
        
        public string Print(char c)
        {
            if (!char.IsLetter(c))
            {
                throw new ArgumentException("Character should be a letter");
            }

            c = char.ToUpper(c);

            char letter = startChar;
            List<string> lines = new List<string>();
            while (letter.CompareTo(c) <= 0)
            {
                string line = letter.ToString();
                if (letter != startChar)
                {
                    line += letter.ToString();
                }
                lines.Add(line);
                letter ++;
            }
            
            lines = lines.Concat(lines.ToArray().Reverse().Skip(1)).ToList();

            return string.Join(Environment.NewLine, lines);
        }
    }

}
