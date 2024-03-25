
namespace Elections
{
    public interface IElections
    {
        void AddCandidate(string candidate);
        Dictionary<string, string> ComputeResults();
        void VoteFor(string elector, string candidate, string electorDistrict);
    }
}