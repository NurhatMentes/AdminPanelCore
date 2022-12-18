using Application.Features.Comments.Commands.CreateComment;
using Application.Features.Comments.Commands.UpdateComment;
using Application.Features.Comments.Dtos;
using Application.Features.Comments.Models;
using Application.Features.Comments.Queries;
using Core.Application.Requests;
using Microsoft.AspNetCore.Mvc;

namespace WepAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentsController : BaseController
    {
        [HttpPost]
        public async Task<IActionResult> Add([FromForm] CreateCommentCommand command)
        {
            CreatedCommentDto result = await Mediator.Send(command);
            return Created("", result);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromForm] UpdateCommentCommand command)
        {
            UpdatedCommentDto result = await Mediator.Send(command);
            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
        {
            GetListCommentQuery query = new GetListCommentQuery { PageRequest = pageRequest };
            CommentListModel result = await Mediator.Send(query);
            return Ok(result);
        }

        [HttpGet("state")]
        public async Task<IActionResult> GetListByState([FromQuery] PageRequest pageRequest, bool confirmation)
        {
            GetListByConfirmationCommentQuery query = new GetListByConfirmationCommentQuery { PageRequest = pageRequest, Confirmation = confirmation };
            CommentListModel result = await Mediator.Send(query);
            return Ok(result);
        }
    }
}
