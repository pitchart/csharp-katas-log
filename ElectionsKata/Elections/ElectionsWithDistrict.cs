using Elections.Domain;

namespace Elections
{
    public class ElectionsWithDistrict
    {
        private Dictionary<string, List<string>> _list;
        private readonly List<string> _candidates = new();
        private readonly List<string> _officialCandidates = new();
        private readonly Dictionary<string, List<int>> _votesWithDistricts;
        private readonly Dictionary<string, Urn> _Urns;
        private readonly ResultFormater _formater;

        public ElectionsWithDistrict(Dictionary<string, List<string>> list)
        {
            this._list = list;

            _formater = new ResultFormater();
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
            var nbElectors = _list.Sum(kv => kv.Value.Count);
            var districtsCounting = new DistrictCounting(_Urns, _officialCandidates, nbElectors);

            var percentResult = districtsCounting.ToPercentResult();
            return _formater.FormatResults(percentResult);
        }
    }
}
