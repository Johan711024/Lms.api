namespace Lms.Core
{
    public class Tournament
    {

        public int Id { get; set; }

        public string? Title { get; set; }
        public DateTime StartDate { get; set; }

        //Nav prop
        public ICollection<Game> Games { get; set; } = new List<Game>();
    }
}