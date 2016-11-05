using Commands.Match;
using CQRSCore.Commands;
using Simple.Data;
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
            var db = Database.Open();

            db.Match.Insert(
                //RedDefenderId : command.RedDefenderId,
                //RedAttackerId : command.RedAttackerId,
                //BlueDefenderId : command.BlueDefenderId,
                //BlueAttackerId : command.BlueAttackerId,
                //RedScore : command.RedScore,
                //BlueScore : command.BlueScore
                command
                );

        }
    }
}
