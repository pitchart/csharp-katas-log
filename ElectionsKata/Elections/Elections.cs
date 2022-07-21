using System.Globalization;

namespace Elections
{
    public abstract class Elections
    {
        protected readonly List<string> _candidates = new List<string>();
        protected readonly Dictionary<string, List<string>> _electorsByDistricts;
        protected readonly List<string> _officialCandidates = new List<string>();

        public Elections(Dictionary<string, List<string>> list)
        {
            _electorsByDistricts = list;
        }

        public virtual void AddCandidate(string candidate)
        {
            _officialCandidates.Add(candidate);
            _candidates.Add(candidate);
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
