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
        public string Name { get; set; }
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
        public int WinDefAmount { get; set; }
        public int WinOffAmount { get; set; }
        public Decimal DefWinRate { get; set; }
        public Decimal OffWinRate { get; set; }
        public Decimal WinRate { get; set; }
        //TODO: ref to rank
        public int Rank { get; set; }
        public int GoalAmount { get; set; }
        public int GoalAmountDef { get; set; }
        public int GoalAmountOff { get; set; }
        public Decimal GoalRateDef { get; set; }
        public Decimal GoalRateOff { get; set; }
        public Decimal GoalMatchRate { get; set; }
        public Decimal GoalMatchRateDef { get; set; }
        public Decimal GoalMatchRateOff { get; set; }
        public virtual IList<GamePlayer> GamePlayers { get; set; }
    }
}
