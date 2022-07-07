namespace Elections
{
    public class ElectionsWithoutDistrict : Elections
    {
        public ElectionsWithoutDistrict(Dictionary<string, List<string>> list) : base(list, false)
        {
        }
    }
}
