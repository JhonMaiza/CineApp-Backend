using CineApp.Bases.Response;
using CineApp.Model.DTO.Movie.Response;
using CineApp.Model.DTO.MovieCinema;
using CineApp.Services;
using CineApp.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CineApp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CinemaMovieController : ControllerBase
    {
        private readonly ICinemaMovieService _service;

        public CinemaMovieController(ICinemaMovieService service)
        {
            _service = service;
        }

        [HttpPost("assign")]
        public async Task<ActionResult<BaseResponse<bool>>> Assign([FromBody] CinemaMovieRequestDTO requestDto)
        {
            var response = await _service.AssignMovieAsync(requestDto);
            if (!response.IsSuccess)
                return BadRequest(response);

            return Ok(response);
        }

        [HttpGet("by-release-date")]
        public async Task<ActionResult<BaseResponse<IEnumerable<MovieResponseDTO>>>> GetByReleaseDate([FromQuery] DateTime date)
        {
            var response = await _service.GetMoviesByReleaseDateAsync(date);
            return response.IsSuccess ? Ok(response) : BadRequest(response);
        }

    }
}
