using BakAPI.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BakAPI.Data
{
    public class Game
    {
        public int Id { get; set; }

       
        public int RedDefId { get; set; }
        public Player RedDef { get; set; }
        public int RedDefScore { get; set; }


        public int RedOffId { get; set; }
        public Player RedOff { get; set; }
        public int RedOffScore { get; set; }


        public int GreDefId { get; set; }
        public Player GreDef { get; set; }
        public int GreDefScore { get; set; }

        public int GreOffId { get; set; }
        public Player GreOff { get; set; }
        public int GreOffScore { get; set; }

        public int GreScore { get; set; }
        public int RedScore { get; set; }
        public DateTime StartDateTime { get; set; }
        public TimeSpan Duration { get; set; }

        public string Winner { get; set; }
        public int DuoRedId { get; set; }
        public Duo DuoRed { get; set; }
        public int DuoGreId { get; set; }
        public Duo DuoGre { get; set; }

        public double EloRedDefBase { get; set; }
        public double EloRedOffBase { get; set; }
        public double EloGreDefBase { get; set; }
        public double EloGreOffBase { get; set; }

        public double EloRedDefBonus { get; set; }
        public double EloRedOffBonus { get; set; }
        public double EloGreDefBonus { get; set; }
        public double EloGreOffBonus { get; set; }

        public double EloRedTeamBonus { get; set; }
        public double EloGreTeamBonus { get; set; }

        public double RedDefDeltaElo { get; set; }
        public double RedOffDeltaElo { get; set; }
        public double GreDefDeltaElo { get; set; }
        public double GreOffDeltaElo { get; set; }

        public virtual ICollection<Player> Players { get; set; }
        public virtual ICollection<Goal> Goals { get; set; }

    }
}
