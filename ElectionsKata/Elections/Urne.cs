namespace Elections
{
    public class Urne
    {
        /// <summary>Gets or sets the list.</summary>
        /// <value>The list.</value>
        public List<string> List { get;} = new List<string>();

        internal void Vote(string candidate) => List.Add(candidate);

        internal int GetTotalVote() => List.Count();

        internal int GetNumberBlankVotes() => List.Count(vote => vote.Equals(string.Empty));

        internal int GetNumberNullVotes(List<string> officialCandidates)
        {
            return List.Count(vote => !(vote.Equals(string.Empty) || officialCandidates.Contains(vote)));
        }
        internal int GetNumberValidVotes(List<string> officialCandidates) => List.Count(vote => officialCandidates.Contains(vote));
    }
}
