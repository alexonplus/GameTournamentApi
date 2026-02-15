namespace GameTournamentApi.Models
{
    public class Tournament
    {
        // Unique number. In the database, it will become the Primary Key.
        public int Id { get; set; }
       
        // Tournament name. By default, we set it to an empty string to avoid errors.
        public string Title { get; set; } = string.Empty;

        //Description of what kind of tournament it is.

        public string Description { get; set; } = string.Empty;

        //How many players can participate in the tournament. 
        public int MaxPlayers { get; set; }

        //Date of the tournament. 
        public DateTime Date { get; set; }


        public ICollection<Game> Games { get; set; } = new List<Game>();


    }
}
