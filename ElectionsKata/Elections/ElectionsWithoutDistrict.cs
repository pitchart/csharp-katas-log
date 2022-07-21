namespace Elections
{
    public class ElectionsWithoutDistrict : Elections
    {
        protected readonly List<int> _votesWithoutDistricts = new List<int>();
        public ElectionsWithoutDistrict(Dictionary<string, List<string>> list) : base(list)
        {
        }
        public override void AddCandidate(string candidate)
        {
            base.AddCandidate(candidate);
            _votesWithoutDistricts.Add(0);
        }
        public override void VoteFor(string elector, string candidate, string electorDistrict)
        {
            if (_candidates.Contains(candidate))
            {
                var index = _candidates.IndexOf(candidate);
                _votesWithoutDistricts[index] = _votesWithoutDistricts[index] + 1;
            }
            else
            {
                _candidates.Add(candidate);
                _votesWithoutDistricts.Add(1);
            }
        }

        public override Dictionary<string, string> Results()
        {
            var results = new Dictionary<string, string>();
            var nbVotes = 0;
            var nullVotes = 0;
            var blankVotes = 0;
            var nbValidVotes = 0;

            nbVotes = _votesWithoutDistricts.Select(i => i).Sum();
            for (var i = 0; i < _officialCandidates.Count; i++)
            {
                var index = _candidates.IndexOf(_officialCandidates[i]);
                nbValidVotes += _votesWithoutDistricts[index];
            }

            for (var i = 0; i < _votesWithoutDistricts.Count; i++)
            {
                float candidateResult = GetPercent(_votesWithoutDistricts[i], nbValidVotes);
                var candidate = _candidates[i];

                if (_officialCandidates.Contains(candidate))
                {
                    results[candidate] = FormatResult(candidateResult);
                }
                else
                {
                    if (_candidates[i] == string.Empty)
                        blankVotes += _votesWithoutDistricts[i];
                    else
                        nullVotes += _votesWithoutDistricts[i];
                }
            }

            var blankResult = GetPercent(blankVotes, nbVotes);
            results["Blank"] = FormatResult(blankResult);

            var nullResult = GetPercent(nullVotes, nbVotes);
            results["Null"] = FormatResult(nullResult);

            var nbElectors = _electorsByDistricts.Sum(disctrict => disctrict.Value.Count);
            var abstentionResult = 100 - GetPercent(nbVotes, nbElectors); ;
            results["Abstention"] = FormatResult(abstentionResult);

            return results;
        }
    }
}
