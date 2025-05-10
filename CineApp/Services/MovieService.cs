using CineApp.Bases.Response;
using CineApp.Model;
using CineApp.Model.DTO.Movie.Request;
using CineApp.Model.DTO.Movie.Response;
using CineApp.Repository.Interfaces;
using CineApp.Services.Interfaces;
using CineApp.Utils;

namespace CineApp.Services
{
    public class MovieService : IMovieService
    {
        private readonly IMovieRepository _repository;
        public MovieService(IMovieRepository repository)
        {
            _repository = repository;
        }

        public async Task<BaseResponse<IEnumerable<MovieResponseDTO>>> GetAllAsync()
        {
            var movies = await _repository.GetAllAsync();
            var data = movies.Select(m => new MovieResponseDTO
            {
                Id = m.Id,
                Name = m.Name,
                Duration = m.Duration,
            });

            return new BaseResponse<IEnumerable<MovieResponseDTO>>
            {
                IsSuccess = true,
                Data = data,
                TotalRecords = data.Count(),
                Message = ReplyMessage.MESSAGE_QUERY
            };
        }

        public async Task<BaseResponse<MovieResponseDTO>> GetByIdAsync(int id)
        {
            var movie = await _repository.GetByIdAsync(id);
            if (movie == null)
            {
                return new BaseResponse<MovieResponseDTO>
                {
                    IsSuccess = false,
                    Message = ReplyMessage.MESSAGE_QUERY_EMPTY,
                };
            }

            return new BaseResponse<MovieResponseDTO>
            {
                IsSuccess = true,
                Data = new MovieResponseDTO
                {
                    Id = movie.Id,
                    Name = movie.Name,
                    Duration = movie.Duration,
                },
                Message = ReplyMessage.MESSAGE_QUERY
            };
        }

        public async Task<BaseResponse<IEnumerable<MovieResponseDTO>>> GetByNameAsync(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                return new BaseResponse<IEnumerable<MovieResponseDTO>>
                {
                    IsSuccess = false,
                    Message = ReplyMessage.MESSAGE_FAILED
                };
            }

            var result = await _repository.GetByNameAsync(name);
            var data = result.Select(m => new MovieResponseDTO
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
                Message = data.Any() ? ReplyMessage.MESSAGE_QUERY : ReplyMessage.MESSAGE_QUERY_EMPTY
            };
        }



        public async Task<BaseResponse<MovieResponseDTO>> CreateAsync(MovieRequestDTO requestDto)
        {
            var movie = new Movie
            {
                Name = requestDto.Name,
                Duration = requestDto.Duration,
                IsDeleted = false,
            };

            var success = await _repository.AddAsync(movie);
            if (!success)
            {
                return new BaseResponse<MovieResponseDTO>
                {
                    IsSuccess = false,
                    Message = ReplyMessage.MESSAGE_FAILED,
                };
            }

            return new BaseResponse<MovieResponseDTO>
            {
                IsSuccess = true,
                Data = new MovieResponseDTO
                {
                    Id = movie.Id,
                    Name = movie.Name,
                    Duration = movie.Duration,
                },
                Message = ReplyMessage.MESSAGE_SAVE
            };
        }

        public async Task<BaseResponse<bool>> UpdateAsync(int id, MovieRequestDTO requestDto)
        {
            var movie = await _repository.GetByIdAsync(id);
            if (movie == null)
            {
                return new BaseResponse<bool>
                {
                    IsSuccess = false,
                    Message = ReplyMessage.MESSAGE_QUERY_EMPTY
                };
            }

            movie.Name = requestDto.Name;
            movie.Duration = requestDto.Duration;

            var updated = await _repository.UpdateAsync(movie);
            return new BaseResponse<bool>
            {
                IsSuccess = updated,
                Message = updated ? ReplyMessage.MESSAGE_QUERY : ReplyMessage.MESSAGE_FAILED
            };
        }

        public async Task<BaseResponse<bool>> DeleteAsync(int id)
        {
            var movie = await _repository.GetByIdAsync(id);
            if (movie == null)
            {
                return new BaseResponse<bool>
                {
                    IsSuccess = false,
                    Message = ReplyMessage.MESSAGE_QUERY_EMPTY
                };
            }

            var deleted = await _repository.DeleteAsync(id);
            return new BaseResponse<bool>
            {
                IsSuccess = deleted,
                Data = deleted,
                Message = deleted ? ReplyMessage.MESSAGE_DELETE : ReplyMessage.MESSAGE_FAILED
            };
        }


    }
}
