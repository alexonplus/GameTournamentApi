namespace GameTournamentApi.Models
{
    public class Game
    {
public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
       
        public DateTime ReleaseDate { get; set; }
        public int TournamentId { get; set; }
        public Tournament Tournament { get; set; } = null!;


    }
}
