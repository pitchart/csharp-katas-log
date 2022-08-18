namespace Elections
{
    public class LocalElections : Elections
    {
        protected readonly Dictionary<string, List<int>> _votesWithDistricts;
        public LocalElections(Dictionary<string, List<string>> list) : base(list)
        {
            _votesWithDistricts = new Dictionary<string, List<int>>
            {
                {"District 1", new List<int>()},
                {"District 2", new List<int>()},
                {"District 3", new List<int>()}
            };
        }

        public override void AddCandidate(string candidate)
        {
            base.AddCandidate(candidate);
            _votesWithDistricts["District 1"].Add(0);
            _votesWithDistricts["District 2"].Add(0);
            _votesWithDistricts["District 3"].Add(0);
        }
        public override void VoteFor(string elector, string candidate, string electorDistrict)
        {
            if (_votesWithDistricts.ContainsKey(electorDistrict))
            {
                var districtVotes = _votesWithDistricts[electorDistrict];
                if (_candidates.Contains(candidate))
                {
                    var index = _candidates.IndexOf(candidate);
                    districtVotes[index] = districtVotes[index] + 1;
                }
                else
                {
                    _candidates.Add(candidate);
                    foreach (var (_, votes) in _votesWithDistricts) votes.Add(0);
                    districtVotes[_candidates.Count - 1] = districtVotes[_candidates.Count - 1] + 1;
                }
            }
        }

        public override Dictionary<string, string> Results()
        {
            var results = new Dictionary<string, string>();
            var nbVotes = 0;
            var nullVotes = 0;
            var blankVotes = 0;
            var nbValidVotes = 0;

            foreach (var entry in _votesWithDistricts)
            {
                var districtVotes = entry.Value;
                nbVotes += districtVotes.Select(i => i).Sum();
            }

            for (var i = 0; i < _officialCandidates.Count; i++)
            {
                var index = _candidates.IndexOf(_officialCandidates[i]);
                foreach (var entry in _votesWithDistricts)
                {
                    var districtVotes = entry.Value;
                    nbValidVotes += districtVotes[index];
                }
            }

            var officialCandidatesResult = new Dictionary<string, int>();
            for (var i = 0; i < _officialCandidates.Count; i++) officialCandidatesResult[_candidates[i]] = 0;
            foreach (var entry in _votesWithDistricts)
            {
                var districtResult = new List<float>();
                var districtVotes = entry.Value;
                for (var i = 0; i < districtVotes.Count; i++)
                {
                    float candidateResult = 0;
                    if (nbValidVotes != 0)
                        candidateResult = GetPercent(districtVotes[i], nbValidVotes); ;
                    var candidate = _candidates[i];
                    if (_officialCandidates.Contains(candidate))
                    {
                        districtResult.Add(candidateResult);
                    }
                    else
                    {
                        if (_candidates[i] == string.Empty)
                            blankVotes += districtVotes[i];
                        else
                            nullVotes += districtVotes[i];
                    }
                }

                var districtWinnerIndex = 0;
                for (var i = 1; i < districtResult.Count; i++)
                    if (districtResult[districtWinnerIndex] < districtResult[i])
                        districtWinnerIndex = i;
                officialCandidatesResult[_candidates[districtWinnerIndex]] =
                    officialCandidatesResult[_candidates[districtWinnerIndex]] + 1;
            }

            for (var i = 0; i < officialCandidatesResult.Count; i++)
            {
                var ratioCandidate = GetPercent(officialCandidatesResult[_officialCandidates[i]], officialCandidatesResult.Count);
                results[_candidates[i]] = FormatResult(ratioCandidate);
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
