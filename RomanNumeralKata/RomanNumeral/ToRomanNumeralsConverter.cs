namespace RomanNumeral
{
    public class ToRomanNumeralsConverter
    {
        public string Convert(int arabic)
        {
            string One = "I";
            string Five = "V";
            string Romain = string.Empty;

            while (arabic > 0)
            {
                if (arabic >= 5)
                {
                    Romain = Five;
                    arabic -= 5;
                }
                else
                {
                    Romain = string.Concat(Romain, One);
                    arabic--;
                }
            }
            return Romain;
        }

    }
}
