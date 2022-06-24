using Newtonsoft.Json;

namespace Elections.Tests;

[UsesVerify]
public class ElectionsTests
{
    public ElectionsTests()
    {
        VerifierSettings.AddExtraSettings(serializerSettings =>
                serializerSettings.DefaultValueHandling = DefaultValueHandling.Include);
    }
    
    [Fact]
    public Task Should_run_without_districts()
        {
            var list = new Dictionary<string, List<string>>
            {
                ["District 1"] = new()
                    {"Bob", "Anna", "Jess", "July"},
                ["District 2"] = new()
                    {"Jerry", "Simon"},
                ["District 3"] = new()
                    {"Johnny", "Matt", "Carole"}
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
            return Verify(results);
        }

        [Fact]
        public Task Should_run_with_districts()
        {
            var list = new Dictionary<string, List<string>>
            {
                ["District 1"] = new()
                    {"Bob", "Anna", "Jess", "July"},
                ["District 2"] = new()
                    {"Jerry", "Simon"},
                ["District 3"] = new()
                    {"Johnny", "Matt", "Carole"}
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
            return Verify(results);
        }
}
