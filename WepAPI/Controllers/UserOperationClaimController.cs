using Application.Features.UserOperationClaims.Commands.CreateUserOperationClaim;
using Application.Features.UserOperationClaims.Commands.DeleteUserOperationClaim;
using Application.Features.UserOperationClaims.Commands.Queries.GetListUserOperation;
using Application.Features.UserOperationClaims.Commands.UpdateUserOperationClaim;
using Application.Features.UserOperationClaims.Dtos;
using Application.Features.UserOperationClaims.Model;
using Core.Application.Requests;
using Microsoft.AspNetCore.Mvc;
using WepAPI.Controllers;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserOperationClaimController : BaseController
    {
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] CreateUserOperationClaimCommand command)
        {
            CreatedUserOperationClaimDto result = await Mediator.Send(command);
            return Created("", result);
        }

        [HttpDelete("{Id}")]
        public async Task<IActionResult> Delete([FromRoute] DeleteUserOperationClaimCommand command)
        {
            DeletedUserOperationClaimDto result = await Mediator.Send(command);
            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateUserOperationClaimCommand command)
        {
            UpdatedUserOperationClaimDto result = await Mediator.Send(command);
            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
        {
            GetListUserOperationQuery query = new() { PageRequest = pageRequest };
            UserOperationClaimListModel result = await Mediator.Send(query);
            return Ok(result);
        }
    }
}
