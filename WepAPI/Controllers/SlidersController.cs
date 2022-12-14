using Application.Features.Sliders.Commands.CreateSlider;
using Application.Features.Sliders.Commands.UpdateSlider;
using Application.Features.Sliders.Dtos;
using Application.Features.Sliders.Models;
using Application.Features.Sliders.Queries;
using Core.Application.Requests;
using Microsoft.AspNetCore.Mvc;

namespace WepAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SlidersController : BaseController
    {

        [HttpPost]
        public async Task<IActionResult> Add([FromForm] CreateSliderCommand command)
        {
            CreatedSliderDto result = await Mediator.Send(command);
            return Created("", result);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromForm] UpdateSliderCommand command)
        {
            UpdatedSliderDto result = await Mediator.Send(command);
            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
        {
            GetListSliderQuery query = new() { PageRequest = pageRequest };
            SliderListModel result = await Mediator.Send(query);
            return Ok(result);
        }
    }
}
