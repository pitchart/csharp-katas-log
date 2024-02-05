using Elections.Domain;
using FluentAssertions;
using Xunit;

namespace Elections.Tests.Domain
{
    public class UrnTest
    {
        [Fact]
        public void Should_Compute_Vote_Number()
        {
            Urn urn = new();
            string candidate = "Julien Vitte";

            urn.VoteFor(candidate);

            var countVotes = urn.CountVotes();

            countVotes.NbVotes.Should().Be(1);
        }

        [Fact]
        public void Should_Compute_Blank_Votes()
        {
            Urn urn = new();
            string candidate = string.Empty;

            urn.VoteFor(candidate);

            var countVotes = urn.CountVotes();

            countVotes.NbBlankVotes.Should().Be(1);
        }
    }
}
