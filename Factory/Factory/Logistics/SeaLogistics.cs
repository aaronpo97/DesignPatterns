using Factory.Transport;

namespace Factory.Logistics;

public sealed class SeaLogistics : LogisticsFactory
{
    public override ITransport CreateTransport() => new Ship();
}
