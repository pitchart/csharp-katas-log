namespace Elections
{
    public class Urne
    {
        private List<string> ListVotes = new List<string>();

        internal void Vote(string candidate) => ListVotes.Add(candidate);

        internal int GetTotalVote() => ListVotes.Count();

        internal int GetNumberBlankVotes() => ListVotes.Count(vote => vote.Equals(string.Empty));

        internal int GetNumberNullVotes(List<string> officialCandidates)
        {
            return ListVotes.Count(vote => !(vote.Equals(string.Empty) || officialCandidates.Contains(vote)));
        }
        internal int GetNumberValidVotes(List<string> officialCandidates) => ListVotes.Count(vote => officialCandidates.Contains(vote));
        internal int GetNumberVotesFor(string candidate) => ListVotes.Count(vote => vote.Equals(candidate));
    }
}
