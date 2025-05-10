using CineApp.Bases.Response;
using CineApp.Model.DTO.Movie.Response;
using CineApp.Model.DTO.MovieCinema;

namespace CineApp.Services.Interfaces
{
    public interface ICinemaMovieService
    {
        Task<BaseResponse<bool>> AssignMovieAsync(CinemaMovieRequestDTO dto);
        Task<BaseResponse<IEnumerable<MovieResponseDTO>>> GetMoviesByReleaseDateAsync(DateTime date);

    }
}
