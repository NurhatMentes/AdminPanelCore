using Application.Features.TablesLogs.Models;
using Application.Features.TablesLogs.Queries;
using Core.Application.Requests;
using Microsoft.AspNetCore.Mvc;

namespace WepAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TablesLogsController : BaseController
    {

        [HttpGet]
        public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
        {
            GetListTablesLogQuery query = new GetListTablesLogQuery { PageRequest = pageRequest };
            TablesLogListModel result = await Mediator.Send(query);
            return Ok(result);
        }
    }
}
