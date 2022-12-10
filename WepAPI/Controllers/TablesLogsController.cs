using Application.Features.TablesLog.Commands.CreateTablesLog;
using Application.Features.TablesLog.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace WepAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TablesLogsController : BaseController
    {
        [HttpPost]
        public async Task<IActionResult> Add([FromForm] CreateTablesLogCommand command)
        {
            CreatedTablesLogDto result = await Mediator.Send(command);
            return Created("", result);
        }

    }
}
