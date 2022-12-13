using Application.Features.ProductSlider.Commands.CreateProductSlider;
using Application.Features.ProductSlider.Commands.UpdateProductSlider;
using Application.Features.ProductSlider.Dtos;
using Application.Features.ProductSlider.Models;
using Application.Features.ProductSlider.Queries;
using Core.Application.Requests;
using Microsoft.AspNetCore.Mvc;

namespace WepAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductSlidersController : BaseController
    {
        [HttpPost]
        public async Task<IActionResult> Add([FromForm] CreateProductSliderCommand command)
        {
            CreatedProductSliderDto result = await Mediator.Send(command);
            return Created("", result);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromForm] UpdateProductSliderCommand command)
        {
            UpdatedProductSliderDto result = await Mediator.Send(command);
            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
        {
            GetListProductSliderQuery query = new() { PageRequest = pageRequest };
            ProductSliderListModel result = await Mediator.Send(query);
            return Ok(result);
        }
    }
}
