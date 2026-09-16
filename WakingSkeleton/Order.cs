namespace WakingSkeleton;

public sealed class Order
{
    private readonly IStock _stock;

    public Order(IStock stock)
    {
        _stock = stock;
    }

    public List<Item> Items { get; set; } = new();

    public void AddItem(int productId, int quantity)
    {
        _stock.PlaceHold(productId, quantity);
        Items.Add(new Item());
    }
}