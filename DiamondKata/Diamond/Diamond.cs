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

            while (letter.CompareTo(c) <= 0)
            {
                string tempLetter = letter.ToString();
                if (!letter.Equals(startChar))
                {
                    tempLetter += letter.ToString();
                }
                lines.Add(tempLetter);
                letter++;
            }

            lines = lines.Concat(lines.ToArray().Reverse().Skip(1)).ToList();
            
            return string.Join(Environment.NewLine, lines);
        }
    }

}
