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

    }
    public class GameDTO : CreateGameDTO
    {
        public int Id { get; set; }
        public PlayerDTO RedOff { get; set; }
        public PlayerDTO RedDef { get; set; }
        public PlayerDTO GreDef { get; set; }
        public PlayerDTO GreOff { get; set; }


    }
    public class UpdateGameDTO : CreateGameDTO
    {

    }
}
