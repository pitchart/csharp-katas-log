namespace Diamond
{

    public class DiamondTddVersion
    {
        public string Print(char letter)
        {
            if (char.ToUpper(letter) == 'A')
            {
                return "A";
            }

            return string.Empty;
        }
    }

}
