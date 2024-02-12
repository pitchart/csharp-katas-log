using Elections.Domain;

using FluentAssertions;

using System.Collections.Generic;

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

            var countVotes = urn.CountVotes(new List<string>());

            countVotes.NbVotes.Should().Be(1);
        }

        [Fact]
        public void Should_Compute_Blank_Votes()
        {
            Urn urn = new();
            string candidate = string.Empty;

            urn.VoteFor(candidate);

            var countVotes = urn.CountVotes(new List<string>());

            countVotes.NbBlankVotes.Should().Be(1);
        }

        [Fact]
        public void Should_compute_null_votes()
        {
            Urn urn = new();
            string candidate = "Julien Vitte";
            string officialCandidate = "Official Candidat";

            urn.VoteFor(candidate);
            urn.VoteFor(officialCandidate);

            var countVotes = urn.CountVotes(new List<string> { officialCandidate });

            countVotes.NbNullVotes.Should().Be(1);
        }

        [Fact]
        public void Should_compute_valid_votes()
        {
            Urn urn = new();
            string candidate = "Julien Vitte";
            string officialCandidate = "Official Candidat";

            urn.VoteFor(candidate);
            urn.VoteFor(officialCandidate);

            var countVotes = urn.CountVotes(new List<string> { officialCandidate });

            countVotes.NbValidVotes.Should().Be(1);
        }

        [Fact]
        public void Should_compute_vote_by_candidate()
        {
            Urn urn = new();
            string officialCandidate1 = "Julien Vitte";
            string officialCandidate2 = "Official Candidat";

            urn.VoteFor(officialCandidate2);
            urn.VoteFor(officialCandidate2);
            var countVotes = urn.CountVotes(new List<string> { officialCandidate1, officialCandidate2 });

            countVotes.NbVoteByCandidate[officialCandidate1].Should().Be(0);
            countVotes.NbVoteByCandidate[officialCandidate2].Should().Be(2);
        }
    }
}
