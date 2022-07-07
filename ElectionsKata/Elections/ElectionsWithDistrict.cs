namespace Elections
{
    public class ElectionsWithDistrict : Elections
    {
        public ElectionsWithDistrict(Dictionary<string, List<string>> list) : base(list, true)
        {

        }
    }
}
