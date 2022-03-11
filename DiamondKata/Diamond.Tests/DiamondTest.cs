using FsCheck;
using FsCheck.Xunit;
using System;
using Xunit;

namespace Diamond.Tests
{
   
    public class DiamondTest
    {
       [Fact]
       public void Should_Draw_A()
        {
            char c = 'A';

            Assert.Equal("A", Diamond.Draw(c));
        }

    }

}
