using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BakAPI.Models
{
    public class GamePlayerDTO : CreateGamePlayerDTO
    {
        public int Id { get; set; }
        public GameDTO Game { get; set; }
        public PlayerDTO Player { get; set; }
    }
    public class CreateGamePlayerDTO
    {
        public int GameId { get; set; }
        public int PlayerId { get; set; }
        public string Role { get; set; }
    }
}
