using Application.Features.SubCategories.Commands.CreateSubCategory;
using Application.Features.SubCategories.Commands.UpdateSubCategory;
using Application.Features.SubCategories.Dtos;
using Application.Features.SubCategories.Models;
using Application.Features.SubCategories.Queries;
using Core.Application.Requests;
using Microsoft.AspNetCore.Mvc;

namespace WepAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubCategoriesController : BaseController
    {
        [HttpPost]
        public async Task<IActionResult> Add([FromForm] CreateSubCategoryCommand command)
        {
            CreatedSubCategoryDto result = await Mediator.Send(command);
            return Created("", result);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromForm] UpdateSubCategoryCommand command)
        {
            UpdatedSubCategoryDto result = await Mediator.Send(command);
            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
        {
            GetListSubCategoryQuery query = new() { PageRequest = pageRequest };
            SubCategoryListModel result = await Mediator.Send(query);
            return Ok(result);
        }
    }
}
