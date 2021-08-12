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
        public int WinDefAmount { get; set; }
        public int WinOffAmount { get; set; }
        public Decimal DefWinRate { get; set; }
        public Decimal OffWinRate { get; set; }
        public Decimal WinRate { get; set; }
        public double Elo { get; set; }
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
        public int GamePlayerId { get; set; }
        public GamePlayer GamePlayers { get; set; }
    }
}
