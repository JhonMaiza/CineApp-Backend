using CineApp.Bases.Response;
using CineApp.Model.DTO.Cinema;
using CineApp.Services;
using CineApp.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CineApp.Controllers
{ 
    [ApiController]
    [Route("api/[controller]")]
    public class CinemaController: ControllerBase
    {
        private readonly ICinemaService _cinemaService;
        public CinemaController(ICinemaService cinemaService)
        {
            _cinemaService = cinemaService;
        }

        [HttpGet("availability")]
        public async Task<ActionResult<BaseResponse<CinemaAvailabilityResponseDTO>>> GetAvailability([FromQuery] string name)
        {
            var response = await _cinemaService.GetAvailabilityByNameAsync(name);
            return response.IsSuccess ? Ok(response) : NotFound(response);
        }

    }
}
