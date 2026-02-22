namespace GameTournamentApi.Models
{
    public class Game
    {
        public int Id { get; set; }

      
        public string Name { get; set; } = string.Empty;


        public string Genre { get; set; } = string.Empty;

        public int TournamentId { get; set; }

        
        public Tournament Tournament { get; set; } = null!;
    }
}