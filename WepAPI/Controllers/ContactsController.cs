using Application.Features.Contact.Commands.CreateContact;
using Application.Features.Contact.Commands.UpdateContact;
using Application.Features.Contact.Dtos;
using Application.Features.Contact.Models;
using Application.Features.Contact.Queries;
using Application.Features.Slider.Commands.CreateSlider;
using Application.Features.Slider.Commands.UpdateSlider;
using Application.Features.Slider.Dtos;
using Application.Features.Slider.Models;
using Application.Features.Slider.Queries;
using Core.Application.Requests;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WepAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactsController : BaseController
    {
        [HttpPost]
        public async Task<IActionResult> Add([FromForm] CreateContactCommand command)
        {
            CreatedContactDto result = await Mediator.Send(command);
            return Created("", result);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromForm] UpdateContactCommand command)
        {
            UpdatedContactDto result = await Mediator.Send(command);
            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
        {
            GetListContactQuery query = new() { PageRequest = pageRequest };
            ContactListModel result = await Mediator.Send(query);
            return Ok(result);
        }
    }
}
