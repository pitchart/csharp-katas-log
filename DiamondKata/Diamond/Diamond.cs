using System;
using System.Linq;

namespace Diamond
{
    public class Diamond
    {
        public string Generate(char letter)
        {
            if(letter == '\0')
                throw new ArgumentException(nameof(letter));
            string result = "";
            for (char c = 'A'; c <= letter; c++)
            {
                result += c;
            }

            string reverse = string.Concat(result.Replace(letter.ToString(), string.Empty).ToCharArray().Reverse());
            result = result + reverse;

            return result;
        }
    }

}
