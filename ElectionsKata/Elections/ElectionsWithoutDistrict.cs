using Elections.Domain;

namespace Elections
{
    public class ElectionsWithoutDistrict : IElections
    {
        private readonly List<string> _officialCandidates = new List<string>();
        private readonly Dictionary<string, List<string>> _list;
        private readonly ResultFormater _formater;
        private readonly Urn _urn = new();

        public ElectionsWithoutDistrict(Dictionary<string, List<string>> list)
        {
            _list = list;

            _formater = new ResultFormater();
        }

        public void AddCandidate(string candidate)
        {
            _officialCandidates.Add(candidate);
        }

        public void VoteFor(string elector, string candidate, string electorDistrict)
        {
            if (!_list[electorDistrict].Contains(elector))
            {
                _urn.VoteFor("123");
            }
            else
            {
                _urn.VoteFor(candidate);
            }
        }

        public Dictionary<string, string> ComputeResults()
        {
            var voteCounting = _urn.CountVotes(_officialCandidates);
            var nbElectors = _list.Sum(kv => kv.Value.Count);
            var percentResult = voteCounting.ToPercentResult(nbElectors);
            return _formater.FormatResults(percentResult);
        }
    }
}
