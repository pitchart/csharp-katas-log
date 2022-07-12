using System.Collections.Generic;
using Xunit;

namespace Elections.Tests
{
    public class ElectionsWithDistrictTests
    {
        private readonly ElectionsWithDistrict _elections;

        public ElectionsWithDistrictTests()
        {
            var electors = new Dictionary<string, List<string>>
            {
                ["District 1"] = new List<string> { "Jerry", "Simon" },
                ["District 2"] = new List<string> { "Johnny", "Matt" }
            };

            _elections = new ElectionsWithDistrict(electors);
            _elections.AddCandidate("Michel");
        }

        [Fact]
        public void Abstention_should_be_zero_when_everyone_vote()
        {
            _elections.VoteFor("Jerry", "Michel", "District 1");
            _elections.VoteFor("Simon", "Michel", "District 1");
            _elections.VoteFor("Johnny", "Michel", "District 2");
            _elections.VoteFor("Matt", "Michel", "District 2");

            var results = _elections.Results();

            Assert.Equal("0,00%", results["Abstention"]);
        }

        [Fact]
        public void Abstention_should_be_100_when_no_one_vote()
        {
            var results = _elections.Results();

            Assert.Equal("100,00%", results["Abstention"]);
        }

        [Fact]
        public void Abstention_should_be_50_when_one_third_of_electoral_list_does_not_vote()
        {
            _elections.VoteFor("Jerry", "Michel", "District 1");
            _elections.VoteFor("Simon", "Michel", "District 1");

            var results = _elections.Results();

            Assert.Equal("50,00%", results["Abstention"]);
        }

        [Fact]
        public void Blank_should_be_50_when_two_of_the_four_votes_is_empty_string()
        {
            _elections.VoteFor("Jerry", "Michel", "District 1");
            _elections.VoteFor("Simon", "", "District 1");
            _elections.VoteFor("Johnny", "Michel", "District 2");
            _elections.VoteFor("Matt", "", "District 2");

            var results = _elections.Results();

            Assert.Equal("50,00%", results["Blank"]);
        }

        [Fact]
        public void Blank_should_be_0_when_all_the_votes_are_not_an_empty_string()
        {
            _elections.VoteFor("Jerry", "Michel", "District 1");
            _elections.VoteFor("Simon", "Michel", "District 1");
            _elections.VoteFor("Johnny", "Michel", "District 2");
            _elections.VoteFor("Matt", "Michel", "District 2");

            var results = _elections.Results();

            Assert.Equal("0,00%", results["Blank"]);
        }

        [Fact]
        public void Null_should_be_0_when_all_votes_are_not_null()
        {
            _elections.VoteFor("Jerry", "Michel", "District 1");
            _elections.VoteFor("Simon", "Michel", "District 1");
            _elections.VoteFor("Johnny", "Michel", "District 2");
            _elections.VoteFor("Matt", "Michel", "District 2");

            var results = _elections.Results();

            Assert.Equal("0,00%", results["Null"]);
        }

        [Fact]
        public void Null_should_be_50_when_two_of_the_four_votes_is_not_for_an_official_canditate()
        {
            _elections.VoteFor("Jerry", "UnofficialCandidate", "District 1");
            _elections.VoteFor("Simon", "Michel", "District 1");
            _elections.VoteFor("Johnny", "Michel", "District 2");
            _elections.VoteFor("Matt", "UnofficialCandidate", "District 2");

            var results = _elections.Results();

            Assert.Equal("50,00%", results["Null"]);
        }

        [Fact]
        public void Null_should_be_100_when_all_votes_is_not_for_an_official_canditate()
        {
            _elections.VoteFor("Jerry", "UnofficialCandidate1", "District 1");
            _elections.VoteFor("Simon", "UnofficialCandidate2", "District 1");
            _elections.VoteFor("Johnny", "UnofficialCandidate3", "District 2");
            _elections.VoteFor("Matt", "UnofficialCandidate4", "District 2");

            var results = _elections.Results();

            Assert.Equal("100,00%", results["Null"]);
        }
    }
}
