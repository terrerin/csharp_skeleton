namespace WakingSkeleton;

public sealed class Order
{
    private readonly IStock _stock;

    public Order(IStock stock)
    {
        _stock = stock;
    }

    public List<object> Items { get; set; } = new List<object> { new() };

    public void AddItem(int productId, int quantity)
    {
        _stock.PlaceHold(productId, quantity);
    }
}
