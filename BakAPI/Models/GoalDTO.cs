using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BakAPI.Data
{
    public class GoalDTO : CreateGoalDTO
    {
        public int Id { get; set; }
        public Game Game { get; set; }
        public Player Player { get; set; }
    }
    public class CreateGoalDTO
    {
        public int GameId { get; set; }
        public int PlayerId { get; set; }
        public TimeSpan Time { get; set; }

    }

}
