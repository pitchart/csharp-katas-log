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

                while (current.CompareTo(letter) <= 0)
                {
                    if (current.CompareTo('A') != 0)
                    {
                        result += current.ToString();
                    }
                    result += current.ToString();
                    current++;
                }

                return result;
            }

            return string.Empty;
        }
    }



}
