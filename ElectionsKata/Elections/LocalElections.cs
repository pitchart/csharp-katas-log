namespace Elections
{
    public class LocalElections : Elections
    {
        protected readonly Dictionary<string, List<int>> _votesWithDistricts;
        protected readonly Dictionary<string, Urne> _urnePerDistricts;

        public LocalElections(Dictionary<string, List<string>> list) : base(list)
        {
            _urnePerDistricts = new Dictionary<string, Urne>
            {
                {"District 1", new Urne()},
                {"District 2", new Urne()},
                {"District 3", new Urne()}
            };
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
            if (_urnePerDistricts.ContainsKey(electorDistrict))
                _urnePerDistricts[electorDistrict].Vote(candidate);
        }

        public override Dictionary<string, string> Results()
        {
            foreach (var district in _urnePerDistricts.Keys)
            {
                foreach (var vote in _urnePerDistricts[district].ListVotes)
                {
                    if (_votesWithDistricts.ContainsKey(district))
                    {
                        var districtVotes = _votesWithDistricts[district];
                        if (_candidates.Contains(vote))
                        {
                            var index = _candidates.IndexOf(vote);
                            districtVotes[index] = districtVotes[index] + 1;
                        }
                        else
                        {
                            _candidates.Add(vote);
                            foreach (var (_, votes) in _votesWithDistricts) votes.Add(0);
                            districtVotes[_candidates.Count - 1] = districtVotes[_candidates.Count - 1] + 1;
                        }
                    }
                }

            }


            var results = new Dictionary<string, string>();
            var nullVotes = _urnePerDistricts.Values.Sum(u => u.GetNumberNullVotes(_officialCandidates));
            var blankVotes = _urnePerDistricts.Values.Sum(u => u.GetNumberBlankVotes());
            var nbValidVotes = 0;

            var nbVotes = _urnePerDistricts.Values.Sum(u => u.GetTotalVote());



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
