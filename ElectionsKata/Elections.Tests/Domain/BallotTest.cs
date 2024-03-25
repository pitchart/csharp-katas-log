using System.Collections.Generic;

using FluentAssertions;

using Xunit;

namespace Elections.Tests.Domain;

public class BallotTest
{
    [Fact]
    public void Should_Convert_Empty_String_To_Blank_Vote()
    {
        var candidate = string.Empty;

        var officialCandidates = new List<string>();

        var ballot = Ballot.From(candidate, officialCandidates);

        ballot.Should().BeOfType<BlankBallot>();
    }

    [Fact]
    public void Should_Convert_Official_Candidate_To_Valid_Vote()
    {
        var candidate = "Bob";

        var officialCandidates = new List<string> { "Bob" };

        var ballot = Ballot.From(candidate, officialCandidates);

        ballot.Should().BeOfType<ValidBallot>();
    }

    [Fact]
    public void Should_Convert_Unofficial_Candidate_To_Null_Vote()
    {
        var candidate = "Bob";

        var officialCandidates = new List<string> { "Jerry" };

        var ballot = Ballot.From(candidate, officialCandidates);

        ballot.Should().BeOfType<NullBallot>();
    }
}

//TODO: Use it in Urn.cs
public class Ballot
{
    public static object From(string candidate, List<string> officialCandidates)
    {
        if (string.IsNullOrWhiteSpace(candidate))
        {
            return new BlankBallot();
        }
        else if (officialCandidates.Contains(candidate))
        {
            return new ValidBallot();
        }
        else
        {
            return new NullBallot();
        }
    }
}
