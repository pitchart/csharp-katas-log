using Elections.Domain;

namespace Elections
{
    public class ElectionsWithDistrict : IElections
    {
        private Dictionary<string, List<string>> _list;
        private readonly List<string> _officialCandidates = new();
        private readonly Dictionary<string, Urn> _urns;
        private readonly ResultFormater _formater;

        public ElectionsWithDistrict(Dictionary<string, List<string>> list)
        {
            _list = list;

            _urns = list.Keys.ToDictionary(key => key, _ => new Urn());

            _formater = new ResultFormater();
        }

        public void AddCandidate(string candidate)
        {
            _officialCandidates.Add(candidate);
        }

        public void VoteFor(string elector, string candidate, string electorDistrict)
        {
            if (_urns.ContainsKey(electorDistrict))
            {
                _urns[electorDistrict].VoteFor(candidate);
            }
        }

        public Dictionary<string, string> ComputeResults()
        {
            var nbElectors = _list.Sum(kv => kv.Value.Count);

            var districtsCounting = new DistrictCounting(_urns, _officialCandidates, nbElectors);

            var percentResult = districtsCounting.ToPercentResult();
            return _formater.FormatResults(percentResult);
        }
    }
}
