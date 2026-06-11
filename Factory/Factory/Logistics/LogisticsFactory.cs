using Factory.Transport;

namespace Factory.Logistics;

public abstract class LogisticsFactory
{
    public string PlanDelivery()
    {
        ITransport transport = CreateTransport();

        return transport.Deliver();
    }

    public abstract ITransport CreateTransport();
}
