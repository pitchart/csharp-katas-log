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

            string result = "";
            List<string> lines = new List<string>();

            char letter = startChar;

            while (letter.CompareTo(c) <= 0)
            {
                lines.Add(letter.ToString());
                letter++;
            }

            lines = lines.Concat(lines.ToArray().Reverse().Skip(1)).ToList();
            
            return String.Join(Environment.NewLine, lines);
        }
    }

}
