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
            var results = new Dictionary<string, string>();
            var nbVotes = 0;
            var nullVotes = 0;
            var blankVotes = 0;
            var nbValidVotes = 0;
            var cultureInfo = new CultureInfo("fr-fr");

            (results, nbVotes, nullVotes, blankVotes, nbValidVotes) = ResultWithoutDistrict(cultureInfo);

            var blankResult = (float)blankVotes * 100 / nbVotes;
            results["Blank"] = string.Format(cultureInfo, "{0:0.00}%", blankResult);

            var nullResult = (float)nullVotes * 100 / nbVotes;
            results["Null"] = string.Format(cultureInfo, "{0:0.00}%", nullResult);

            var nbElectors = _electorsByDistrict.Sum(kv => kv.Value.Count);
            var abstentionResult = 100 - (float)nbVotes * 100 / nbElectors;
            results["Abstention"] = string.Format(cultureInfo, "{0:0.00}%", abstentionResult);

            return results;
        }

        private (Dictionary<string, string> results, int nbVotes, int nullVotes, int blankVotes, int nbValidVotes) ResultWithoutDistrict(CultureInfo cultureInfo)
        {
            var nbVotes = _urne.Count;
            var nullVotes = _urne.Count(vote => !vote.Equals(string.Empty) && !_officialCandidates.Contains(vote));
            var blankVotes = _urne.Count(vote => vote.Equals(string.Empty));
            var nbValidVotes = _urne.Count(vote => _officialCandidates.Contains(vote));

            var results = _officialCandidates.ToDictionary(candidat => candidat, candidat =>
            {
                var nbVote = _urne.Count(vote => vote.Equals(candidat));
                var percent = nbVote * 100 / nbValidVotes;
                return string.Format(cultureInfo, "{0:0.00}%", percent);
            });

            return (results, nbVotes, nullVotes, blankVotes, nbValidVotes);
        }
    }
}
