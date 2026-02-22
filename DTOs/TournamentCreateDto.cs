using System.ComponentModel.DataAnnotations; // 

namespace GameTournamentApi.DTOs
{
    public class TournamentCreateDto
    {
        [Required]
        [MinLength(3, ErrorMessage = "Title must be at least 3 characters")] // protect from 2 words
        public string Title { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;

        [Range(1, 1000)]
        public int MaxPlayers { get; set; }

        public DateTime Date { get; set; }
    }
}