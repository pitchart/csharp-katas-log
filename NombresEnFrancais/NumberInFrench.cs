namespace NombresEnFrancais
{
    public static class NumberInFrench
    {
        public static string GetNumberInFrench(int number)
        {
            var numberMapping = new Dictionary<int, string>
            {
                { 0, "zero"},
                { 1, "un"},
                { 2, "deux"},
                { 3, "trois"},
                { 4, "quatre"},
                { 5, "cinq"},
                { 6, "six"},
                { 7, "sept"},
                { 8, "huit"},
                { 9, "neuf"},
                { 10, "dix"},
                { 11, "onze"},
                { 12, "douze"},
                { 13, "treize"},
                { 14, "quatorze"},
                { 15, "quinze"},
                { 16, "seize"},
                { 20, "vingt"}
            };

            if (!numberMapping.ContainsKey(number))
            {
                return numberMapping[number / 10 * 10] + "-" + numberMapping[number % 10];
            }
            return numberMapping[number];
        }
    }
}
