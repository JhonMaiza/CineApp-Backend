using CineApp.Bases.Response;
using CineApp.Model.DTO.Movie.Request;
using CineApp.Model.DTO.Movie.Response;

namespace CineApp.Services.Interfaces
{
    public interface IMovieService
    {
        Task<BaseResponse<IEnumerable<MovieResponseDTO>>> GetAllAsync();
        Task<BaseResponse<MovieResponseDTO>> GetByIdAsync(int id);
        Task<BaseResponse<IEnumerable<MovieResponseDTO>>> GetByNameAsync(string name);

        Task<BaseResponse<MovieResponseDTO>> CreateAsync(MovieRequestDTO requestDto);
        Task<BaseResponse<bool>> UpdateAsync(int id, MovieRequestDTO requestDto);
        Task<BaseResponse<bool>> DeleteAsync(int id);
    }
}
