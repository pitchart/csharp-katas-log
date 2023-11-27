using Order_Shipping.Domain;

namespace OrderShipping.Domain;

public class Order
{
    public decimal Total { get; set; }
    public string Currency { get; set; }
    public IList<OrderItem> Items { get; set; }
    public decimal Tax { get; set; }
    public OrderStatus Status { get; set; }
    public int Id { get; set; }

    public Order(IEnumerable<OrderItem> items, string currency)
    {
        if (items is null || !items.Any())
        {
            throw new InvalidOrderException();
        }

        Status = OrderStatus.Created;
        Items = new List<OrderItem>();
        Currency = currency;
        Total = 0m;
        Tax = 0m;

        foreach (var item in items)
        {
            AddItem(item);
        }
    }

    public Order() { }

    private void AddItem(OrderItem orderItem)
    {
        this.Items.Add(orderItem);
        this.Total += orderItem.TaxedAmount;
        this.Tax += orderItem.Tax;
    }
}
