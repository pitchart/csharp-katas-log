using Elections.Interfaces;
using System.Collections.Generic;
using System.Globalization;

namespace Elections
{
    public class ElectionsWithoutDistrict : IElections
    {
        private Dictionary<string, List<string>> _list;
        private readonly List<string> _officialCandidates = new List<string>();

        private readonly Dictionary<string, int> voteByCandidate = new Dictionary<string, int>();
        private readonly List<string> _urne = new List<string>();


        public ElectionsWithoutDistrict(Dictionary<string, List<string>> list)
        {
            _list = list;
        }

        public void AddCandidate(string candidate)
        {
            _officialCandidates.Add(candidate);

            voteByCandidate.Add(candidate, 0);
        }

        public void VoteFor(string elector, string candidate, string electorDistrict)
        {
            _urne.Add(candidate);
        }

        private void VoteForExistingCandidate(string candidate)
        {
            voteByCandidate[candidate] += 1;
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
            var nbVotes = _urne.Count;
            var nullVotes = _urne.Count(vote => !vote.Equals(string.Empty) && !_officialCandidates.Contains(vote));
            var blankVotes = _urne.Count(vote => vote.Equals(string.Empty));
            var nbValidVotes = _urne.Count(vote => _officialCandidates.Contains(vote));

            /*
             * on prend tout les bulletins valide
             * on groupe par candidat
             * on les comptes
             */
            foreach (var vote in _urne)
            {
                if (voteByCandidate.ContainsKey(vote))
                {
                    VoteForExistingCandidate(vote);
                }
            }

            /*
             * on calcule le pourcentage de vote
             * on formate le pourcentage
             */
            foreach (var candidateVotes in voteByCandidate)
            {
                int nbVote = candidateVotes.Value;
                var precent = nbVote * 100 / nbValidVotes;
                string candidateName = candidateVotes.Key;
                results[candidateName] = string.Format(cultureInfo, "{0:0.00}%", precent);
            }

            return (results, nbVotes, nullVotes, blankVotes, nbValidVotes);
        }
    }
}
