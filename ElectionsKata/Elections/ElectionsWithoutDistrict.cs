using Elections.Interfaces;

namespace Elections
{

    public class ElectionsWithoutDistrict : Elections, IElections
    {
    private Dictionary<string, List<string>> _electorsByDistrict;

    private readonly List<string> _officialCandidates = new();

    private readonly List<string> _urne = new();

    public ElectionsWithoutDistrict(Dictionary<string, List<string>> electorsByDistrict)
    {
        _electorsByDistrict = electorsByDistrict;
    }

    public override void AddCandidate(string candidate)
    {
        _officialCandidates.Add(candidate);
    }

    public override void VoteFor(string elector, string candidate, string electorDistrict)
    {
        _urne.Add(candidate);
    }

    public override Dictionary<string, string> Results()
    {
        var nbVotes = _urne.Count;
        var nbValidVotes = _urne.Count(IsValid);

        var results = _officialCandidates
            .Map(candidate => (candidate, ComputePercentage(vote => vote.Equals(candidate), nbValidVotes)))
            .ToDictionary(kv => kv.Item1, kv => FormatResult(kv.Item2));

        var blankResult = ComputePercentage(IsBlank, nbVotes);
        results["Blank"] = FormatResult(blankResult);

        var nullResult = ComputePercentage(IsNull, nbVotes);
        results["Null"] = FormatResult(nullResult);

        var nbElectors = _electorsByDistrict.Sum(kv => kv.Value.Count);
        var abstentionResult = 100 - (float)nbVotes * 100 / nbElectors;
        results["Abstention"] = FormatResult(abstentionResult);

        return results;
    }

    private float ComputePercentage(Func<string, bool> filter, int nbVotes)
    {
        return (float)_urne.Count(filter) * 100 / nbVotes;
    }

    private bool IsValid(string vote) => _officialCandidates.Contains(vote);

    private static bool IsBlank(string vote) => vote.Equals(string.Empty);

    private bool IsNull(string vote) => !IsBlank(vote) && !IsValid(vote);
    }

}
