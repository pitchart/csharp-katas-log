using System.Collections.Generic;
using Xunit;

namespace Elections.Tests;

public class ElectionsTests
{
    [Fact]
    public void Should_run_without_districts()
        {
            var list = new Dictionary<string, List<string>>
            {
                ["District 1"] = new List<string> {"Bob", "Anna", "Jess", "July"},
                ["District 2"] = new List<string> {"Jerry", "Simon"},
                ["District 3"] = new List<string> {"Johnny", "Matt", "Carole"}
            };

            var elections = new Elections(list, false);
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

        }

        [Fact]
        public void Should_run_with_districts()
        {
            var list = new Dictionary<string, List<string>>
            {
                ["District 1"] = new List<string> {"Bob", "Anna", "Jess", "July"},
                ["District 2"] = new List<string> {"Jerry", "Simon"},
                ["District 3"] = new List<string> {"Johnny", "Matt", "Carole"}
            };
            var elections = new Elections(list, true);
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
        }
}
