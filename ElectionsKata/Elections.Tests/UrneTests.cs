using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Elections.Tests
{
    public class UrneTests
    {
        [Fact]
        public void Should_return_number_of_votes()
        {
            var urne = new Urne();
            urne.Vote("1");
            urne.Vote("2");
            urne.Vote("3");

            Assert.Equal(3, urne.GetTotalVote());
        }

        [Fact]
        public void Should_return_number_of_blank_votes()
        {
            var urne = new Urne();
            urne.Vote("NotBlank");
            urne.Vote("");
            urne.Vote("NotBlank");

            Assert.Equal(1, urne.GetNumberBlankVotes());
        }
    }
}
