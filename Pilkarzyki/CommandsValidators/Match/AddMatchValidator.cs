using Commands.Match;
using System.Collections.Generic;
using System.Linq;

namespace CommandsValidators.Match
{
    public class AddMatchPlayersIdsValidator : IValidator<AddMatch>
    {
        public ValidationResult Validate(AddMatch command)
        {
            var ids = new List<int> { command.RedAttackerId, command.RedDefenderId, command.BlueAttackerId, command.BlueDefenderId };
            if (ids.Distinct().Count() != 4)
                return new ValidationResult(false, "Zawodnik nie może grać jednocześnie na dwóch pozycjach");

            return new ValidationResult();
        }
    }
}
