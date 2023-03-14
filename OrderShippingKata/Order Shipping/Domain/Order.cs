using LanguageExt;
using Order_Shipping.Domain;
using OrderShipping.UseCase;

namespace OrderShipping.Domain
{
    public class Order
    {
        public int Id { get; set; }
        private OrderStatus _status;
        public OrderStatusEnum StatusEnum
        {
            get => _status.GetOrderStatusEnum(); 
            set
            {
                _status = OrderStatus.Create(value);
            }
        }
        public string Currency { get; }
        public IList<OrderItem> Items { get; }
        public decimal Tax => this.Items.Sum(item => item.Tax.RoundedValue);
        public decimal Total => this.Items.Sum(item => item.TaxedAmount.RoundedValue);

        public Order()
        {
            this.StatusEnum = OrderStatusEnum.Created;
            this.Items = new List<OrderItem>();
            this.Currency = "EUR";
            //this._status = new OrderCreated();
        }

        public void AddProduct(Product product, int quantity)
        {
            this.Items.Add(new OrderItem { Product = product, Quantity = quantity });
        }

        public Either<ApplicationException, Order> Approve()
        {
            try
            {
                _status.Approve(this);
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
                _status.Reject(this);
                return this;
            }
            catch (ApplicationException ex)
            {
                return ex;
            }
        }

        public (Order? Success, ApplicationException? Error) Ship()
        {
            try
            {
                _status.Ship(this);
                return (this, null);
            }
            catch (ApplicationException ex)
            {
                return (this, ex);
            }
        }
    }
}
