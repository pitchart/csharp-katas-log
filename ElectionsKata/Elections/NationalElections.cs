using System.Linq;

namespace Elections
{
    public class NationalElections : Elections
    {
        protected readonly Urne _urne = new Urne();

        public NationalElections(Dictionary<string, List<string>> list) : base(list)
        {
        }

        public override void VoteFor(string elector, string candidate, string electorDistrict)
        {
            _urne.Vote(candidate);
        }

        public override Dictionary<string, string> Results()
        {
            var results = new Dictionary<string, string>();
            var nbVotes = _urne.GetTotalVote();
            var nullVotes = _urne.GetNumberNullVotes(_officialCandidates);
            var blankVotes = _urne.GetNumberBlankVotes();
            var nbValidVotes = _urne.GetNumberValidVotes(_officialCandidates);


            foreach (var candidate in _officialCandidates)
            {
                var nombreVote = _urne.GetNumberVotesFor(candidate);
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

    }
}
