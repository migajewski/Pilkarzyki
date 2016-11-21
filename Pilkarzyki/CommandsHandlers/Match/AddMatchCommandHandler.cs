using Commands.Match;
using CQRSCore.Commands;
using Simple.Data;

namespace CommandsHandlers.Match
{
    public class AddMatchCommandHandler : IHandleCommand<AddMatch>
    {
        public void Handle(AddMatch command)
        {
            var db = Database.Open();

            db.Match.Insert(
                RedDefenderId : command.RedDefenderId,
                RedAttackerId : command.RedAttackerId,
                BlueDefenderId : command.BlueDefenderId,
                BlueAttackerId : command.BlueAttackerId,
                RedScore : command.RedScore,
                BlueScore : command.BlueScore
                );

        }
    }
}
