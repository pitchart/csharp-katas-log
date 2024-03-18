
using Elections.Domain;

namespace Elections;

public class DistrictCounting
{
    public int NbVotes { get; }
    public int NbBlankVotes { get; }
    public int NbNullVotes { get; }
    public int NbDistrict { get; } = 0;
    public int NbValidVotes { get; } = 0;
    public int NbElectors { get; } = 0;
    public Dictionary<string, int> OfficialCandidatesResult { get; } = new Dictionary<string, int>();

    public DistrictCounting(Dictionary<string, Urn> urns, List<string> officialCandidates, int nbElectors)
    {
        var votesCounting = urns.ToDictionary(x => x.Key, y => y.Value.CountVotes(officialCandidates));

        NbVotes = votesCounting.Sum(x => x.Value.NbVotes);
        NbValidVotes = votesCounting.Sum(x => x.Value.NbValidVotes);
        NbElectors = nbElectors;

        var officialCandidatesResult = officialCandidates.ToDictionary(x => x, _ => 0);

        foreach (var key in votesCounting.Keys)
        {
            var districtResult = votesCounting[key].ToPercentResult(nbElectors).PercentByCandidates.Select(x => x.Value).ToList();

            var winner = votesCounting[key].GetWinner();
            officialCandidatesResult[winner] = officialCandidatesResult[winner] + 1;
        }

        NbNullVotes = votesCounting.Sum(x => x.Value.NbNullVotes);
        NbBlankVotes = votesCounting.Sum(x => x.Value.NbBlankVotes);
        OfficialCandidatesResult = officialCandidatesResult;
        NbDistrict = officialCandidatesResult.Sum(_result => _result.Value);
    }

    public PercentResult ToPercentResult()
    {
        var percentByCandidates = OfficialCandidatesResult
            .ToDictionary(_votesByCandidate =>
                _votesByCandidate.Key,
                _votesByCandidate => NbDistrict == 0 ? 0 : (float)_votesByCandidate.Value * 100 / NbDistrict);

        var blankResult = NbVotes > 0 ? (float)NbBlankVotes * 100 / NbVotes : 0;

        var nullResult = NbVotes > 0 ? (float)NbNullVotes * 100 / NbVotes : 0;

        var abstentionResult = 100 - (float)NbVotes * 100 / NbElectors;

        return new PercentResult(percentByCandidates, blankResult, nullResult, abstentionResult);
    }
}
