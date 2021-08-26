using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BakAPI.Models
{
    public class DuoDTO : CreateDuoDTO
    {
        public int Id { get; set; }
        public PlayerDTO DefPlayer { get; set; }
        public PlayerDTO OffPlayer { get; set; }
        public Double WinRate { get; set; }
        public int NumberOfGames { get; set; }

        public ICollection<GameDTO> GamesRed { get; set; }
        public ICollection<GameDTO> GamesGre { get; set; }

    }
    public class CreateDuoDTO
    {
        public int DefPlayerId { get; set; }
        public int OffPlayerId { get; set; }

    }
}
