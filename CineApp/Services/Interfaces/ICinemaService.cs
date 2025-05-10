using CineApp.Bases.Response;
using CineApp.Model.DTO.Cinema;

namespace CineApp.Services.Interfaces
{
    public interface ICinemaService
    {
        Task<BaseResponse<CinemaAvailabilityResponseDTO>> GetAvailabilityByNameAsync(string name);
    }
}
