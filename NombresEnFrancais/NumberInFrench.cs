namespace NombresEnFrancais
{
    public static class NumberInFrench
    {
        public static string GetNumberInFrench(int number)
        {
            var numberMapping = new Dictionary<int, string>
            {
                { 0,  "zero"},
                { 1,  "un"},
                { 2,  "deux"},
                { 3,  "trois"},
                { 4,  "quatre"},
                { 5,  "cinq"},
                { 6,  "six"},
                { 7,  "sept"},
                { 8,  "huit"},
                { 9,  "neuf"},
            };
            return numberMapping[number];
        }
    }
}
