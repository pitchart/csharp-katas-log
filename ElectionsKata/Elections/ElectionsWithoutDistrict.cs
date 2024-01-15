using System.Globalization;

namespace Elections
{
    internal class ElectionsWithoutDistrict
    {
        //TODO réduire le nombre de listes
        private readonly List<string> _candidates = new List<string>();
        private readonly List<string> _officialCandidates = new List<string>();
        private readonly List<int> _votes = new List<int>();
        private readonly Dictionary<string, List<string>> _list;

        public ElectionsWithoutDistrict(Dictionary<string, List<string>> list)
        {
            _list = list;
        }

        internal void AddCandidate(string candidate)
        {
            _officialCandidates.Add(candidate);
            _candidates.Add(candidate);
            _votes.Add(0);
        }

        internal void VoteFor(string elector, string candidate, string electorDistrict)
        {
            if (_candidates.Contains(candidate))
            {
                var index = _candidates.IndexOf(candidate);
                _votes[index] = _votes[index] + 1;
            }
            else
            {
                _candidates.Add(candidate);
                _votes.Add(1);
            }
        }

        internal Dictionary<string, string> ComputeResults()
        {
            var results = new Dictionary<string, string>();
            var nbVotes = _votes.Sum();
            var nullVotes = 0;
            var blankVotes = 0;
            var nbValidVotes = 0;
            var cultureInfo = new CultureInfo("fr-fr");

            for (var i = 0; i < _officialCandidates.Count; i++)
            {
                var index = _candidates.IndexOf(_officialCandidates[i]);
                nbValidVotes += _votes[index];
            }

            for (var i = 0; i < _votes.Count; i++)
            {
                var candidateResult = (float)_votes[i] * 100 / nbValidVotes;
                var candidate = _candidates[i];

                if (_officialCandidates.Contains(candidate))
                {
                    results[candidate] = string.Format(cultureInfo, "{0:0.00}%", candidateResult);
                }
                else
                {
                    if (_candidates[i] == string.Empty)
                        blankVotes += _votes[i];
                    else
                        nullVotes += _votes[i];
                }
            }

            var blankResult = (float)blankVotes * 100 / nbVotes;
            results["Blank"] = string.Format(cultureInfo, "{0:0.00}%", blankResult);

            var nullResult = (float)nullVotes * 100 / nbVotes;
            results["Null"] = string.Format(cultureInfo, "{0:0.00}%", nullResult);

            var nbElectors = _list.Sum(kv => kv.Value.Count);
            var abstentionResult = 100 - (float)nbVotes * 100 / nbElectors;
            results["Abstention"] = string.Format(cultureInfo, "{0:0.00}%", abstentionResult);

            return results;
        }
    }
}
