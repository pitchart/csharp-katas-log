namespace Elections.Domain;

public record PercentResult(
    Dictionary<string, float> PercentByCandidates,
    float BlankResult,
    float NullResult,
    float AbstentionResult)
{ }
