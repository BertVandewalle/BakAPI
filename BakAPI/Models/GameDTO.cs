using BakAPI.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BakAPI.Models
{
    public class CreateGameDTO
    {
        [Required]
        public int RedDefId { get; set; }
        public int RedDefScore { get; set; }

        [Required]
        public int RedOffId { get; set; }
        public int RedOffScore { get; set; }

        [Required]
        public int GreDefId { get; set; }
        public int GreDefScore { get; set; }

        [Required]
        public int GreOffId { get; set; }
        public int GreOffScore { get; set; }

        public int GreScore { get; set; }
        public int RedScore { get; set; }

        public DateTime StartDateTime { get; set; }
        public TimeSpan Duration { get; set; }

        public string Winner { get; set; }

        public int DuoRedId { get; set; }
        public int DuoGreId { get; set; }

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


    }
    public class GameDTO : CreateGameDTO
    {
        public int Id { get; set; }
        public PlayerDTO RedOff { get; set; }
        public PlayerDTO RedDef { get; set; }
        public PlayerDTO GreDef { get; set; }
        public PlayerDTO GreOff { get; set; }

        public DuoDTO DuoRed { get; set; }
        public DuoDTO DuoGre { get; set; }

        public ICollection<PlayerDTO> Players { get; set; }
        public ICollection<GoalDTO> Goals { get; set; }

    }
    public class UpdateGameDTO : CreateGameDTO
    {

    }
}
