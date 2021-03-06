﻿using CQRSCore.Commands;
using System;

namespace Commands.Match
{
    public class AddMatch : ICommand
    {
        public int RedDefenderId { get; set; }
        public int RedAttackerId { get; set; }
        public int BlueAttackerId { get; set; }
        public int BlueDefenderId { get; set; }
        public int RedScore { get; set; }
        public int BlueScore { get; set; }
        public DateTime Date { get; private set; }

        public AddMatch()
        {
            Date = DateTime.Now;
        }
    }
}
