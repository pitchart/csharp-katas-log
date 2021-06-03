using System;
using System.Collections.Generic;
using System.Linq;

namespace RomanNumeral
{
    public class ToRomanNumeralsConverter
    {
        readonly Dictionary<int, string> _romainNumbers = new Dictionary<int, string>
        {
            { 1,"I"},
            { 5,"V"},
            { 10,"X"},
            { 50,"L"},
            { 100,"C"},
            { 500,"D"},
            { 1000,"M"},
        };
        

        public string Convert(int arabic)
        {
            return _romainNumbers.GetValueOrDefault(arabic, string.Empty);
        }
    }
}
