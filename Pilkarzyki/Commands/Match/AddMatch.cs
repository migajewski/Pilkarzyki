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
        public string RedDefender { get; set; }
        public string RedAttacker { get; set; }
        public string BlueAttacker { get; set; }
        public string BlueDefender { get; set; }
        public int RedScore { get; set; }
        public int BlueScore { get; set; }
    }
}
