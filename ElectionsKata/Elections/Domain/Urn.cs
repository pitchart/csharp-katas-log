namespace Elections.Domain
{
    public class Urn
    {
        private readonly Dictionary<string, int> _urn = new();

        public void VoteFor(string candidate)
        {
            if (_urn.ContainsKey(candidate))
            {
                _urn[candidate] += 1;
            }
            else
            {
                _urn.Add(candidate, 1);
            }
        }

        public VoteCounting CountVotes(List<string> _officialCandidates)
        {
            var voteCounting = new VoteCounting(_urn.Values.Sum(),
                _urn.GetValueOrDefault(string.Empty),
                _urn.Where(vote => vote.Key != string.Empty && !_officialCandidates.Contains(vote.Key)).Select(vote => vote.Value).Sum(),
                _officialCandidates.ToDictionary(_candidate => _candidate, _candidate => _urn.GetValueOrDefault(_candidate)));

            return voteCounting;
        }
    }
}
