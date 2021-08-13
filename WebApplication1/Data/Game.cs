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
        
 
        //public virtual ICollection<Player> Players { get; set; }
    }
}
