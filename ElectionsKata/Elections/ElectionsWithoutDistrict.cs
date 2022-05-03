using Elections.Interfaces;
using System.Collections.Generic;
using System.Globalization;

namespace Elections
{
    public class ElectionsWithoutDistrict : IElections
    {
        private Dictionary<string, List<string>> _list;
        private readonly List<string> _officialCandidates = new List<string>();

        private readonly Dictionary<string, int> _urne = new Dictionary<string, int>();

        public ElectionsWithoutDistrict(Dictionary<string, List<string>> list)
        {
            _list = list;
        }

        public void AddCandidate(string candidate)
        {
            _officialCandidates.Add(candidate);

            _urne.Add(candidate, 0);
        }

        public void VoteFor(string elector, string candidate, string electorDistrict)
        {
            if (_urne.ContainsKey(candidate))
            {
                VoteForExistingCandidate(candidate);
            }
            else
            {
                VoteForUnknownCandidate(candidate);
            }
        }

        private void VoteForUnknownCandidate(string candidate)
        {
            _urne.Add(candidate, 1);
        }

        private void VoteForExistingCandidate(string candidate)
        {
            _urne[candidate] += 1;
        }

        public Dictionary<string, string> Results()
        {
            var results = new Dictionary<string, string>();
            var nbVotes = 0;
            var nullVotes = 0;
            var blankVotes = 0;
            var nbValidVotes = 0;
            var cultureInfo = new CultureInfo("fr-fr");

            (results, nbVotes, nullVotes, blankVotes, nbValidVotes) = ResultWithoutDistrict(cultureInfo);

            var blankResult = (float)blankVotes * 100 / nbVotes;
            results["Blank"] = string.Format(cultureInfo, "{0:0.00}%", blankResult);

            var nullResult = (float)nullVotes * 100 / nbVotes;
            results["Null"] = string.Format(cultureInfo, "{0:0.00}%", nullResult);

            var nbElectors = _list.Sum(kv => kv.Value.Count);
            var abstentionResult = 100 - (float)nbVotes * 100 / nbElectors;
            results["Abstention"] = string.Format(cultureInfo, "{0:0.00}%", abstentionResult);

            return results;
        }

        private (Dictionary<string, string> results, int nbVotes, int nullVotes, int blankVotes, int nbValidVotes) ResultWithoutDistrict(CultureInfo cultureInfo)
        {
            var results = new Dictionary<string, string>();
            var nbVotes = _urne.Values.Sum();
            var nullVotes = 0;
            var blankVotes = 0;
            var nbValidVotes = 0;


            foreach (var candidateName in _officialCandidates)
            {
                nbValidVotes += _urne[candidateName];
            }

            foreach (var candidateVotes in _urne)
            {
                var candidateResult = candidateVotes.Value * 100 / nbValidVotes;
                if (_officialCandidates.Contains(candidateVotes.Key))
                {
                    results[candidateVotes.Key] = string.Format(cultureInfo, "{0:0.00}%", candidateResult);
                }
                else
                {
                    if (candidateVotes.Key == string.Empty)
                        blankVotes += candidateVotes.Value;
                    else
                        nullVotes += candidateVotes.Value;
                }
            }

            return (results, nbVotes, nullVotes, blankVotes, nbValidVotes);
        }
    }
}
