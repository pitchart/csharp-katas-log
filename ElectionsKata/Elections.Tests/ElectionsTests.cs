using System.Collections.Generic;
using System.Threading.Tasks;

using FluentAssertions;

using VerifyXunit;

using Xunit;

using static VerifyXunit.Verifier;

namespace Elections.Tests;

[UsesVerify]
public class ElectionsTests
{
    [Fact]
    public Task Should_run_without_districts()
    {
        var list = new Dictionary<string, List<string>>
        {
            ["District 1"] = new List<string> { "Bob", "Anna", "Jess", "July" },
            ["District 2"] = new List<string> { "Jerry", "Simon" },
            ["District 3"] = new List<string> { "Johnny", "Matt", "Carole" }
        };

        var elections = new ElectionsWithoutDistrict(list);

        elections.AddCandidate("Michel");
        elections.AddCandidate("Jerry");
        elections.AddCandidate("Johnny");

        elections.VoteFor("Bob", "Jerry", "District 1");
        elections.VoteFor("Jerry", "Jerry", "District 2");
        elections.VoteFor("Anna", "Johnny", "District 1");
        elections.VoteFor("Johnny", "Johnny", "District 3");
        elections.VoteFor("Matt", "Donald", "District 3");
        elections.VoteFor("Jess", "Joe", "District 1");
        elections.VoteFor("Simon", "", "District 2");
        elections.VoteFor("Carole", "", "District 3");

        var results = elections.ComputeResults();

        return Verify(results);
    }

    [Fact]
    public Task Should_run_with_districts()
    {
        var list = new Dictionary<string, List<string>>
        {
            ["District 1"] = new List<string> { "Bob", "Anna", "Jess", "July" },
            ["District 2"] = new List<string> { "Jerry", "Simon" },
            ["District 3"] = new List<string> { "Johnny", "Matt", "Carole" }
        };
        var elections = new ElectionsWithDistrict(list);
        elections.AddCandidate("Michel");
        elections.AddCandidate("Jerry");
        elections.AddCandidate("Johnny");

        elections.VoteFor("Bob", "Jerry", "District 1");
        elections.VoteFor("Jerry", "Jerry", "District 2");
        elections.VoteFor("Anna", "Johnny", "District 1");
        elections.VoteFor("Johnny", "Johnny", "District 3");
        elections.VoteFor("Matt", "Donald", "District 3");
        elections.VoteFor("Jess", "Joe", "District 1");
        elections.VoteFor("July", "Jerry", "District 1");
        elections.VoteFor("Simon", "", "District 2");
        elections.VoteFor("Carole", "", "District 3");

        var results = elections.ComputeResults();

        return Verify(results);
    }

    [Fact]
    public void Should_Count_Null_Vote_For_Elector_In_Another_District()
    {
        var list = new Dictionary<string, List<string>>
        {
            ["District 1"] = new List<string> { "Bob", "Anna", "Jess", "July" },
            ["District 2"] = new List<string> { "Jerrye", "Simon" }
        };

        var elections = new ElectionsWithoutDistrict(list);

        elections.AddCandidate("Michel");
        elections.AddCandidate("Jerry");
        elections.AddCandidate("Johnny");

        elections.VoteFor("Bob", "Jerry", "District 2");
        var results = elections.ComputeResults();

        results["Null"].Should().Be("100,00%");
    }
}
