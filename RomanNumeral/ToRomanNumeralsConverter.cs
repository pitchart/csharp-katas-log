using System.Collections.Generic;
using System.Linq;

namespace RomanNumeral
{
    public class ToRomanNumeralsConverter
    {
        private readonly Dictionary<int, string> _arabicToRoman = new Dictionary<int, string>
        {
            { 1, "I"},
            { 5, "V"},
            {10, "X"},
            {50, "L"},
            {100, "C"},
            {500, "D"},
            {1000, "M"}
        };

        public string Convert(int arabic)
        {
            if (_arabicToRoman.ContainsKey(arabic)) return _arabicToRoman.GetValueOrDefault(arabic);

            var result = string.Empty;

            foreach (var symbol in _arabicToRoman.Reverse())
            {
                if (arabic > symbol.Key)
                {
                    for (int i = 0; i < arabic; i += symbol.Key)
                    {
                        result += symbol.Value;
                    }
                    break;
                }
            }
            return result;
        }
    }
}
