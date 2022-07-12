using Elections.Interfaces;
using System.Collections.Generic;
using System.Globalization;

namespace Elections
{
    public class ElectionsWithDistrict : IElections
    {
        private Dictionary<string, List<string>> _list;
        private readonly List<string> _candidates = new();
        private readonly Dictionary<string, List<int>> _votes;
        private readonly List<string> _officialCandidates = new();

        public ElectionsWithDistrict(Dictionary<string, List<string>> list)
        {
            _list = list;
            _votes = new Dictionary<string, List<int>>
            {
                {"District 1", new List<int>()},
                {"District 2", new List<int>()},
                {"District 3", new List<int>()}
            };
        }

        public void AddCandidate(string candidate)
        {
            _officialCandidates.Add(candidate);
            _candidates.Add(candidate);
            _votes["District 1"].Add(0);
            _votes["District 2"].Add(0);
            _votes["District 3"].Add(0);
        }

        public void VoteFor(string elector, string candidate, string electorDistrict)
        {
            if (_votes.ContainsKey(electorDistrict))
            {
                var districtVotes = _votes[electorDistrict];
                if (_candidates.Contains(candidate))
                {
                    VoteForExistingCandidate(candidate, districtVotes);
                }
                else
                {
                    VoteForUnknownCandidate(candidate, districtVotes);
                }
            }
        }

        private void VoteForUnknownCandidate(string candidate, List<int> districtVotes)
        {
            _candidates.Add(candidate);
            foreach (var (_, votes) in _votes) votes.Add(0);
            districtVotes[_candidates.Count - 1] += 1;
        }

        private void VoteForExistingCandidate(string candidate, List<int> districtVotes)
        {
            var index = _candidates.IndexOf(candidate);
            districtVotes[index] += 1;
        }

        public Dictionary<string, string> Results()
        {
            var results = new Dictionary<string, string>();
            int nbVotes;
            int nullVotes;
            int blankVotes;
            var nbValidVotes = 0;
            var cultureInfo = new CultureInfo("fr-fr");

            (results, nbVotes, nullVotes, blankVotes, nbValidVotes) = ResultWithDistrict(cultureInfo);

            var blankResult = (float)blankVotes * 100 / nbVotes;
            var nullResult = (float)nullVotes * 100 / nbVotes;
            var nbElectors = _list.Sum(kv => kv.Value.Count);
            var abstentionResult = 100 - (float)nbVotes * 100 / nbElectors;

            results["Blank"] = string.Format(cultureInfo, "{0:0.00}%", blankResult);

            results["Null"] = string.Format(cultureInfo, "{0:0.00}%", nullResult);
            
            results["Abstention"] = string.Format(cultureInfo, "{0:0.00}%", abstentionResult);

            return results;
        }

        private (Dictionary<string, string> results, int nbVotes, int nullVotes, int blankVotes, int nbValidVotes) ResultWithDistrict(CultureInfo cultureInfo)
        {
            var results = new Dictionary<string, string>();
            var nbVotes = _votes.Select(v => v.Value.Sum()).Sum();
            var nullVotes = 0;
            var blankVotes = 0;
            var nbValidVotes = 0;

            //nbValidVotes = _officialCandidates.Select(oc => _candidates.IndexOf(oc))
            for (var i = 0; i < _officialCandidates.Count; i++)
            {
                var index = _candidates.IndexOf(_officialCandidates[i]);
                foreach (var entry in _votes)
                {
                    var districtVotes = entry.Value;
                    nbValidVotes += districtVotes[index];
                }
            }

            var officialCandidatesResult = new Dictionary<string, int>();
            for (var i = 0; i < _officialCandidates.Count; i++) officialCandidatesResult[_candidates[i]] = 0;
            foreach (var entry in _votes)
            {
                var districtResult = new List<float>();
                var districtVotes = entry.Value;
                for (var i = 0; i < districtVotes.Count; i++)
                {
                    float candidateResult = 0;
                    if (nbValidVotes != 0)
                        candidateResult = (float)districtVotes[i] * 100 / nbValidVotes;
                    var candidate = _candidates[i];
                    if (_officialCandidates.Contains(candidate))
                    {
                        districtResult.Add(candidateResult);
                    }
                    else
                    {
                        if (_candidates[i] == string.Empty)
                            blankVotes += districtVotes[i];
                        else
                            nullVotes += districtVotes[i];
                    }
                }

                var districtWinnerIndex = 0;
                for (var i = 1; i < districtResult.Count; i++)
                    if (districtResult[districtWinnerIndex] < districtResult[i])
                        districtWinnerIndex = i;
                officialCandidatesResult[_candidates[districtWinnerIndex]] += 1;
            }

            for (var i = 0; i < officialCandidatesResult.Count; i++)
            {
                var ratioCandidate = (float)officialCandidatesResult[_candidates[i]] /
                    officialCandidatesResult.Count * 100;
                results[_candidates[i]] = string.Format(cultureInfo, "{0:0.00}%", ratioCandidate);
            }

            return (results, nbVotes, nullVotes, blankVotes, nbValidVotes);
        }
    }
}
