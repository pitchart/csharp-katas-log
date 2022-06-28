using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Elections.Tests
{
    public class ElectionsWithoutDistrictTests
    {
        private readonly ElectionsWithoutDistrict _elections;

        public ElectionsWithoutDistrictTests()
        {
            var electors = new Dictionary<string, List<string>>
            {
                ["District 1"] = new List<string> { "Jerry", "Simon", "Matt" },
            };

            _elections = new ElectionsWithoutDistrict(electors);
            _elections.AddCandidate("Michel");
        }

        /**
         * abstention valeurs limite (0, 100)
         * bulletin blanc
         * bulletin null
         */
        [Fact]
        public void Abstention_should_be_zero_when_everyone_vote()
        {
            _elections.VoteFor("Jerry", "Michel", "District 1");
            _elections.VoteFor("Simon", "Michel", "District 1");
            _elections.VoteFor("Matt", "Michel", "District 1");

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
        public void Abstention_should_be_33_when_one_third_of_electoral_list_does_not_vote()
        {
            _elections.VoteFor("Jerry", "Michel", "District 1");
            _elections.VoteFor("Simon", "Michel", "District 1");

            var results = _elections.Results();

            Assert.Equal("33,33%", results["Abstention"]);
        }

        [Fact]
        public void Blank_should_be_50_when_one_of_the_two_votes_is_empty_string()
        {
            _elections.VoteFor("Jerry", "Michel", "District 1");
            _elections.VoteFor("Simon", "", "District 1");

            var results = _elections.Results();

            Assert.Equal("50,00%", results["Blank"]);
        }

        [Fact]
        public void Blank_should_be_0_when_the_two_votes_are_not_an_empty_string()
        {
            _elections.VoteFor("Jerry", "Michel", "District 1");
            _elections.VoteFor("Simon", "Michel", "District 1");

            var results = _elections.Results();

            Assert.Equal("0,00%", results["Blank"]);
        }

    }
}
