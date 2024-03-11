namespace Elections
{
    public class Elections
    {
        private readonly bool _withDistrict;
        private readonly ElectionsWithoutDistrict _electionsWithoutDistrict;
        private readonly ElectionsWithDistrict _electionsWithDistrict;

        public Elections(Dictionary<string, List<string>> list, bool withDistrict)
        {
            _withDistrict = withDistrict;
            _electionsWithoutDistrict = new(list);
            _electionsWithDistrict = new(list);
        }

        public void AddCandidate(string candidate)
        {
            if (!_withDistrict)
            {
                _electionsWithoutDistrict.AddCandidate(candidate);
            }
            else
            {
                _electionsWithDistrict.AddCandidate(candidate);
            }
        }

        public void VoteFor(string elector, string candidate, string electorDistrict)
        {
            if (!_withDistrict)
            {
                _electionsWithoutDistrict.VoteFor(elector, candidate, electorDistrict);
            }
            else
            {
                _electionsWithDistrict.VoteFor(elector, candidate, electorDistrict);
            }
        }

        public Dictionary<string, string> Results()
        {
            if (!_withDistrict)
            {
                return _electionsWithoutDistrict.ComputeResults();
            }
            else
            {
                return _electionsWithDistrict.ComputeResults();
            }
        }
    }
}
