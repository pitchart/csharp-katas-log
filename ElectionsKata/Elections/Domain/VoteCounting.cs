namespace Elections.Domain
{
    public record VoteCounting
    {
        public VoteCounting(int nbVotes, int nbBlankVotes, int nbNullVotes, Dictionary<string, int> nbVoteByCandidate)
        {
            NbVotes = nbVotes;
            NbBlankVotes = nbBlankVotes;
            NbNullVotes = nbNullVotes;
            NbVoteByCandidate = nbVoteByCandidate;
            NbValidVotes = nbVoteByCandidate.Sum(_candidate => _candidate.Value);
        }

        public int NbVotes { get; }
        public int NbBlankVotes { get; }
        public int NbNullVotes { get; }
        public int NbValidVotes { get; } = 0;
        public Dictionary<string, int> NbVoteByCandidate { get; } = new Dictionary<string, int>();

        // ToDo mapping + tests

        internal static PercentResult ToPercentResult(int nbElectors)
        {
            return new PercentResult();
        }
    }
}
