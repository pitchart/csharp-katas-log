namespace CupCake;

public class Bundle
{
    private readonly IEnumerable<ICakeBase> _cakeBaseList;
    private readonly Bundle _bundle;

    public Bundle(ICakeBase cake, params ICakeBase[] cakeBase)
    {
        _cakeBaseList = cakeBase.ToList().Prepend(cake);
    }

    public Bundle(Bundle bundle, ICakeBase cake) : this(cake)
    {
        _bundle = bundle;
    }

    public string GetName()
    {
        var cakeComposition = _cakeBaseList
            .Select(cake => cake.GetName())
            .GroupBy(name => name)
            .Select(CakeNameWithNumbers());
        return $"📦 composed of {string.Join(" and ", cakeComposition)}";
    }

    private static Func<IGrouping<string, string>, string> CakeNameWithNumbers()
    {
        return groupedCake =>
        {
            if (groupedCake.Count() > 1)
            {
                return $"{groupedCake.Count()} {groupedCake.Key}";
            }

            return groupedCake.Key;
        };
    }

    public string GetFormatedPrice()
    {
        return $"{(_cakeBaseList.Sum(cake => cake.GetPrice()) * 0.9f):N1}$".Replace(',', '.');
    }
}
