namespace CupCake
{
    public class CupCake
    {
        public string GetName()
        {
            return "🧁";
        }

        public float GetUnitPrice()
        {
            return 1;
        }

        public string GetPrice()
        {
            return $"{GetUnitPrice()}$";
        }
    }
}
