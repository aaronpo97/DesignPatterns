using Factory.Logistics;
using Factory.Transport;

namespace Factory.Tests;

public class FactoryMethodTests
{
    /// <summary>
    /// Factory Method lets each concrete creator decide which product to build
    /// while callers only depend on the shared product interface.
    /// </summary>
    [Theory]
    [MemberData(nameof(LogisticsFactories))]
    public void Logistics_CreatesTransportBehindAbstractType(
        LogisticsFactory logistics,
        Type expectedTransportType,
        string expectedDelivery)
    {
        // Act
        ITransport transport = logistics.CreateTransport();

        // Assert
        Assert.IsAssignableFrom<ITransport>(transport);
        Assert.IsType(expectedTransportType, transport);
        Assert.Equal(expectedDelivery, transport.Deliver());
    }

    /// <summary>
    /// The creator can contain business logic that works with any transport
    /// returned by the factory method.
    /// </summary>
    [Theory]
    [MemberData(nameof(LogisticsDeliveries))]
    public void PlanDelivery_UsesTransportCreatedByFactoryMethod(
        LogisticsFactory logistics,
        string expectedDelivery)
    {
        // Act
        string deliveryPlan = logistics.PlanDelivery();

        // Assert
        Assert.Equal(expectedDelivery, deliveryPlan);
    }

    /// <summary>
    /// Client code can swap logistics implementations without changing how it
    /// asks for a delivery plan.
    /// </summary>
    [Fact]
    public void DifferentLogisticsFactories_CreateDifferentTransports()
    {
        // Arrange
        LogisticsFactory roadLogistics = new RoadLogistics();
        LogisticsFactory seaLogistics = new SeaLogistics();

        // Act
        string roadDelivery = roadLogistics.PlanDelivery();
        string seaDelivery = seaLogistics.PlanDelivery();

        // Assert
        Assert.Equal("Deliver by land in a truck", roadDelivery);
        Assert.Equal("Deliver by sea in a ship", seaDelivery);
        Assert.NotEqual(roadDelivery, seaDelivery);
    }

    public static TheoryData<LogisticsFactory, Type, string> LogisticsFactories =>
        new()
        {
            { new RoadLogistics(), typeof(Truck), "Deliver by land in a truck" },
            { new SeaLogistics(), typeof(Ship), "Deliver by sea in a ship" },
        };

    public static TheoryData<LogisticsFactory, string> LogisticsDeliveries =>
        new()
        {
            { new RoadLogistics(), "Deliver by land in a truck" },
            { new SeaLogistics(), "Deliver by sea in a ship" },
        };
}
