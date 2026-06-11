using Factory.Transport;

namespace Factory.Logistics;

public sealed class RoadLogistics : LogisticsFactory
{
    public override ITransport CreateTransport() => new Truck();
}
