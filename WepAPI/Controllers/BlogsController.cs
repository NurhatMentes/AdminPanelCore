using Application.Features.Blogs.Commands.CreateBlog;
using Application.Features.Blogs.Commands.UpdateBlog;
using Application.Features.Blogs.Dtos;
using Application.Features.Blogs.Models;
using Application.Features.Blogs.Queries;
using Application.Features.Blogs.Queris;
using Core.Application.Requests;
using Microsoft.AspNetCore.Mvc;

namespace WepAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogsController : BaseController
    {
        [HttpPost]
        public async Task<IActionResult> Add([FromForm] CreateBlogCommand command)
        {
            CreatedBlogDto result = await Mediator.Send(command);
            return Created("", result);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromForm] UpdateBlogCommand command)
        {
            UpdatedBlogDto result = await Mediator.Send(command);
            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
        {
            GetListBlogQuery query = new GetListBlogQuery { PageRequest = pageRequest };
            BlogListModel result = await Mediator.Send(query);
            return Ok(result);
        }

        [HttpGet("state")]
        public async Task<IActionResult> GetListByState([FromQuery] PageRequest pageRequest, bool State)
        {
            GetListByStateBlogQuery query = new GetListByStateBlogQuery { PageRequest = pageRequest, State = State };
            BlogListModel result = await Mediator.Send(query);
            return Ok(result);
        }

        [HttpGet("GetCountOfBlog")]
        public async Task<IActionResult> GetCountOfBlog([FromQuery] PageRequest pageRequest)
        {
            GetListBlogQuery query = new GetListBlogQuery { PageRequest = pageRequest };
            BlogListModel result = await Mediator.Send(query);
            return Ok(result.Count);
        }

        [HttpGet("GetEndOfBlog")]
        public async Task<IActionResult> GetEndOfBlog([FromQuery] PageRequest pageRequest)
        {
            GetListBlogQuery query = new GetListBlogQuery { PageRequest = pageRequest };
            BlogListModel result = await Mediator.Send(query);
            return Ok(result.Items.OrderByDescending(p => p.Id).Take(3)
                .Select(p => p.Title + " - Ekleyen:" + p.UserName + ", Güncelleyen:" + p.EmendatorAdminName + ", Tarih:" + p.CreationTime).ToList());
        }
    }
}
