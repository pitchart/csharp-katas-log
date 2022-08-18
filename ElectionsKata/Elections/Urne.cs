namespace Elections
{
    public class Urne
    {
        private List<string> ListVotes = new List<string>();

        public void Vote(string candidate) => ListVotes.Add(candidate);

        public int GetTotalVote() => ListVotes.Count();

        public int GetNumberBlankVotes() => ListVotes.Count(vote => IsBlank(vote));

        public int GetNumberNullVotes(List<string> officialCandidates) => ListVotes.Count(vote => !(IsBlank(vote) || officialCandidates.Contains(vote)));
        
        public int GetNumberValidVotes(List<string> officialCandidates) => ListVotes.Count(vote => officialCandidates.Contains(vote));

        public int GetNumberVotesFor(string candidate) => ListVotes.Count(vote => vote.Equals(candidate));

        private static bool IsBlank(string vote) => vote.Equals(string.Empty);
    }
}
