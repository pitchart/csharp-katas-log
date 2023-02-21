using LanguageExt;
using Order_Shipping.Domain;
using OrderShipping.UseCase;

namespace OrderShipping.Domain
{
    public class Order
    {
        public int Id { get; set; }
        private OrderStatus _status;
        private OrderStatusEnum statusEnum;
        public OrderStatusEnum StatusEnum
        {
            get => statusEnum; 
            set
            {
                statusEnum = value;
                //_status = OrderStatus.Create(value);
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
            this._status = new OrderCreated();
        }

        public void AddProduct(Product product, int quantity)
        {
            this.Items.Add(new OrderItem { Product = product, Quantity = quantity });
        }

        public Either<ApplicationException, Order> Approve()
        {
            try
            {
                this.StatusEnum = OrderStatusEnum.Approved;
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
            if (this.StatusEnum == OrderStatusEnum.Shipped)
            {
                return new ShippedOrdersCannotBeChangedException();
            }

            if (this.StatusEnum == OrderStatusEnum.Approved)
            {
                return new ApprovedOrderCannotBeRejectedException();
            }

            this.StatusEnum = OrderStatusEnum.Rejected;
            return this;
        }

        public (Order? Success, ApplicationException? Error) Ship()
        {
            if (this.StatusEnum == OrderStatusEnum.Created || this.StatusEnum == OrderStatusEnum.Rejected)
            {
                return (null, new OrderCannotBeShippedException());
            }

            if (this.StatusEnum == OrderStatusEnum.Shipped)
            {
                return (null, new OrderCannotBeShippedTwiceException());
            }

            this.StatusEnum = OrderStatusEnum.Shipped;
            return (this, null);
        }
    }
}
