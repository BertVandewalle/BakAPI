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

        //public int PlayerId { get; set; }
        ///public Player Player { get; set; }

        public int RedDefScore { get; set; }

        //[ForeignKey(nameof(RedOff))]
        public int RedOffId { get; set; }
        //public Player RedOff { get; set; }
        public int RedOffScore { get; set; }


        //[ForeignKey(nameof(GreDef))]
        public int GreDefId { get; set; }
        //public Player GreDef { get; set; }
        public int GreDefScore { get; set; }

        //[ForeignKey(nameof(GreOff))]
        public int GreOffId { get; set; }
        //public Player GreOff { get; set; }
        public int GreOffScore { get; set; }

        public int GreScore { get; set; }
        public int RedScore { get; set; }


        public IList<GamePlayer> GamePlayers { get; set; }
    }
}
