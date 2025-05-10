namespace CineApp.Model.DTO.MovieCinema
{
    public class CinemaMovieRequestDTO
    {
        public int MovieId { get; set; }
        public int CinemaId { get; set; }
        public DateTime ReleaseDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
