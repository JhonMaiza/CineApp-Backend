namespace CineApp.Model
{
    public class Movie
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Duration { get; set; }

        public bool IsDeleted { get; set; }

        public ICollection<CinemaMovie> CinemaMovies { get; set; }
    }
}
