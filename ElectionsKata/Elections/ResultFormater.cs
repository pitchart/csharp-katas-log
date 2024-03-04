using Elections.Domain;
using System.Globalization;

namespace Elections
{
    public class ResultFormater
    {
        private readonly CultureInfo _cultureInfo = new CultureInfo("fr-fr");

        public Dictionary<string, string> FormatResults(PercentResult percentResult)
        {
            var formattedResults = new Dictionary<string, string>();

            foreach (var percentByCandidate in percentResult.PercentByCandidates)
            {
                formattedResults[percentByCandidate.Key] = FormatResult(percentByCandidate.Value);
            }

            formattedResults["Blank"] = FormatResult(percentResult.BlankResult);

            formattedResults["Null"] = FormatResult(percentResult.NullResult);

            formattedResults["Abstention"] = FormatResult(percentResult.AbstentionResult);

            return formattedResults;
        }

        private string FormatResult(float blankResult)
        {
            return string.Format(_cultureInfo, "{0:0.00}%", blankResult);
        }
    }
}
