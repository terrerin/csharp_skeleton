namespace WakingSkeleton;

public sealed class Order
{
    private readonly IStock _stock;

    public Order(IStock stock)
    {
        _stock = stock;
    }

    public List<Item> Items { get; set; } = new List<Item> { new() };

    public void AddItem(int productId, int quantity)
    {
        _stock.PlaceHold(productId, quantity);
    }
}

public class Item
{
    public int ProductId { get; } = 327;
}
