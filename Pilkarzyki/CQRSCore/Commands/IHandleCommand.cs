namespace CQRSCore.Commands
{
    public interface IHandleCommand :ICommand
    {
    }

    public interface IHandleCommand<TCommand> : IHandleCommand
        where TCommand : ICommand
    {
        void Handle(TCommand command);
    }
}
