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

        [Fact]
        public void Should_return_number_of_votes_for_specific_candidate()
        {
            var urne = new Urne();
            urne.Vote("SpecificCandidate");
            urne.Vote("AnotherCandidate");
            urne.Vote("SpecificCandidate");
            urne.Vote("SpecificCandidate");
            urne.Vote("AnotherCandidate");
            urne.Vote("SpecificCandidate");

            Assert.Equal(4, urne.GetNumberVotesFor("SpecificCandidate"));
            Assert.Equal(2, urne.GetNumberVotesFor("AnotherCandidate"));
        }

        [Fact]
        public void Should_Return_number_of_null_votes()
        {
            List<string> officialCandidates = new List<string> { "SpecificCandidate", "AnotherCandidate" };

            var urne = new Urne();
            urne.Vote("");
            urne.Vote("NullVote");
            urne.Vote(officialCandidates[0]);
            urne.Vote(officialCandidates[1]);
            urne.Vote(officialCandidates[1]);
            urne.Vote("AnotherNullVote");

            Assert.Equal(2, urne.GetNumberNullVotes(officialCandidates));
        }

        [Fact]
        public void Should_Return_number_of_valid_votes()
        {
            List<string> officialCandidates = new List<string> { "SpecificCandidate", "AnotherCandidate" };

            var urne = new Urne();
            urne.Vote("");
            urne.Vote("NullVote");
            urne.Vote(officialCandidates[0]);
            urne.Vote(officialCandidates[1]);
            urne.Vote(officialCandidates[1]);
            urne.Vote("AnotherNullVote");

            Assert.Equal(3, urne.GetNumberValidVotes(officialCandidates));
        }
    }
}
