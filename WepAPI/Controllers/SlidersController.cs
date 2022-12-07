using Application.Features.Slider.Commands.CreateSlider;
using Application.Features.Slider.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WepAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SlidersController : BaseController
    {

        [HttpPost("multiple-files")]
        public async Task<IActionResult> Upload([FromForm] CreateSliderCommand command)
        {
            CreatedSliderDto result = await Mediator.Send(command);
            return Created("", result);
        }
    }
}
