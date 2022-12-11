using Application.Features.Product.Commands.CreateProduct;
using Application.Features.Product.Commands.UpdateProduct;
using Application.Features.Product.Dtos;
using Application.Features.Product.Models;
using Application.Features.Product.Queries;
using Core.Application.Requests;
using Microsoft.AspNetCore.Mvc;

namespace WepAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : BaseController
    {

        [HttpPost]
        public async Task<IActionResult> Add([FromForm] CreateProductCommand command)
        {
            CreatedProductDto result = await Mediator.Send(command);
            return Created("", result);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromForm] UpdateProductCommand command)
        {
            UpdatedProductDto result = await Mediator.Send(command);
            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
        {
            GetListProductQuery query = new() { PageRequest = pageRequest };
            ProductListModel result = await Mediator.Send(query);
            return Ok(result);
        }
    }
}
