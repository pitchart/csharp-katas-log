using Elections.Domain;

namespace Elections
{
    internal class ElectionsWithoutDistrict
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

        internal void AddCandidate(string candidate)
        {
            _officialCandidates.Add(candidate);
        }

        internal void VoteFor(string elector, string candidate, string electorDistrict)
        {
            _urn.VoteFor(candidate);
        }

        internal Dictionary<string, string> ComputeResults()
        {
            var voteCounting = _urn.CountVotes(_officialCandidates);
            var nbElectors = _list.Sum(kv => kv.Value.Count);
            var percentResult = voteCounting.ToPercentResult(nbElectors);
            return _formater.FormatResults(percentResult);
        }
    }
}
