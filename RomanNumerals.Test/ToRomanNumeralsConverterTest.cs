using FluentAssertions;
using RomanNumeral;
using Xunit;

namespace RomanNumerals.Test
{
    public class ToRomanNumeralsConverterTest
    {
        private readonly ToRomanNumeralsConverter _converter;

        public ToRomanNumeralsConverterTest()
        {
            this._converter = new ToRomanNumeralsConverter();
        }

        [Fact]
        public void Should_be_empty_for_zero()
        {
            _converter.Convert(0).Should().Be("");
        }

        [Theory]
        [InlineData(1, "I")]
        [InlineData(5, "V")]
        [InlineData(10, "X")]
        [InlineData(50, "L")]
        [InlineData(100, "C")]
        [InlineData(500, "D")]
        [InlineData(1000, "M")]
        public void Should_convert_symbols(int arabic, string roman)
        {
            _converter.Convert(arabic).Should().Be(roman);
        }

        [Theory]
        [InlineData(2, "II")]
        [InlineData(3, "III")]
        [InlineData(20, "XX")]
        [InlineData(30, "XXX")]
        [InlineData(200, "CC")]
        public void Should_Convert_to_repetitive_symbol(int arabic, string roman)
        {
            _converter.Convert(arabic).Should().Be(roman);
        }
    }
}
