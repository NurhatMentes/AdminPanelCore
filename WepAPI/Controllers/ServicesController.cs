﻿using Application.Features.Service.Commands.CreateService;
using Application.Features.Service.Commands.UpdateService;
using Application.Features.Service.Dtos;
using Application.Features.Service.Models;
using Application.Features.Service.Queries;
using Core.Application.Requests;
using Microsoft.AspNetCore.Mvc;

namespace WepAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServicesController : BaseController
    {
        [HttpPost]
        public async Task<IActionResult> Add([FromForm] CreateServiceCommand command)
        {
            CreatedServiceDto result = await Mediator.Send(command);
            return Created("", result);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromForm] UpdateServiceCommand command)
        {
            UpdatedServiceDto result = await Mediator.Send(command);
            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
        {
            GetListServiceQuery query = new() { PageRequest = pageRequest };
            ServiceListModel result = await Mediator.Send(query);
            return Ok(result);
        }
    }
}
