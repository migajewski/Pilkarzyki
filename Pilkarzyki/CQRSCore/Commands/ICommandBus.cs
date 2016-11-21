namespace CQRSCore.Commands
{
    public interface ICommandBus
    {
        void SendCommand<T>(T command) where T : ICommand;
    }
}
