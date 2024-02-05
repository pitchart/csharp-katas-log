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

        public VoteCounting CountVotes()
        {
            var voteCounting = new VoteCounting();
            voteCounting.NbVotes = _urn.Values.Sum();
            voteCounting.NbBlankVotes = _urn.ContainsKey(string.Empty) ? _urn[string.Empty] : 0;
            return voteCounting;
        }
    }
}
