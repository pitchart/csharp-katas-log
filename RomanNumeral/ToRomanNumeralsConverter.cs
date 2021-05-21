using System.Collections.Generic;
using System.Linq;

namespace RomanNumeral
{
    public class ToRomanNumeralsConverter
    {
        private readonly Dictionary<int, string> _arabicToRoman = new Dictionary<int, string>
        {
            { 1, "I"},
            {4, "IV"},
            {5, "V"},
            {9, "IX"},
            {10, "X"},
            {40, "XL"},
            {50, "L"},
            {90, "XC"},
            {100, "C"},
            {400, "CD"},
            {500, "D"},
            {900, "CM"},
            {1000, "M"}
        };

        public string Convert(int arabic)
        {
            var result = string.Empty;

            foreach (var symbol in _arabicToRoman.Reverse())
            {
                while (arabic >= symbol.Key)
                {
                    result += symbol.Value;
                    arabic -= symbol.Key;
                }
            }
            return result;
        }
    }
}
