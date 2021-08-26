using BakAPI.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BakAPI.Models
{
    public class CreatePlayerDTO
    {
        [Required]
        public virtual string Name { get; set; }
        public double Elo { get; set; }


    }
    public class PlayerDTO : CreatePlayerDTO
    {
        public int Id { get; set; }
        public int RedDefAmount { get; set; }
        public int RedOffAmount { get; set; }
        public int GreDefAmount { get; set; }
        public int GreOffAmount { get; set; }
        public int GameAmount { get; set; }
        public int WinAmount { get; set; }
        public int LossAmount { get; set; }
        public int DefAmount { get; set; }
        public int OffAmount { get; set; }
        public int WinDefAmount { get; set; }
        public int WinOffAmount { get; set; }
        public double DefWinRate { get; set; }
        public double OffWinRate { get; set; }
        public double WinRate { get; set; }
        //TODO: ref to rank
        public int RankId { get; set; }
        public RankDTO Rank { get; set; }
        public int GoalAmount { get; set; }
        public int GoalAmountDef { get; set; }
        public int GoalAmountOff { get; set; }
        public double GoalRateDef { get; set; }
        public double GoalRateOff { get; set; }
        public double GoalMatchRate { get; set; }
        public double GoalMatchRateDef { get; set; }
        public double GoalMatchRateOff { get; set; }
        public ICollection<GameDTO> GamesRedDef { get; set; }
        public ICollection<GameDTO> GamesRedOff { get; set; }
        public ICollection<GameDTO> GamesGreDef { get; set; }
        public ICollection<GameDTO> GamesGreOff { get; set; }
        public ICollection<GoalDTO> Goals { get; set; }
        public virtual ICollection<DuoDTO> DefDuos { get; set; }
        public virtual ICollection<DuoDTO> OffDuos { get; set; }

    }
    
}
