using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BakAPI.Data
{
    public class Duo
    {
        public int Id { get; set; }
        public int DefPlayerId { get; set; }
        public Player DefPlayer { get; set; }
        public int OffPlayerId { get; set; }
        public Player OffPlayer { get; set; }
        public double WinRate { get; set; }
        public int NumberOfGames { get; set; }
        public ICollection<Game> GamesRed { get; set; }
        public ICollection<Game> GamesGre { get; set; }


    }
}
