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
        ValidationResult Validate(T command);
    }

    public class ValidationResult
    {
        public string Message { get; private set; }
        public bool IsValid { get; private set; }

        public ValidationResult(bool isValid =true)
        {
            IsValid = isValid;
        }

        public ValidationResult(bool isValid, string message)
        {
            IsValid = isValid;
            Message = message;
        }
    }
}
