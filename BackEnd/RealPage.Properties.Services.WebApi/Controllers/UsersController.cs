using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using RealPage.Properties.Application.DTO;
using RealPage.Properties.Application.Interface;
using RealPage.Properties.Services.WebApi.Helpers;
using RealPage.Properties.Transversal.Common;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace RealPage.Properties.Services.WebApi.Controllers
{
    //[Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : Controller
    {
        private readonly IUsersApplication _usersApplication;
        private readonly AppSettings _appSettings;

        public UsersController(IUsersApplication authApplication, IOptions<AppSettings> appSettings)
        {
            _usersApplication = authApplication;
            _appSettings = appSettings.Value;
        }

        [AllowAnonymous]
        [HttpPost("Authenticate")]
        public async Task<ActionResult> Authenticate([FromBody]UsersDto usersDto)
        {
            var response = await _usersApplication.Authenticate(usersDto.UserName, usersDto.Password);
            if (response.IsSuccess)
            {
                if (response.Data != null)
                {
                    response.Data.Token = BuildToken(response);
                    return Ok(response);
                }
                else
                    return NotFound(response.Message);
            }

            return BadRequest(response.Message);
        }

        private string BuildToken(Response<UsersDto> usersDto)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
            var minutesToSpire = int.Parse(_appSettings.MinutesToExpire);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, usersDto.Data.UserId.ToString())
                }),
                Expires = DateTime.UtcNow.AddMinutes(minutesToSpire),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature),
                Issuer = _appSettings.Issuer,
                Audience = _appSettings.Audience
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            var tokenString = tokenHandler.WriteToken(token);
            return tokenString;
        }

        [HttpPost("Add")]
        public async Task<IActionResult> Add([FromBody] UsersDto userDto)
        {
            if (userDto == null)
                return BadRequest();
            var response = await _usersApplication.Add(userDto);
            if (response.IsSuccess)
                return Ok(response.Data);

            return BadRequest(response.Message);
        }

        [HttpPut("Update")]
        public async Task<IActionResult> Update([FromBody] UsersDto usersDto)
        {
            if (usersDto == null)
                return BadRequest();
            var response = await _usersApplication.Update(usersDto);
            if (response.IsSuccess)
                return Ok(response.Data);

            return BadRequest(response.Message);
        }

        [HttpDelete("Delete/{propertyId}")]
        public async Task<IActionResult> Delete(string userId)
        {
            if (string.IsNullOrEmpty(userId))
                return BadRequest();
            var response = await _usersApplication.Delete(int.Parse(userId));
            if (response.IsSuccess)
                return Ok(response);

            return BadRequest(response.Message);
        }

        [HttpGet("Get/{propertyId}")]
        public async Task<IActionResult> Get(string userId)
        {
            if (string.IsNullOrEmpty(userId))
                return BadRequest();
            var response = await _usersApplication.Get(int.Parse(userId));
            if (response.IsSuccess)
                return Ok(response);

            return BadRequest(response.Message);
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var response = await _usersApplication.GetAll();
            if (response.IsSuccess)
                return Ok(response.Data);

            return BadRequest(response.Message);
        }
    }
}