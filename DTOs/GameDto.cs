namespace GameTournamentApi.DTOs
{
    public class GameDto 
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Genre { get; set; } = string.Empty;

        // without this, we get a 500 circular reference error when trying to serialize the Game object.f****
        public int TournamentId { get; set; }
    }
}