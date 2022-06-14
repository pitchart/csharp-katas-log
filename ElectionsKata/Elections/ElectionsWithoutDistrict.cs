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
            var cultureInfo = new CultureInfo("fr-fr");

            var nbVotes = _urne.Count;
            var nbValidVotes = _urne.Count(IsValid);

            var results = _officialCandidates.ToDictionary(candidat => candidat, candidat =>
            {
                var nbVote = _urne.Count(vote => vote.Equals(candidat));
                var percent = nbVote * 100 / nbValidVotes;
                return FormatResult(cultureInfo, percent);
            });

            var blankResult = ComputePercentage(nbVotes, IsBlank);
            results["Blank"] = FormatResult(cultureInfo, blankResult);

            var nullResult = ComputePercentage(nbVotes, IsNull);
            results["Null"] = FormatResult(cultureInfo, nullResult);

            var nbElectors = _electorsByDistrict.Sum(kv => kv.Value.Count);
            var abstentionResult = 100 - (float)nbVotes * 100 / nbElectors;
            results["Abstention"] = string.Format(cultureInfo, "{0:0.00}%", abstentionResult);

            return results;
        }

        private float ComputePercentage(int nbVotes, Func<string, bool> filter)
        {
            return (float)_urne.Count(filter) * 100 / nbVotes;
        }

        private static string FormatResult(CultureInfo cultureInfo, float result)
        {
            return string.Format(cultureInfo, "{0:0.00}%", result);
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
