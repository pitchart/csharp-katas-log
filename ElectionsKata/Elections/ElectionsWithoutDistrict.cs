using System.Linq;

namespace Elections
{
    public class ElectionsWithoutDistrict : Elections
    {
        protected readonly List<string> _urne = new List<string>();

        public ElectionsWithoutDistrict(Dictionary<string, List<string>> list) : base(list)
        {
        }

        public override void VoteFor(string elector, string candidate, string electorDistrict)
        {
            _urne.Add(candidate);
        }

        public override Dictionary<string, string> Results()
        {
            var results = new Dictionary<string, string>();
            var nbVotes = _urne.Count();
            var nullVotes = _urne.Count(vote => IsVoteNull(vote));
            var blankVotes = _urne.Count(vote => vote.Equals(string.Empty));
            var nbValidVotes = _urne.Count(vote => _officialCandidates.Contains(vote));

            
            foreach (var candidate in _officialCandidates)
            {
                var nombreVote = _urne.Count(vote => vote.Equals(candidate));
                float candidateResult = GetPercent(nombreVote, nbValidVotes);
                results[candidate] = FormatResult(candidateResult);
            }

            var blankResult = GetPercent(blankVotes, nbVotes);
            results["Blank"] = FormatResult(blankResult);

            var nullResult = GetPercent(nullVotes, nbVotes);
            results["Null"] = FormatResult(nullResult);

            var nbElectors = _electorsByDistricts.Sum(disctrict => disctrict.Value.Count);
            var abstentionResult = 100 - GetPercent(nbVotes, nbElectors); ;
            results["Abstention"] = FormatResult(abstentionResult);

            return results;
        }

        private bool IsVoteNull(string vote)
        {
            return !(vote.Equals(string.Empty) || _officialCandidates.Contains(vote));
        }
    }
}
