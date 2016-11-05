using CQRSCore.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommandsValidators
{
    public interface IValidator
    {
    }

    public interface IValidator<T> : IValidator 
        where T : ICommand
    {
        bool Validate(T command);
    }
}
