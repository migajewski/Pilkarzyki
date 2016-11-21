namespace CQRSCore.Events
{
    public interface IHandleEvent : IEvent
    {

    }

    public interface IHandleEVent<TEvent> : IHandleEvent
    where TEvent : IEvent
    {
        void Handle(TEvent ev);
    }
}
