using Elections.Domain;
using System.Globalization;

namespace Elections
{
    internal class ElectionsWithoutDistrict
    {
        private readonly List<string> _officialCandidates = new List<string>();
        private readonly Dictionary<string, List<string>> _list;
        private readonly Dictionary<string, int> _urn = new();
        private readonly Urn _newUrn = new();

        public ElectionsWithoutDistrict(Dictionary<string, List<string>> list)
        {
            _list = list;
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

        //TODO => Formatage, division par 0 vote valide, guard constructeur VoteCounting


        internal Dictionary<string, string> ComputeResults()
        {
            var voteCounting = _newUrn.CountVotes(_officialCandidates);

            var formattedResults = new Dictionary<string, string>();
            var cultureInfo = new CultureInfo("fr-fr");

            var nbElectors = _list.Sum(kv => kv.Value.Count);
            var percentResult = voteCounting.ToPercentResult(nbElectors);

            foreach (var percentByCandidate in percentResult.PercentByCandidates)
            {
                formattedResults[percentByCandidate.Key] = string.Format(cultureInfo, "{0:0.00}%", percentByCandidate.Value);
            }

            formattedResults["Blank"] = string.Format(cultureInfo, "{0:0.00}%", percentResult.BlankResult);

            formattedResults["Null"] = string.Format(cultureInfo, "{0:0.00}%", percentResult.NullResult);

            formattedResults["Abstention"] = string.Format(cultureInfo, "{0:0.00}%", percentResult.AbstentionResult);

            return formattedResults;
        }
    }
}
