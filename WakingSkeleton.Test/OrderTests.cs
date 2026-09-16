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
}
