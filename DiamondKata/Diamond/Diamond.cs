using System;

namespace Diamond
{
    public class Diamond
    {
        public string Print(char letter)
        {
            if (char.IsLetter(letter))
            {
                var current = 'A';
                var result = "";

                letter = char.ToUpper(letter);
                var range = 0;

                while (current.CompareTo(letter) <= 0)
                {
                    range = current.CompareTo('A') - 1;
                    
                    if (current.CompareTo('A') != 0)
                    {
                        result += current.ToString();
                        result += " ";
                        result = result.PadRight(2 * range, 'Z');
                    }
                    result += current.ToString();
                    result += Environment.NewLine;
                    current++;
                }

                return result;
            }

            return string.Empty;
        }
    }



}
