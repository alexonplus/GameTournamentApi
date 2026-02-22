namespace GameTournamentApi.DTOs
{
    public class GameCreateDto
    {
        public string Name { get; set; } = string.Empty;
        public string Genre { get; set; } = string.Empty;
        public int TournamentId { get; set; }
    }
}