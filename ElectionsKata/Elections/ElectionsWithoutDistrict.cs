using Elections.Domain;

namespace Elections
{
    internal class ElectionsWithoutDistrict
    {
        private readonly List<string> _officialCandidates = new List<string>();
        private readonly Dictionary<string, List<string>> _list;
        private readonly ResultFormater _formater;
        private readonly Dictionary<string, int> _urn = new();
        private readonly Urn _newUrn = new();

        public ElectionsWithoutDistrict(Dictionary<string, List<string>> list)
        {
            _list = list;
            _formater = new ResultFormater();
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

        //TODO => guard constructeur VoteCounting


        internal Dictionary<string, string> ComputeResults()
        {
            var voteCounting = _newUrn.CountVotes(_officialCandidates);
            var nbElectors = _list.Sum(kv => kv.Value.Count);
            var percentResult = voteCounting.ToPercentResult(nbElectors);
            return _formater.FormatResults(percentResult);
        }
    }
}
