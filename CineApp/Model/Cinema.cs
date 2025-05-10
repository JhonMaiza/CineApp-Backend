namespace CineApp.Model
{
    public class Cinema
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int State { get; set; }

        public ICollection<CinemaMovie> CinemaMovies { get; set; }
    }
}
