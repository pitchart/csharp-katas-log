using LanguageExt;
using OrderShipping.UseCase;

namespace OrderShipping.Domain
{
    public class Order
    {
        public int Id { get; set; }
        public OrderStatus Status { get; set; }
        public string Currency { get; }
        public IList<OrderItem> Items { get; }
        public decimal Tax => this.Items.Sum(item => item.Tax.RoundedValue);
        public decimal Total => this.Items.Sum(item => item.TaxedAmount.RoundedValue);

        public Order()
        {
            this.Status = OrderStatus.Created;
            this.Items = new List<OrderItem>();
            this.Currency = "EUR";
        }

        public void AddProduct(Product product, int quantity)
        {
            this.Items.Add(new OrderItem { Product = product, Quantity = quantity });
        }

        public  Either<ApplicationException, Order> Approve()
        {
            if (Status == OrderStatus.Rejected)
            {
                return new RejectedOrderCannotBeApprovedException();
            }

            if (Status == OrderStatus.Shipped)
            {
                return new ShippedOrdersCannotBeChangedException();
            }

            Status = OrderStatus.Approved;
            return this;
        }

        public Either<ApplicationException, Order> Reject()
        {
            if (Status == OrderStatus.Shipped)
            {
                return new ShippedOrdersCannotBeChangedException();
            }

            if (Status == OrderStatus.Approved)
            {
                return new ApprovedOrderCannotBeRejectedException();
            }

            Status = OrderStatus.Rejected;
            return this;
        }

        public (Order? Success, ApplicationException? Error) Ship()
        {
            if (Status == OrderStatus.Created || Status == OrderStatus.Rejected)
            {
                return (null, new OrderCannotBeShippedException());
            }

            if (Status == OrderStatus.Shipped)
            {
                return (null, new OrderCannotBeShippedTwiceException());
            }

            Status = OrderStatus.Shipped;
            return (this, null);
        }
    }
}
