namespace Factory.Transport;

public sealed class Truck : ITransport
{
    public string Deliver() => "Deliver by land in a truck";
}
