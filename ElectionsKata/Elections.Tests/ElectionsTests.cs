using System.Collections.Generic;
using System.Threading.Tasks;
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

        var results = elections.Results();

        // Add approval tests here
        return Verify(results);
    }

    [Fact]
    public Task Should_run_without_districts_when_blank_result()
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
        elections.VoteFor("Matt", "---", "District 3");
        elections.VoteFor("Jess", "xxx", "District 1");

        var results = elections.Results();

        // Add approval tests here
        return Verify(results);
    }

    [Fact]
    public Task Should_run_without_districts_when_not_have_null_and_blank_result()
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

        var results = elections.Results();

        // Add approval tests here
        return Verify(results);
    }

    [Fact]
    public Task Should_run_without_districts_when_null_result()
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
        elections.VoteFor("Matt", "", "District 3");
        elections.VoteFor("Jess", "", "District 1");

        var results = elections.Results();

        // Add approval tests here
        return Verify(results);
    }

    [Fact]
    public Task Should_run_with_districts_when_not_have_null_and_blank_result()
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
        elections.VoteFor("July", "Jerry", "District 1");

        var results = elections.Results();

        // Add approval tests here
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

        var results = elections.Results();

        // Add approval tests here
        return Verify(results);
    }

    [Fact]
    public Task Should_run_with_districts_with_different_nomber_of_null_and_blank_vote()
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
        elections.VoteFor("Simon", "nullVote", "District 2");
        elections.VoteFor("Carole", "", "District 3");

        var results = elections.Results();

        // Add approval tests here
        return Verify(results);
    }

    [Fact(Skip = "Feature doesn't exist anymore")]
    public void Should_run_with_districts_and_ignore_elector_vote_in_another_district()
    {
        var list = new Dictionary<string, List<string>>
        {
            ["District 1"] = new List<string> { "Bob", "Anna", "Jess", "July" },
            ["District 2"] = new List<string> { "Jerry", "Simon" },
            ["District 3"] = new List<string> { "Johnny", "Matt", "Carole" }
        };
        var elections = new ElectionsWithDistrict(list);
        elections.AddCandidate("Jerry");

        elections.VoteFor("Bob", "Jerry", "District 2");

        var results = elections.Results();

        Assert.True(results.ContainsKey("Null"));
        Assert.Equal("100,00%", results["Null"]);
    }

    [Fact]
    public Task Michel_should_be_100_when_all_votes_for_Michel()
    {
        var electors = new Dictionary<string, List<string>>
        {
            ["District 1"] = new List<string> { "Jerry", "Simon" },
            ["District 2"] = new List<string> { "Johnny", "Matt" }
        };

        var _elections = new ElectionsWithDistrict(electors);
        _elections.AddCandidate("Michel");

        _elections.VoteFor("Jerry", "Michel", "District 1");
        _elections.VoteFor("Simon", "Michel", "District 1");
        _elections.VoteFor("Johnny", "Michel", "District 2");
        _elections.VoteFor("Matt", "Michel", "District 2");

        var results = _elections.Results();

        return Verify(results);
    }
}
