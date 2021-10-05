using System.Collections.Generic;

namespace RomanNumeral
{
    public class ToRomanNumeralsConverter
    {
        private readonly Dictionary<int, string> arabicToRomain;

        public ToRomanNumeralsConverter()
        {
            arabicToRomain = new Dictionary<int, string>
            {
                { 1, "I" },
                { 4, "IV" },
                { 5, "V" },
                { 9, "IX" },
                { 10, "X" }
            };
        }

        public string Convert(int arabic)
        {
            string Romain = string.Empty;

            while (arabic > 0)
            {
                if(arabicToRomain.ContainsKey(arabic))
                {
                    BuildRomainNumber(ref arabic, ref Romain, arabic);
                }
                else if (arabic > 10)
                {
                    BuildRomainNumber(ref arabic, ref Romain, 10);
                }
                else if (arabic > 5)
                {
                    BuildRomainNumber(ref arabic, ref Romain, 5);
                }
                else
                {
                    BuildRomainNumber(ref arabic, ref Romain, 1);
                }
            }
            return Romain;
        }

        private void BuildRomainNumber(ref int arabic, ref string Romain, int indexNumber)
        {
            Romain += arabicToRomain.GetValueOrDefault(indexNumber);
            arabic -= indexNumber;
        }
    }
}
