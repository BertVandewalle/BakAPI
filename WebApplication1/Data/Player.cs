using BakAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BakAPI.Data
{
    public class Player
    {
        public int Id { get; set; }
        public string Name { get; set; }
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
        public double Elo { get; set; }
        //TODO: ref to rank
        public int? RankId { get; set; }
        public Rank Rank { get; set; }
        public int GoalAmount { get; set; }
        public int GoalAmountDef { get; set; }
        public int GoalAmountOff { get; set; }
        public double GoalRateDef { get; set; }
        public double GoalRateOff { get; set; }
        public double GoalMatchRate { get; set; }
        public double GoalMatchRateDef { get; set; }
        public double GoalMatchRateOff { get; set; }
        public virtual ICollection<Game> GamesRedDef { get; set; }
        public virtual ICollection<Game> GamesRedOff { get; set; }
        public virtual ICollection<Game> GamesGreDef { get; set; }
        public virtual ICollection<Game> GamesGreOff { get; set; }
        public virtual ICollection<Goal> Goals { get; set; }
        public virtual ICollection<Duo> DefDuos { get; set; }
        public virtual ICollection<Duo> OffDuos { get; set; }



    }
}
