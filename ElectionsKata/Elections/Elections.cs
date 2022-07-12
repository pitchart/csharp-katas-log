using System.Globalization;

namespace Elections;

public abstract class Elections
{
    public abstract void AddCandidate(string candidate);

    public abstract void VoteFor(string elector, string candidate, string electorDistrict);


    public abstract Dictionary<string, string> Results();

    public static string FormatResult(float result)
    {
        return string.Format(new CultureInfo("fr-fr"), "{0:0.00}%", result);
    }
}
