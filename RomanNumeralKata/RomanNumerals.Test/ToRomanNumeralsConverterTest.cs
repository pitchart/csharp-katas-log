using System;
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
        [InlineData(1,"I")]
        [InlineData(2, "II")]
        [InlineData(3, "III")]
        public void Should_be_Able_ToConvert_Into_SuccesiveOnes(int arabic, string romain)
        {
            _converter.Convert(arabic).Should().Be(romain);
        }

    }
}
