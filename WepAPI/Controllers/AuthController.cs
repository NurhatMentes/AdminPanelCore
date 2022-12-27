using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Application.Auth.Dtos;
using Application.Features.Auth.Commands.Login;
using Application.Features.Auth.Commands.Register;
using Application.Features.Auth.Dtos;
using Core.Security.Entities;
using Core.Security.JWT;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace WepAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : BaseController
    {

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] UserForRegisterDto userForRegisterDto)
        {
            RegisterCommand registerCommand = new RegisterCommand()
            {
                UserForRegisterDto = userForRegisterDto,
                IpAddress = GetIpAddress()
            };

            RegisteredDto result = await Mediator.Send(registerCommand);
            SetRefreshTokenToCookie(result.RefreshToken);
            return Created("", result.AccessToken);
        }
        private void SetRefreshTokenToCookie(RefreshToken refreshToken)
        {
            CookieOptions cookieOptions = new() { HttpOnly = true, Expires = DateTime.Now.AddMinutes(60) , Secure = true};
            Response.Cookies.Append("refreshToken", refreshToken.Token, cookieOptions);
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromQuery] LoginQuery loginQuery)
        {
            RefreshedTokenDto result = await Mediator.Send(loginQuery);
            return Ok(result);
        }
    }
}