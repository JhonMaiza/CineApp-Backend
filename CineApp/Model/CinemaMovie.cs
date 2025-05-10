namespace CineApp.Model
{
    public class CinemaMovie
    {
        public int Id { get; set; }

        public int CinemaId { get; set; }
        public Cinema Cinema { get; set; }

        public int MovieId { get; set; }
        public Movie Movie { get; set; }

        public DateTime ReleaseDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
