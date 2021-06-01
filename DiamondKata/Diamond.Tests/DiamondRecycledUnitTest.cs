using System;
using Xunit;


namespace Diamond.Tests
{

    public class DiamondRecycledUnitTest
    {
        [Fact]
        public void ShouldBeEmpty_WhenInputISNotLetter()
        {
            var diamond = new DiamondRecycledVersion();
            var print = diamond.Print('*');

            Assert.Equal(string.Empty, print);
        }

        [Fact]
        void ShouldBeLetterA_WhenInputIsA()
        {
            var diamond = new DiamondRecycledVersion();
            var print = diamond.Print('A');

            Assert.Equal("A", print);
        }

        [Fact]
        void ShouldprintUpperCaseDiamond_WhenInputIsLowerCase()
        {
            var diamond = new DiamondRecycledVersion();
            var print = diamond.Print('a');

            Assert.Equal("A", print);
        }

        [Fact]
        void ShouldBeLetterA_WhenInputIsB()
        {
            var diamond = new DiamondRecycledVersion();
            var print = diamond.Print('B');

            Assert.Equal(            $" A " +
                $"{Environment.NewLine}B B" +
                $"{Environment.NewLine} A "
                , print);
        }

        [Fact]
        void ShouldBeDiamond_WhenInputIsC()
        {
            var diamond = new DiamondRecycledVersion();
            var print = diamond.Print('C');

            Assert.Equal(            $"  A  " +
                $"{Environment.NewLine} B B " +
                $"{Environment.NewLine}C   C" +
                $"{Environment.NewLine} B B " +
                $"{Environment.NewLine}  A  "
                , print);
        }

        [Fact]
        void ShouldBeDiamond_WhenInputIsD()
        {
            var diamond = new DiamondRecycledVersion();
            var print = diamond.Print('D');

            Assert.Equal(            $"   A   " +
                $"{Environment.NewLine}  B B  " +
                $"{Environment.NewLine} C   C " +
                $"{Environment.NewLine}D     D" +
                $"{Environment.NewLine} C   C " +
                $"{Environment.NewLine}  B B  " +
                $"{Environment.NewLine}   A   "
                , print);
        }

    }

}
