﻿using Application.Features.User.Commands.UpdateUser;
using Application.Features.User.Dtos;
using Application.Features.User.Models;
using Application.Features.User.Queries;
using Core.Application.Requests;
using Microsoft.AspNetCore.Mvc;

namespace WepAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : BaseController
    {
        [HttpPut]
        public async Task<IActionResult> UpdateUser([FromBody] UpdateUserCommand updateUserCommand)
        {
            UpdatedUserDto updatedUserDto = await Mediator.Send(updateUserCommand);

            return Ok(updatedUserDto);
        }

        [HttpGet]
        public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
        {
            GetListUserQuery query = new() { PageRequest = pageRequest };
            UserListModel result = await Mediator.Send(query);
            return Ok(result);
        }
    }
}
