using Elections.Domain;
using System.Globalization;

namespace Elections
{
    internal class ElectionsWithoutDistrict
    {
        private readonly List<string> _officialCandidates = new List<string>();
        private readonly Dictionary<string, List<string>> _list;
        private readonly Dictionary<string, int> _urn = new();
        private readonly Urn _newUrn = new();

        public ElectionsWithoutDistrict(Dictionary<string, List<string>> list)
        {
            _list = list;
        }

        internal void AddCandidate(string candidate)
        {
            _officialCandidates.Add(candidate);
            _urn.Add(candidate, 0);
        }



        internal void VoteFor(string elector, string candidate, string electorDistrict)
        {
            if (_urn.ContainsKey(candidate))
            {
                _urn[candidate] += 1;
            }
            else
            {
                _urn.Add(candidate, 1);
            }

            _newUrn.VoteFor(candidate);
        }

        internal Dictionary<string, string> ComputeResults()
        {
            var voteCounting = _newUrn.CountVotes();

            var formattedResults = new Dictionary<string, string>();
            var nullVotes = _urn.Where(vote => vote.Key != string.Empty && !_officialCandidates.Contains(vote.Key)).Select(vote => vote.Value).Sum();
            var nbValidVotes = 0;
            var cultureInfo = new CultureInfo("fr-fr");

            foreach (var candidate in _officialCandidates)
            {
                nbValidVotes += _urn[candidate];
            }

            // TODO Linq
            foreach (var vote in _urn)
            {
                if (_officialCandidates.Contains(vote.Key))
                {
                    var candidateResult = (float)vote.Value * 100 / nbValidVotes;
                    formattedResults[vote.Key] = string.Format(cultureInfo, "{0:0.00}%", candidateResult);
                }
            }

            var blankResult = (float)voteCounting.NbBlankVotes * 100 / voteCounting.NbVotes;
            formattedResults["Blank"] = string.Format(cultureInfo, "{0:0.00}%", blankResult);

            var nullResult = (float)nullVotes * 100 / voteCounting.NbVotes;
            formattedResults["Null"] = string.Format(cultureInfo, "{0:0.00}%", nullResult);

            var nbElectors = _list.Sum(kv => kv.Value.Count);
            var abstentionResult = 100 - (float)voteCounting.NbVotes * 100 / nbElectors;
            formattedResults["Abstention"] = string.Format(cultureInfo, "{0:0.00}%", abstentionResult);

            return formattedResults;
        }
    }
}
