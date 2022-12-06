using Application.Features.User.Models;
using Application.Features.User.Queries;
using Core.Application.Requests;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AdminPanelCore.Controllers
{
    public class UsersController : BaseController
    {
        [HttpGet]
        public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
        {
            GetListUserQuery getListTechnologyQuery = new() { PageRequest = pageRequest };
            UserListModel result = await Mediator.Send(getListTechnologyQuery);
            return View(result);
        }

    }
}



///////////////
///
///
///
/// {
"Logging": {
    "LogLevel": {
        "Default": "Information",
        "Microsoft.AspNetCore": "Warning"
    }
},
"ConnectionStrings": {
    "AdminPanelCoreDbConnectionString": "Server=(localdb)\\MSSQLLocalDB;Database=AdminPanelCoreDb; Trusted_Connection=True;"
},
"AllowedHosts": "*"
}
