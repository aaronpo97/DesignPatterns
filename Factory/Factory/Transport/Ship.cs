namespace Factory.Transport;

public sealed class Ship : ITransport
{
    public string Deliver() => "Deliver by sea in a ship";
}
