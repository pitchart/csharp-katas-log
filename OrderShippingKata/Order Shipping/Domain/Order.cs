using LanguageExt;
using Order_Shipping.Domain;

namespace OrderShipping.Domain
{
    public class Order
    {
        public int Id { get; set; }

        public OrderStatus Status { get; internal set; }

        public string Currency { get; }
        public IList<OrderItem> Items { get; }
        public decimal Tax => Items.Sum(item => item.Tax.RoundedValue);
        public decimal Total => Items.Sum(item => item.TaxedAmount.RoundedValue);

        public Order()
        {
            Items = new List<OrderItem>();
            Currency = "EUR";
            Status = new OrderCreated();
        }

        public void AddProduct(Product product, int quantity)
        {
            Items.Add(new OrderItem { Product = product, Quantity = quantity });
        }

        public Either<ApplicationException, Order> Approve()
        {
            try
            {
                Status.Approve(this);
                return this;
            }
            catch (ApplicationException ex)
            {
                return ex;
            }
        }

        public Either<ApplicationException, Order> Reject()
        {
            try
            {
                Status.Reject(this);
                return this;
            }
            catch (ApplicationException ex)
            {
                return ex;
            }
        }

        public Either<ApplicationException, Order> Ship()
        {
            try
            {
                Status.Ship(this);
                return this;
            }
            catch (ApplicationException ex)
            {
                return ex;
            }
        }
    }
}
