using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web.Models
{
    public class MatchModel
    {
        public int RedScore { get; set; }
        public int BlueScore { get; set; }
        public string RedTeam { get; set; }
        public string BlueTeam { get; set; }
    }
}