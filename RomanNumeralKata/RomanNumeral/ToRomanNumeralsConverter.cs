using System.Collections.Generic;
using System.Linq;

namespace RomanNumeral
{
    public class ToRomanNumeralsConverter
    {
        private readonly Dictionary<int, string> _arabicToRomain;

        public ToRomanNumeralsConverter()
        {
            _arabicToRomain = new Dictionary<int, string>
            {
                { 1, "I" },
                { 4, "IV" },
                { 5, "V" },
                { 9, "IX" },
                { 10, "X" },
                { 40, "XL" },
                { 50, "L" },
                { 90, "XC" },
                {100, "C"},
                {1000, "M"}
            };
        }

        public string Convert(int arabic)
        {
            string romain = string.Empty;

            foreach (var arabicKey in _arabicToRomain.Reverse())
            {
                while (arabic >= arabicKey.Key)
                {
                    romain += arabicKey.Value;
                    arabic -= arabicKey.Key;
                }
            }
            
            return romain;
        }
    }
}
