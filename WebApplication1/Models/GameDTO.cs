using BakAPI.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BakAPI.Models
{
    public class CreateGameDTO
    {

        public int RedDefId { get; set; }
        public int RedDefScore { get; set; }

        public int RedOffId { get; set; }
        public int RedOffScore { get; set; }


        public int GreDefId { get; set; }
        public int GreDefScore { get; set; }

        public int GreOffId { get; set; }
        public int GreOffScore { get; set; }
        public ICollection<Player> Players { get; set; }

    }
    public class GameDTO : CreateGameDTO
    {
        public int Id { get; set; }


    }
}
