using CineApp.Bases.Response;
using CineApp.Model;
using CineApp.Model.DTO.Movie.Response;
using CineApp.Model.DTO.MovieCinema;
using CineApp.Repository;
using CineApp.Repository.Interfaces;
using CineApp.Services.Interfaces;
using CineApp.Utils;

namespace CineApp.Services
{
    public class CinemaMovieService: ICinemaMovieService
    {
        private readonly ICinemaMovieRepository _repository;

        public CinemaMovieService(ICinemaMovieRepository repository)
        {
            _repository = repository;
        }

        public async Task<BaseResponse<bool>> AssignMovieAsync(CinemaMovieRequestDTO requestDto)
        {
            if (requestDto.ReleaseDate >= requestDto.EndDate)
            {
                return new BaseResponse<bool>
                {
                    IsSuccess = false,
                    Message =  ReplyMessage.MESSAGE_DATE_ERROR,
                };
            }

            var exists = await _repository.ExistsAsync(requestDto.MovieId, requestDto.CinemaId, requestDto.ReleaseDate);
            if (exists)
            {
                return new BaseResponse<bool>
                {
                    IsSuccess = false,
                    Message = ReplyMessage.MESSAGE_EXISTS,
                };
            }

            var assignment = new CinemaMovie
            {
                MovieId = requestDto.MovieId,
                CinemaId = requestDto.CinemaId,
                ReleaseDate = requestDto.ReleaseDate,
                EndDate = requestDto.EndDate
            };

            var success = await _repository.AddAsync(assignment);
            return new BaseResponse<bool>
            {
                IsSuccess = success,
                Data = success,
                Message = success ? ReplyMessage.MESSAGE_SAVE : ReplyMessage.MESSAGE_FAILED
            };
        }

        public async Task<BaseResponse<IEnumerable<MovieResponseDTO>>> GetMoviesByReleaseDateAsync(DateTime date)
        {
            if (date == default)
            {
                return new BaseResponse<IEnumerable<MovieResponseDTO>>
                {
                    IsSuccess = false,
                    Message = ReplyMessage.MESSAGE_FAILED
                };
            }

            var movies = await _repository.GetMoviesByReleaseDateAsync(date);
            var data = movies.Select(m => new MovieResponseDTO
            {
                Id = m.Id,
                Name = m.Name,
                Duration = m.Duration
            });

            return new BaseResponse<IEnumerable<MovieResponseDTO>>
            {
                IsSuccess = true,
                Data = data,
                TotalRecords = data.Count(),
                Message = ReplyMessage.MESSAGE_QUERY
            };
        }
    }
}
