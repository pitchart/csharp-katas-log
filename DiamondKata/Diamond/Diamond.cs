using System;

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

            string result = "";
            char letter = startChar;
            while (letter.CompareTo(c) <= 0)
            {
                result += letter;
                if (c != letter)
                {
                    result += Environment.NewLine;
                }
                letter ++;
            }

            if (c != startChar)
            {
                result += Environment.NewLine;
                result += startChar;
            }

            return result;
        }
    }

}
