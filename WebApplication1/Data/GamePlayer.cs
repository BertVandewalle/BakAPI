namespace BakAPI.Data
{
    public class GamePlayer
    {
        public int Id { get; set; }
        public int GameId { get; set; }
        public int PlayerId { get; set; }
        public string Role { get; set; }
        public Game Game { get; set; }
        public Player Player { get; set; }
    }
}