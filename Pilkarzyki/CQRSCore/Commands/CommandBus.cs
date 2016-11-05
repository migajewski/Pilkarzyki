using System;

namespace CQRSCore.Commands
{
    public class CommandBus : ICommandBus
    {
        private readonly Func<Type, IHandleCommand> handlersFactory;

        public CommandBus(Func<Type, IHandleCommand> handlersFactory)
        {
            this.handlersFactory = handlersFactory;

        }


        public void SendCommand<T>(T command) where T : ICommand
        {
            var handler = (IHandleCommand<T>)handlersFactory(typeof(T));
            handler.Handle(command);
        }
    }
}
