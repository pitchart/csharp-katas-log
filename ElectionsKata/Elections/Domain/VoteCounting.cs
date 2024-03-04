namespace Elections.Domain
{
    public record VoteCounting
    {
        public int NbVotes { get; }
        public int NbBlankVotes { get; }
        public int NbNullVotes { get; }
        public int NbValidVotes { get; } = 0;
        public Dictionary<string, int> NbVoteByCandidate { get; } = new Dictionary<string, int>();

        public VoteCounting(int nbVotes, int nbBlankVotes, int nbNullVotes, Dictionary<string, int> nbVoteByCandidate)
        {
            NbVotes = nbVotes;
            NbBlankVotes = nbBlankVotes;
            NbNullVotes = nbNullVotes;
            NbVoteByCandidate = nbVoteByCandidate;
            NbValidVotes = nbVoteByCandidate.Sum(_candidate => _candidate.Value);
        }

        public PercentResult ToPercentResult(int nbElectors)
        {
            var percentByCandidates = NbVoteByCandidate
                .ToDictionary(_votesByCandidate =>
                    _votesByCandidate.Key,
                    _votesByCandidate => NbValidVotes == 0 ? 0 : (float)_votesByCandidate.Value * 100 / NbValidVotes);

            var blankResult = NbVotes > 0 ? (float)NbBlankVotes * 100 / NbVotes : 0;

            var nullResult = NbVotes > 0 ? (float)NbNullVotes * 100 / NbVotes : 0;

            var abstentionResult = 100 - (float)NbVotes * 100 / nbElectors;

            return new PercentResult(percentByCandidates, blankResult, nullResult, abstentionResult);
        }
    }
}
