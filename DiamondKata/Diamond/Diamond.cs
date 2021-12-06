using System;

namespace Diamond
{

    public class Diamond
    {
        private  char startChar = 'A';
        
        public string Print(char c)
        {
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

            return result;
        }
    }

}
