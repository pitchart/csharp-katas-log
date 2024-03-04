using Elections.Domain;
using FluentAssertions;
using System.Collections.Generic;
using Xunit;

namespace Elections.Tests.Domain;

public class VoteCoutingTest
{
    [Fact]
    public void Should_return_0_percent_by_candidate_when_no_vote()
    {
        // Arrange
        var nbElectors = 1;
        var votesByCandidates = new Dictionary<string, int> { { "Toto", 0 } };
        var voteCounting = new VoteCounting(0, 0, 0, votesByCandidates);

        // Act
        var result = voteCounting.ToPercentResult(nbElectors);

        // Assert
        result.PercentByCandidates.Should().Contain("Toto", 0);
    }

    [Fact]
    public void Should_return_percent_by_candidate_with_one_candidate()
    {
        // Arrange
        var nbElectors = 1;
        var votesByCandidates = new Dictionary<string, int> { { "Toto", 1 } };
        var voteCounting = new VoteCounting(0, 0, 0, votesByCandidates);

        // Act
        var result = voteCounting.ToPercentResult(nbElectors);

        // Assert
        result.PercentByCandidates.Should().Contain("Toto", 100);
    }

    [Fact]
    public void Should_return_percent_by_candidate_with_many_candidates()
    {
        // Arrange
        var nbElectors = 4;
        var votesByCandidates = new Dictionary<string, int> { { "Toto", 1 }, { "Titi", 3 } };
        var voteCounting = new VoteCounting(0, 0, 0, votesByCandidates);

        // Act
        var result = voteCounting.ToPercentResult(nbElectors);

        // Assert
        result.PercentByCandidates.Should().Contain("Toto", 25)
            .And.Contain("Titi", 75);
    }

    [Fact]
    public void Should_return_percent_result_when_no_vote()
    {
        // Arrange
        var nbElectors = 4;
        var votesByCandidates = new Dictionary<string, int> { { "Toto", 0 }, { "Titi", 0 } };
        var voteCounting = new VoteCounting(0, 0, 0, votesByCandidates);

        // Act
        var result = voteCounting.ToPercentResult(nbElectors);

        // Assert
        result.PercentByCandidates.Should().Contain("Toto", 0)
            .And.Contain("Titi", 0);
        result.BlankResult.Should().Be(0);
        result.NullResult.Should().Be(0);
        result.AbstentionResult.Should().Be(100);
    }
}
