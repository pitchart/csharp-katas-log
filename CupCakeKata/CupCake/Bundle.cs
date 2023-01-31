namespace CupCake;

public class Bundle
{
    private readonly IEnumerable<ICakeBase> _cakeBaseList;

    public Bundle(ICakeBase cake, params ICakeBase[] cakeBase)
    {
        _cakeBaseList = cakeBase.ToList().Prepend(cake);
    }

    public string GetName()
    {
        return $"📦 composed of {string.Join(" and ", _cakeBaseList.Select(cake => cake.GetName()))}";
    }

    public string GetFormatedPrice()
    {
        return $"{(_cakeBaseList.Sum(cake => cake.GetPrice()) * 0.9f):N1}$".Replace(',', '.');
    }
}
