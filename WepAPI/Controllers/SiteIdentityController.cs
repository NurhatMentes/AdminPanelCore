using Application.Features.SiteIdentity.Commands.CreateSiteIdentity;
using Application.Features.SiteIdentity.Commands.UpdateSiteIdentity;
using Application.Features.SiteIdentity.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace WepAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SiteIdentityController : BaseController
    {
        [HttpPost]
        public async Task<IActionResult> Add([FromForm] CreateSiteIdentityCommand command)
        {
            CreatedSiteIdentityDto result = await Mediator.Send(command);
            return Created("", result);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromForm] UpdateSiteIdentityCommand command)
        {
            UpdatedSiteIdentityDto result = await Mediator.Send(command);
            return Ok(result);
        }
    }
}
