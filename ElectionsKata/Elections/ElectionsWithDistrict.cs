using Elections.Domain;

using System.Globalization;

namespace Elections
{
    public class ElectionsWithDistrict
    {
        private Dictionary<string, List<string>> _list;
        private readonly List<string> _candidates = new List<string>();
        private readonly List<string> _officialCandidates = new List<string>();
        private readonly Dictionary<string, List<int>> _votesWithDistricts;
        private readonly Dictionary<string, Urn> _Urns;
        private readonly ResultFormater _formater;

        public ElectionsWithDistrict(Dictionary<string, List<string>> list)
        {
            this._list = list;
            _formater = new();
            _votesWithDistricts = new Dictionary<string, List<int>>
                {
                    {"District 1", new List<int>()},
                    {"District 2", new List<int>()},
                    {"District 3", new List<int>()}
                };
            _Urns = new Dictionary<string, Urn>
                {
                    {"District 1", new()},
                    {"District 2", new()},
                    {"District 3", new()}
                };
        }

        public void AddCandidate(string candidate)
        {
            _officialCandidates.Add(candidate);
            _candidates.Add(candidate);
            _votesWithDistricts["District 1"].Add(0);
            _votesWithDistricts["District 2"].Add(0);
            _votesWithDistricts["District 3"].Add(0);
        }

        public void VoteFor(string elector, string candidate, string electorDistrict)
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

            if (_Urns.ContainsKey(electorDistrict))
            {
                _Urns[electorDistrict].VoteFor(candidate);
            }
        }

        public Dictionary<string, string> ComputeResults()
        {
            var cultureInfo = new CultureInfo("fr-fr");
            var results = new Dictionary<string, string>();
            var votesCounting = _Urns.ToDictionary(x => x.Key, y => y.Value.CountVotes(_officialCandidates));

            var nbVotes = votesCounting.Sum(x => x.Value.NbVotes);
            var nbValidVotes = votesCounting.Sum(x => x.Value.NbValidVotes);

            var nbElectors = _list.Sum(kv => kv.Value.Count);

            var officialCandidatesResult = new Dictionary<string, int>();
            for (var i = 0; i < _officialCandidates.Count; i++) officialCandidatesResult[_candidates[i]] = 0;
            foreach (var entry in _votesWithDistricts)
            {
                var districtResult = votesCounting[entry.Key].ToPercentResult(nbElectors).PercentByCandidates.Select(x => x.Value).ToList();
                var districtWinnerIndex = 0;
                for (var i = 1; i < districtResult.Count; i++)
                    if (districtResult[districtWinnerIndex] < districtResult[i])
                        districtWinnerIndex = i;
                officialCandidatesResult[_candidates[districtWinnerIndex]] =
                    officialCandidatesResult[_candidates[districtWinnerIndex]] + 1;
            }
            var nullVotes = votesCounting.Sum(x => x.Value.NbNullVotes);
            var blankVotes = votesCounting.Sum(x => x.Value.NbBlankVotes);
            //var voteCounting = new VoteCounting(nbVotes, blankVotes, nullVotes, officialCandidatesResult);

            for (var i = 0; i < officialCandidatesResult.Count; i++)
            {
                var ratioCandidate = (float)officialCandidatesResult[_candidates[i]] /
                    officialCandidatesResult.Count * 100;
                results[_candidates[i]] = string.Format(cultureInfo, "{0:0.00}%", ratioCandidate);
            }

            var blankResult = (float)blankVotes * 100 / nbVotes;
            results["Blank"] = string.Format(cultureInfo, "{0:0.00}%", blankResult);

            var nullResult = (float)nullVotes * 100 / nbVotes;
            results["Null"] = string.Format(cultureInfo, "{0:0.00}%", nullResult);
            var abstentionResult = 100 - (float)nbVotes * 100 / nbElectors;
            results["Abstention"] = string.Format(cultureInfo, "{0:0.00}%", abstentionResult);

            //var percentResult = voteCounting.ToPercentResult(nbElectors);

            return results;
        }
    }
}
