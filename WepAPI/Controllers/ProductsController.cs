using Application.Features.Products.Commands.CreateProduct;
using Application.Features.Products.Commands.UpdateProduct;
using Application.Features.Products.Dtos;
using Application.Features.Products.Models;
using Application.Features.Products.Queries;
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
            GetListProductQuery query = new GetListProductQuery { PageRequest = pageRequest };
            ProductListModel result = await Mediator.Send(query);
            return Ok(result);
        }

        [HttpGet("state")]
        public async Task<IActionResult> GetListByState([FromQuery] PageRequest pageRequest,bool State)
        {
            GetListByStateProductQuery query = new GetListByStateProductQuery { PageRequest = pageRequest, State = State };
            ProductListModel result = await Mediator.Send(query);
            return Ok(result);
        }

        [HttpGet("GetCountOfProduct")]
        public async Task<IActionResult> GetCountOfProduct([FromQuery] PageRequest pageRequest)
        {
            GetListProductQuery query = new GetListProductQuery { PageRequest = pageRequest };
            ProductListModel result = await Mediator.Send(query);
            return Ok(result.Count);
        }

        [HttpGet("GetEndOfProduct")]
        public async Task<IActionResult> GetEndOfProduct([FromQuery] PageRequest pageRequest)
        {
            GetListProductQuery query = new GetListProductQuery { PageRequest = pageRequest };
            ProductListModel result = await Mediator.Send(query);
            return Ok(result.Items.OrderByDescending(p=>p.ProductId).Take(3)
                .Select(p=>p.Title+" - Ekleyen:"+p.UserName +", Güncelleyen:"+p.EmendatorAdminName+", E.Tarih:"+p.CreationTime + ", G.Tarih:"+p.UpdateDate).ToList());
        }

        [HttpGet("GetTotalPriceProduct")]
        public async Task<IActionResult> GetTotalPriceProduct([FromQuery] PageRequest pageRequest)
        {
            GetListProductQuery query = new GetListProductQuery { PageRequest = pageRequest };
            ProductListModel result = await Mediator.Send(query);
            return Ok(result.Items.Sum(p => p.Price));
        }
    }
}
