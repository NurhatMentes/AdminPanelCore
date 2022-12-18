using Application.Features.HomeVideo.Models;
using Application.Features.HomeVideos.Commands.CreateHomeVideo;
using Application.Features.HomeVideos.Commands.UpdateHomeVideo;
using Application.Features.HomeVideos.Dtos;
using Application.Features.HomeVideos.Queries;
using Core.Application.Requests;
using Microsoft.AspNetCore.Mvc;

namespace WepAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeVideosController : BaseController
    {
        [HttpPost]
        public async Task<IActionResult> Add([FromForm] CreateHomeVideoCommand command)
        {
            CreatedHomeVideoDto result = await Mediator.Send(command);
            return Created("", result);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromForm] UpdateHomeVideoCommand command)
        {
            UpdatedHomeVideoDto result = await Mediator.Send(command);
            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
        {
            GetListHomeVideoQuery query = new() { PageRequest = pageRequest };
            HomeVideoListModel result = await Mediator.Send(query);
            return Ok(result);
        }
    }
}
