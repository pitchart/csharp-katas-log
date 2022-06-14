using Elections.Interfaces;
using System.Globalization;

namespace Elections
{
    public class ElectionsWithoutDistrict : IElections
    {
        private Dictionary<string, List<string>> _electorsByDistrict;
        private readonly List<string> _officialCandidates = new();

        private readonly List<string> _urne = new();

        public ElectionsWithoutDistrict(Dictionary<string, List<string>> electorsByDistrict)
        {
            _electorsByDistrict = electorsByDistrict;
        }

        public void AddCandidate(string candidate)
        {
            _officialCandidates.Add(candidate);
        }

        public void VoteFor(string elector, string candidate, string electorDistrict)
        {
            _urne.Add(candidate);
        }

        public Dictionary<string, string> Results()
        {
            var nbVotes = _urne.Count;
            var nbValidVotes = _urne.Count(IsValid);

            var results = _officialCandidates.ToDictionary(candidat => candidat, candidat =>
            {
                var percent = ComputePercentage(vote => vote.Equals(candidat), nbValidVotes);
                return FormatResult(percent);
            });

            var blankResult = ComputePercentage(IsBlank, nbVotes);
            results["Blank"] = FormatResult(blankResult);

            var nullResult = ComputePercentage(IsNull, nbVotes);
            results["Null"] = FormatResult(nullResult);

            var nbElectors = _electorsByDistrict.Sum(kv => kv.Value.Count);
            var abstentionResult = 100 - (float)nbVotes * 100 / nbElectors;
            results["Abstention"] = FormatResult(abstentionResult);

            return results;
        }

        private float ComputePercentage(Func<string, bool> filter, int nbVotes)
        {
            return (float)_urne.Count(filter) * 100 / nbVotes;
        }

        private static string FormatResult(float result)
        {
            return string.Format(new CultureInfo("fr-fr"), "{0:0.00}%", result);
        }

        private bool IsValid(string vote)
        {
            return _officialCandidates.Contains(vote);
        }

        private static bool IsBlank(string vote)
        {
            return vote.Equals(string.Empty);
        }

        private bool IsNull(string vote)
        {
            return !vote.Equals(string.Empty) && !_officialCandidates.Contains(vote);
        }
    }
}
