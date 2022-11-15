using NombresEnFrancais;
using Xunit;

namespace NombresEnFrancaisTests
{
    public class GetNumberInFrenchTests
    {
        [Fact]
        public void GetNumberInFrench_When1_ReturnsUn()
        {
            int un = 1;

            string result = NumberInFrench.GetNumberInFrench(un);

            Assert.Equal("un", result);
        }
    }
}
