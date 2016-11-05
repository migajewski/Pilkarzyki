using CQRSCore.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Commands.Match
{
    public class AddMatch : ICommand
    {
        public string RedDefenderId { get; set; }
        public string RedAttackerId { get; set; }
        public string BlueAttackerId { get; set; }
        public string BlueDefenderId { get; set; }
        public int RedScore { get; set; }
        public int BlueScore { get; set; }
    }
}
