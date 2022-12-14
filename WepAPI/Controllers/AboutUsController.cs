using Application.Features.AboutUs.Commands.CreateAboutUs;
using Application.Features.AboutUs.Commands.UpdateAboutUs;
using Application.Features.AboutUs.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace WepAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AboutUsController : BaseController
    {
        [HttpPost]
        public async Task<IActionResult> Add([FromForm] CreateAboutUsCommand command)
        {
            CreatedAboutUsDto result = await Mediator.Send(command);
            return Created("", result);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromForm] UpdateAboutUsCommand command)
        {
            UpdatedAboutUsDto result = await Mediator.Send(command);
            return Ok(result);
        }

    }
}
