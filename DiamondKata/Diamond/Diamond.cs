using System;
using System.Collections.Generic;
using System.Linq;

namespace Diamond
{
    public class Diamond
    {
        public string Print(char letter)
        {
            if (char.IsLetter(letter))
            {
                var current = 'A';
                var result = new List<string>();

                letter = char.ToUpper(letter);
                var innerSpace = 0;
                var outerSpace = 0;

                while (current.CompareTo(letter) <= 0)
                {
                    var line = "";
                    innerSpace = current.CompareTo('A') - 1;
                    outerSpace = Math.Abs(current.CompareTo(letter));

                    line = SpacesString(outerSpace);
                    line += current.ToString();

                    if (current.CompareTo('A') != 0)
                    {
                        line += SpacesString((2 * innerSpace) + 1);
                        line += current.ToString();
                    }

                    line += SpacesString(outerSpace);

                    result.Add(line);
                    current++;
                }

                result = result.Concat(result.ToArray().Reverse().Skip(1)).ToList();

                return String.Join(Environment.NewLine, result);
            }

            return string.Empty;
        }

        private string SpacesString(int number)
        {
            return string.Empty.PadLeft(number, ' ');
        }

    }
}
