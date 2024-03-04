namespace Elections
{
    public class ElectionsWithDistrict
    {
        private Dictionary<string, List<string>> _list;

        public ElectionsWithDistrict(Dictionary<string, List<string>> list)
        {
            this._list = list;
        }

        public void AddCandidate(string candidate)
        {

        }

        public void VoteFor(string elector, string candidate, string electorDistrict)
        {

        }

        public Dictionary<string, string> ComputeResults()
        {
            return new Dictionary<string, string>();
        }
    }
}
