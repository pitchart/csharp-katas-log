namespace RomanNumeral
{
    public class ToRomanNumeralsConverter
    {
        public string Convert(int arabic)
        {
            string One = "I";

            string Romain = string.Empty;

            while (arabic > 0)
            {
                Romain = string.Concat(Romain, One);
                arabic--;

            }
            return Romain;

        }

    }
}
