﻿using CommandsValidators;
using CQRSCore.Validators;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CQRSCore.Commands
{
    public class CommandBus : ICommandBus
    {
        private readonly Func<Type, IHandleCommand> handlersFactory;
        private readonly Func<Type, IEnumerable<IValidator>> valdiatorsFactory;

        public CommandBus(Func<Type, IHandleCommand> handlersFactory, Func<Type, IEnumerable<IValidator>> valdiatorsFactory)
        {
            this.handlersFactory = handlersFactory;
            this.valdiatorsFactory = valdiatorsFactory;
        }


        public void SendCommand<T>(T command) where T : ICommand
        {
            var validators = valdiatorsFactory(typeof(T))
                .Cast<IValidator<T>>();

            foreach (var validator in validators)
            {
                var result = validator.Validate(command);
                if (!result.IsValid)
                {
                    throw new ValidationException(result.Message);
                }
            }
            
            var handler = (IHandleCommand<T>)handlersFactory(typeof(T));
            handler.Handle(command);
        }
    }
}
