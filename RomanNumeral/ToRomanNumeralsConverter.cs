using System;
using System.Collections.Generic;

namespace RomanNumeral
{
    public class ToRomanNumeralsConverter
    {
        private readonly Dictionary<int, string> _arabicToRoman = new Dictionary<int, string>
        {
            { 1, "I"},
            { 5, "V"}
        };

        public string Convert(int arabic)
        {
            return _arabicToRoman.GetValueOrDefault(arabic) ?? "";
        }
    }
}
