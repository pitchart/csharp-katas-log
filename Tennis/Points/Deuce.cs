using System.Text;

namespace Tennis.Points
{

    public class Deuce: IPoint
    {
        public string GetScore(string _ = "")
        {
            return "Deuce";
        }
    }

}
