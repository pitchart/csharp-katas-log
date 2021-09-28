using System.Collections.Generic;

namespace RomanNumeral
{
    public class ToRomanNumeralsConverter
    {
        public string Convert(int arabic)
        {
            Dictionary<int, string> arabicToRomain = new Dictionary<int, string>
            {
                { 1, "I" },
                { 4, "IV" },
                { 5, "V" },
                { 10, "X" }
            };

            string One = "I";
            string Five = "V";
            string Ten = "X";
            string Romain = string.Empty;

            while (arabic > 0)
            {
                if(arabicToRomain.ContainsKey(arabic))
                {
                    Romain += arabicToRomain.GetValueOrDefault(arabic);
                    arabic -= arabic;
                }
                else if (arabic >= 5)
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
