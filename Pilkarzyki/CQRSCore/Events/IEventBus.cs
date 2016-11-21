namespace CQRSCore.Events
{
    public interface IEventBus
    {
        void PublishEvent<T>(T ev) where T : IEvent;
    }
}
