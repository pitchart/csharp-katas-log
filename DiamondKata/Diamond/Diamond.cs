using System;
using System.Collections.Generic;
using System.Linq;

namespace Diamond
{
    public class Diamond
    {
        public static string Display(char letter)
        {
            IEnumerable<string> diamond = Pyramid(letter);
            diamond = diamond.Concat(diamond.Reverse().Skip(1));
            return String.Join(Environment.NewLine, diamond);
        }

        private static IEnumerable<string> Pyramid(char letter)
        {
            var outerSpaceNumber = (int)letter - (int)'A';
            var innerSpaceNumber = 0;
            IEnumerable<int> upperLetters = Enumerable.Range((int)'A', (int)letter - (int)'A' + 1);

            var lines = new List<string>();
            foreach(var upperLetter in upperLetters)
            {
                var line = BuildLine(outerSpaceNumber, upperLetter, innerSpaceNumber) ;
                lines.Add(line);
                outerSpaceNumber = --outerSpaceNumber;
                innerSpaceNumber = innerSpaceNumber == 0 ? innerSpaceNumber = 1 : innerSpaceNumber+2;
            }
            return lines;
        }

        private static string BuildLine(int outerSpaceNumber, int upperLetter, int innerSpaceNumber)
        {
            string outerSpaces = string.Empty.PadLeft(outerSpaceNumber);
            string innerSpaces = string.Empty.PadLeft(innerSpaceNumber);

            if (innerSpaceNumber == 0) return outerSpaces + ((char)upperLetter).ToString() + outerSpaces;
            //TODO : Refacto
            return outerSpaces + ((char)upperLetter).ToString() + innerSpaces + ((char)upperLetter).ToString() + outerSpaces;
        }
    }
}
