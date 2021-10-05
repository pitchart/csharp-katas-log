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
        [InlineData(1, "I")]
        [InlineData(2, "II")]
        [InlineData(3, "III")]
        public void Should_be_Able_ToConvert_Into_SuccesiveOnes(int arabic, string romain)
        {
            _converter.Convert(arabic).Should().Be(romain);
        }

        [Theory]
        [InlineData(5, "V")]
        [InlineData(6, "VI")]
        [InlineData(7, "VII")]
        [InlineData(8, "VIII")]
        public void Should_be_Able_ToConvert_Into_BeginFive_And_SuccesiveOnes(int arabic, string romain)
        {
            _converter.Convert(arabic).Should().Be(romain);
        }

        [Fact]
        public void Should_be_IV_for_four()
        {
            _converter.Convert(4).Should().Be("IV");
        }

        [Fact]
        public void Should_be_IX_for_nine()
        {
            _converter.Convert(9).Should().Be("IX");
        }

        [Fact]
        public void Should_be_X_for_ten()
        {
            _converter.Convert(10).Should().Be("X");
        }

        [Fact]
        public void Should_be_XI_for_eleven()
        {
            _converter.Convert(11).Should().Be("XI");
        }
    }
}
