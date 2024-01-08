using Order_Shipping.Domain;

namespace OrderShipping.Domain;

public class Order
{
    public OrderState State { get; private set; }
    public Price Total { get; private set; }
    public string Currency { get; }
    public IList<OrderItem> Items { get; }
    public Price Tax { get; private set; }
    public int Id { get; init; }

    public Order(IEnumerable<OrderItem> items, string currency)
    {
        if (items is null || !items.Any())
        {
            throw new InvalidOrderException();
        }
        State = new OrderCreated();
        Items = new List<OrderItem>();
        Currency = currency;
        Total = new Price(0m, currency);
        Tax = new Price(0m, currency);

        foreach (var item in items)
        {
            AddItem(item);
        }
    }

    public Order()
    {
        State = new OrderCreated();
    }

    private void AddItem(OrderItem orderItem)
    {
        this.Items.Add(orderItem);
        this.Total += orderItem.TaxedAmount;
        this.Tax += orderItem.Tax;
    }

    public void Approve()
    {
        State = State.Approve();
    }

    public void Reject()
    {
        State = State.Reject();
    }

    public void Ship()
    {
        State = State.Ship();
    }
}
