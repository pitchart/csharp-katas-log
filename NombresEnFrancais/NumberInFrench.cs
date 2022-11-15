namespace NombresEnFrancais
{
    public static class NumberInFrench
    {
        public static string GetNumberInFrench(int number)
        {
            switch (number)
            {
                case 1:
                    return "un";
                case 2:
                    return "deux";
                case 3:
                    return "trois";
                case 4:
                    return "quatre";
                case 5:
                    return "cinq";
                case 6:
                    return "six";
                case 7:
                    return "sept";
                case 8:
                    return "huit";
                case 9:
                    return "neuf";
            }
            return "zero";
        }
    }
}
