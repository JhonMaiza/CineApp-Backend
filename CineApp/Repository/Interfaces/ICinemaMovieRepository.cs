using CineApp.Model;

namespace CineApp.Repository.Interfaces
{
    public interface ICinemaMovieRepository
    {
        Task<bool> ExistsAsync(int movieId, int cinemaId, DateTime releaseDate);
        Task<bool> AddAsync(CinemaMovie entity);
        Task<IEnumerable<Movie>> GetMoviesByReleaseDateAsync(DateTime date);
    }
}
