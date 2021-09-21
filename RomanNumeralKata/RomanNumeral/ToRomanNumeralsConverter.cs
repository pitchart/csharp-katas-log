namespace RomanNumeral
{
    public class ToRomanNumeralsConverter
    {
        public string Convert(int arabic)
        {
            if (arabic == 1)
            {
                return "I";
            }

            if (arabic == 2)
            {
                return "II";
            }

            return string.Empty;
        }
    }
}
