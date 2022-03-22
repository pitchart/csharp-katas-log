using Elections.Interfaces;
using System.Collections.Generic;
using System.Globalization;

namespace Elections
{
    public class ElectionsWithoutDistrict : IElections
    {
        private Dictionary<string, List<string>> _list;
        private readonly List<string> _candidates = new List<string>();
        private readonly List<int> _votes = new List<int>();
        private readonly List<string> _officialCandidates = new List<string>();

        public ElectionsWithoutDistrict(Dictionary<string, List<string>> list)
        {
            _list = list;
        }

        public void AddCandidate(string candidate)
        {
            _officialCandidates.Add(candidate);
            _candidates.Add(candidate);
            _votes.Add(0);
        }

        public void VoteFor(string elector, string candidate, string electorDistrict)
        {
            if (_candidates.Contains(candidate))
            {
                VoteForExistingCandidate(candidate);
            }
            else
            {
                VoteForUnknownCandidate(candidate);
            }
        }

        private void VoteForUnknownCandidate(string candidate)
        {
            _candidates.Add(candidate);
            _votes.Add(1);
        }

        private void VoteForExistingCandidate(string candidate)
        {
            var index = _candidates.IndexOf(candidate);
            _votes[index] = _votes[index] + 1;
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

            var nbElectors = _list.Sum(kv => kv.Value.Count);
            var abstentionResult = 100 - (float)nbVotes * 100 / nbElectors;
            results["Abstention"] = string.Format(cultureInfo, "{0:0.00}%", abstentionResult);

            return results;
        }

        private (Dictionary<string, string> results, int nbVotes, int nullVotes, int blankVotes, int nbValidVotes) ResultWithoutDistrict(CultureInfo cultureInfo)
        {
            var results = new Dictionary<string, string>();
            var nbVotes = 0;
            var nullVotes = 0;
            var blankVotes = 0;
            var nbValidVotes = 0;

            nbVotes = _votes.Select(i => i).Sum();
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
            return (results, nbVotes, nullVotes, blankVotes, nbValidVotes);
        }
    }
}
