using CineApp.Bases.Response;
using CineApp.Model.DTO.Cinema;
using CineApp.Repository.Interfaces;
using CineApp.Services.Interfaces;
using CineApp.Utils;

namespace CineApp.Services
{
    public class CinemaService: ICinemaService
    {
        private readonly ICinemaRepository _repository;
        public CinemaService(ICinemaRepository repository)
        {
            _repository = repository;
        }

        public async Task<BaseResponse<CinemaAvailabilityResponseDTO>> GetAvailabilityByNameAsync(string name)
        {
            var count = await _repository.GetActiveMovieCountByCinemaNameAsync(name);
            string message = count switch
            {
                < 3 => ReplyMessage.MESSAGE_CINEMA_AVAILABLE,
                <= 5 => $"{ReplyMessage.MESSAGE_CINEMA_MOVIES_ASSIGNED}{count}",
                > 5 => ReplyMessage.MESSAGE_CINEMA_NOT_AVAILABLE
            };

            return new BaseResponse<CinemaAvailabilityResponseDTO>
            {
                IsSuccess = true,
                Data = new CinemaAvailabilityResponseDTO
                {
                    CinemaName = name,
                    AssignedMoviesCount = count,
                    StatusMessage = message
                },
                Message = ReplyMessage.MESSAGE_QUERY
            };
        }
    }
}
