namespace CupCake
{
    public abstract class Cake
    {
        protected float Price;
        protected string Name;

        protected Cake(float price, string name)
        {
            Price = price;
            Name = name;
        }

        public string GetName()
        {
            return Name;
        }

        public float GetPrice()
        {
            return Price;
        }

        public string GetFormatedPrice()
        {
            return $"{GetPrice()}$";
        }
    }
}
