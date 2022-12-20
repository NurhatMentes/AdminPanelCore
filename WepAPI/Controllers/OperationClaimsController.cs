using Application.Features.Claims.Commands.CreateOperationClaim;
using Application.Features.Claims.Commands.DeleteOperationClaim;
using Application.Features.Claims.Commands.UptadeOperationClaim;
using Application.Features.Claims.Dtos;
using Application.Features.Claims.Models;
using Application.Features.Claims.Queries;
using Core.Application.Requests;
using Microsoft.AspNetCore.Mvc;
using WepAPI.Controllers;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OperationClaimsController : BaseController
    {
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] CreateOperationClaimCommand command)
        {
            CreatedOperationClaimDto result = await Mediator.Send(command);
            return Created("", result);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateOperationClaimCommand command)
        {
            UpdatedOperationClaimDto result = await Mediator.Send(command);
            return Ok(result);
        }

        [HttpDelete("{Id}")]
        public async Task<IActionResult> Delete([FromRoute] DeleteOperationClaimCommand command)
        {
            DeletedOperationClaimDto? result = await Mediator.Send(command);
            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
        {
            GetListOperationClaimQuery getList = new() { PageRequest = pageRequest };
            OperationClaimListModel result = await Mediator.Send(getList);
            return Ok(result);
        }
    }
}
