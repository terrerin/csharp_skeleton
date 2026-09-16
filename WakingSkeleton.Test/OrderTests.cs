using Moq;

namespace WakingSkeleton.Test;

using WakingSkeleton;

public class OrderTests
{
    [Test]
    public void AddingItemToOrderWhenSufficientStockIsAvailablePutsTemporaryHoldOnStock()
    {
        var mockStock = new Mock<IStock>();

        var order = new Order(mockStock.Object);
        order.AddItem(327, 1);

        mockStock.Verify(s => s.PlaceHold(It.IsAny<int>(), It.IsAny<int>()));
    }

    [Test]
    public void AddingItemToOrderWhenSufficientStockIsAvailableAddsItemToOrder()
    {
        var order = new Order(new Mock<IStock>().Object);
        order.AddItem(327, 1);

        Assert.That(order.Items.Count, Is.EqualTo(1));
        Assert.That(order.Items.Single().ProductId, Is.EqualTo(327));
        Assert.That(order.Items.Single().Quantity, Is.EqualTo(1));
    }

    [Test]
    public void AddingAnItemWhenInsufficientStockIsAvailableRejectsWithInsufficientStockError()
    {
        var mockStock = new Mock<IStock>();
        mockStock.Setup(s => s.PlaceHold(It.IsAny<int>(), It.IsAny<int>())).Throws(new InsufficientStockException());
        var order = new Order(mockStock.Object);

        Assert.That(
            () => order.AddItem(327, 2),
            Throws.Exception.InstanceOf(typeof(InsufficientStockException)));
    }
}
