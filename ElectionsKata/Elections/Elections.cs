using System.Globalization;

namespace Elections
{
    public class Elections
    {
        private readonly List<string> _candidates = new List<string>();
        private readonly Dictionary<string, List<string>> _list;
        private readonly List<string> _officialCandidates = new List<string>();
        private readonly Dictionary<string, List<int>> _votesWithDistricts;
        private readonly List<int> _votesWithoutDistricts = new List<int>();
        private readonly bool _withDistrict;

        public Elections(Dictionary<string, List<string>> list, bool withDistrict)
        {
            _list = list;
            _withDistrict = withDistrict;

            _votesWithDistricts = new Dictionary<string, List<int>>
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
            _votesWithoutDistricts.Add(0);
            _votesWithDistricts["District 1"].Add(0);
            _votesWithDistricts["District 2"].Add(0);
            _votesWithDistricts["District 3"].Add(0);
        }

        public void VoteFor(string elector, string candidate, string electorDistrict)
        {
            if (!_withDistrict)
            {
                if (_candidates.Contains(candidate))
                {
                    var index = _candidates.IndexOf(candidate);
                    _votesWithoutDistricts[index] = _votesWithoutDistricts[index] + 1;
                }
                else
                {
                    _candidates.Add(candidate);
                    _votesWithoutDistricts.Add(1);
                }
            }
            else
            {
                if (_votesWithDistricts.ContainsKey(electorDistrict))
                {
                    var districtVotes = _votesWithDistricts[electorDistrict];
                    if (_candidates.Contains(candidate))
                    {
                        var index = _candidates.IndexOf(candidate);
                        districtVotes[index] = districtVotes[index] + 1;
                    }
                    else
                    {
                        _candidates.Add(candidate);
                        foreach (var (_, votes) in _votesWithDistricts) votes.Add(0);
                        districtVotes[_candidates.Count - 1] = districtVotes[_candidates.Count - 1] + 1;
                    }
                }
            }
        }

        public Dictionary<string, string> Results()
        {
            var results = new Dictionary<string, string>();
            var nbVotes = 0;
            var nullVotes = 0;
            var blankVotes = 0;
            var nbValidVotes = 0;
            var cultureInfo = new CultureInfo("fr-fr");

            if (!_withDistrict)
            {
                nbVotes = _votesWithoutDistricts.Select(i => i).Sum();
                for (var i = 0; i < _officialCandidates.Count; i++)
                {
                    var index = _candidates.IndexOf(_officialCandidates[i]);
                    nbValidVotes += _votesWithoutDistricts[index];
                }

                for (var i = 0; i < _votesWithoutDistricts.Count; i++)
                {
                    var candidateResult = (float) _votesWithoutDistricts[i] * 100 / nbValidVotes;
                    var candidate = _candidates[i];

                    if (_officialCandidates.Contains(candidate))
                    {
                        results[candidate] = string.Format(cultureInfo, "{0:0.00}%", candidateResult);
                    }
                    else
                    {
                        if (_candidates[i] == string.Empty)
                            blankVotes += _votesWithoutDistricts[i];
                        else
                            nullVotes += _votesWithoutDistricts[i];
                    }
                }
            }
            else
            {
                foreach (var entry in _votesWithDistricts)
                {
                    var districtVotes = entry.Value;
                    nbVotes += districtVotes.Select(i => i).Sum();
                }

                for (var i = 0; i < _officialCandidates.Count; i++)
                {
                    var index = _candidates.IndexOf(_officialCandidates[i]);
                    foreach (var entry in _votesWithDistricts)
                    {
                        var districtVotes = entry.Value;
                        nbValidVotes += districtVotes[index];
                    }
                }

                var officialCandidatesResult = new Dictionary<string, int>();
                for (var i = 0; i < _officialCandidates.Count; i++) officialCandidatesResult[_candidates[i]] = 0;
                foreach (var entry in _votesWithDistricts)
                {
                    var districtResult = new List<float>();
                    var districtVotes = entry.Value;
                    for (var i = 0; i < districtVotes.Count; i++)
                    {
                        float candidateResult = 0;
                        if (nbValidVotes != 0)
                            candidateResult = (float) districtVotes[i] * 100 / nbValidVotes;
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
                    officialCandidatesResult[_candidates[districtWinnerIndex]] =
                        officialCandidatesResult[_candidates[districtWinnerIndex]] + 1;
                }

                for (var i = 0; i < officialCandidatesResult.Count; i++)
                {
                    var ratioCandidate = (float) officialCandidatesResult[_candidates[i]] /
                        officialCandidatesResult.Count * 100;
                    results[_candidates[i]] = string.Format(cultureInfo, "{0:0.00}%", ratioCandidate);
                }
            }

            var blankResult = (float) blankVotes * 100 / nbVotes;
            results["Blank"] = string.Format(cultureInfo, "{0:0.00}%", blankResult);

            var nullResult = (float) nullVotes * 100 / nbVotes;
            results["Null"] = string.Format(cultureInfo, "{0:0.00}%", nullResult);

            var nbElectors = _list.Sum(kv => kv.Value.Count);
            var abstentionResult = 100 - (float) nbVotes * 100 / nbElectors;
            results["Abstention"] = string.Format(cultureInfo, "{0:0.00}%", abstentionResult);

            return results;
        }
    }
}
