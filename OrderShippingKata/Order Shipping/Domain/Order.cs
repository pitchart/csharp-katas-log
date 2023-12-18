using Order_Shipping.Domain;

namespace OrderShipping.Domain;

public class Order
{
    private OrderState _state;

    public Price Total { get; private set; }
    public string Currency { get; }
    public IList<OrderItem> Items { get; }
    public Price Tax { get; private set; }
    public OrderStatus Status { get => _state.State; set => _state = OrderState.Create(value); }
    public int Id { get; init; }

    public Order(IEnumerable<OrderItem> items, string currency)
    {
        if (items is null || !items.Any())
        {
            throw new InvalidOrderException();
        }

        Status = OrderStatus.Created;
        Items = new List<OrderItem>();
        Currency = currency;
        Total = new Price(0m, currency);
        Tax = new Price(0m, currency);

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

    public void Approve()
    {
        _state = _state.Approve();
    }

    public void Reject()
    {
        _state = _state.Reject();
    }
}
