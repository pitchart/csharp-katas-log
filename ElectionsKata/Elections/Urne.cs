namespace Elections
{
    public class Urne
    {
        private List<string> ListVotes = new List<string>();

        public void Vote(string candidate) => ListVotes.Add(candidate);

        public int GetTotalVote() => ListVotes.Count();

        public int GetNumberBlankVotes() => ListVotes.Count(vote => vote.Equals(string.Empty));

        public int GetNumberNullVotes(List<string> officialCandidates)
        {
            return ListVotes.Count(vote => !(vote.Equals(string.Empty) || officialCandidates.Contains(vote)));
        }
        public int GetNumberValidVotes(List<string> officialCandidates) => ListVotes.Count(vote => officialCandidates.Contains(vote));
        public int GetNumberVotesFor(string candidate) => ListVotes.Count(vote => vote.Equals(candidate));
    }
}
