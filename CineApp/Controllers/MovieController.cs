using CineApp.Bases.Response;
using CineApp.Model.DTO.Movie.Request;
using CineApp.Model.DTO.Movie.Response;
using CineApp.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CineApp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MovieController : ControllerBase
    {
        private readonly IMovieService _movieService;

        public MovieController(IMovieService movieService)
        {
            _movieService = movieService;
        }

        [HttpGet]
        public async Task<ActionResult<BaseResponse<IEnumerable<MovieResponseDTO>>>> GetAll()
        {
            var response = await _movieService.GetAllAsync();
            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<BaseResponse<MovieResponseDTO>>> GetById(int id)
        {
            var response = await _movieService.GetByIdAsync(id);
            if (!response.IsSuccess)
                return NotFound(response);
            return Ok(response);
        }

        [HttpGet("search")]
        public async Task<ActionResult<BaseResponse<IEnumerable<MovieResponseDTO>>>> SearchByName([FromQuery] string name)
        {
            var response = await _movieService.GetByNameAsync(name);
            return response.IsSuccess ? Ok(response) : BadRequest(response);
        }



        [HttpPost]
        public async Task<ActionResult<BaseResponse<MovieResponseDTO>>> Create([FromBody] MovieRequestDTO requestDto)
        {
            var response = await _movieService.CreateAsync(requestDto);
            if (!response.IsSuccess)
                return BadRequest(response);

            return CreatedAtAction(nameof(GetById), new { id = response.Data?.Id }, response);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<BaseResponse<bool>>> Update(int id, [FromBody] MovieRequestDTO dto)
        {
            var response = await _movieService.UpdateAsync(id, dto);
            if (!response.IsSuccess)
                return NotFound(response);

            return Ok(response);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<BaseResponse<bool>>> Delete(int id)
        {
            var response = await _movieService.DeleteAsync(id);
            if (!response.IsSuccess)
                return NotFound(response);

            return Ok(response);
        }
    }
}
