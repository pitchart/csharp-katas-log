using System;

namespace Diamond
{

    public class Diamond
    {
        public string Generate(char letter)
        {
            if (letter.Equals('A')) return "A";

            throw new ArgumentException(nameof(letter));
        }
    }

}
