using System.Globalization;

namespace Elections
{
    public abstract class Elections
    {
        protected readonly List<string> _candidates = new List<string>();
        protected readonly Dictionary<string, List<string>> _electorsByDistricts;
        protected readonly List<string> _officialCandidates = new List<string>();
        protected readonly Dictionary<string, List<int>> _votesWithDistricts;
        protected readonly List<int> _votesWithoutDistricts = new List<int>();

        public Elections(Dictionary<string, List<string>> list)
        {
            _electorsByDistricts = list;

            _votesWithDistricts = new Dictionary<string, List<int>>
            {
                {"District 1", new List<int>()},
                {"District 2", new List<int>()},
                {"District 3", new List<int>()}
            };
        }

        public void AddCandidate(string candidate)
        {
            _officialCandidates.Add(candidate);
            _candidates.Add(candidate);
            _votesWithoutDistricts.Add(0);
            _votesWithDistricts["District 1"].Add(0);
            _votesWithDistricts["District 2"].Add(0);
            _votesWithDistricts["District 3"].Add(0);
        }

        public abstract void VoteFor(string elector, string candidate, string electorDistrict);

        public abstract Dictionary<string, string> Results();

        protected static float GetPercent(int votes, int total)
        {
            return (float)votes * 100 / total;
        }

        protected static string FormatResult(float resultToFormat)
        {
            return string.Format(new CultureInfo("fr-fr"), "{0:0.00}%", resultToFormat);
        }
    }
}
