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

        [Fact]
        public void Should_be_I_for_one()
        {
            _converter.Convert(1).Should().Be("I");
        }

        [Fact]
        public void Should_be_II_for_two()
        {
            _converter.Convert(2).Should().Be("II");
        }

        [Fact]
        public void Should_be_III_for_three()
        {
            _converter.Convert(3).Should().Be("III");
        }

    }
}
