using NombresEnFrancais;
using Xunit;

namespace NombresEnFrancaisTests
{
    public class GetNumberInFrenchTests
    {
        [Fact]
        public void GetNumberInFrench_When0_ReturnsZero()
        {
            int zero = 0;

            string result = NumberInFrench.GetNumberInFrench(zero);

            Assert.Equal("zero", result);
        }

        [Fact]
        public void GetNumberInFrench_When1_ReturnsUn()
        {
            int un = 1;

            string result = NumberInFrench.GetNumberInFrench(un);

            Assert.Equal("un", result);
        }

        [Theory]
        [InlineData(2, "deux")]
        [InlineData(3, "trois")]
        [InlineData(4, "quatre")]
        [InlineData(5, "cinq")]
        [InlineData(6, "six")]
        [InlineData(7, "sept")]
        [InlineData(8, "huit")]
        [InlineData(9, "neuf")]
        public void GetNumberInFrench_WhenUnit_ReturnsUnitAsString(int number, string expected)
        {
            string result = NumberInFrench.GetNumberInFrench(number);

            Assert.Equal(expected, result);
        }
    }
}
