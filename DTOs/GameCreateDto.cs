namespace GameTournamentApi.DTOs
{
    public class GameCreateDto // This class is a Data Transfer Object (DTO) used for creating a new gamentId.
    {
        public string Name { get; set; } = string.Empty;
        public string Genre { get; set; } = string.Empty;
        public int TournamentId { get; set; }
    }
}