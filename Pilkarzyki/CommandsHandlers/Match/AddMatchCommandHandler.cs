using Commands.Match;
using CQRSCore.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommandsHandlers.Match
{
    public class AddMatchCommandHandler : IHandleCommand<AddMatch>
    {
        public void Handle(AddMatch command)
        {
            throw new NotImplementedException();
        }
    }
}
