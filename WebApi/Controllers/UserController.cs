using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Timesheets.Api.Responses;
using Timesheets.BusinessLayer.Abstractions.Services;
using Timesheets.BusinessLayer.Dto;
using Timesheets.BusinessLayer.Requests;

namespace Timesheets.Api.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _service;
        private readonly CancellationToken _token;

        public UserController(IUserService service)
        {
            _service = service;
            _token = new CancellationToken();
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserDto>>> GetAllAsync([FromQuery] int count = 5, [FromQuery] int page = 1, [FromQuery] string searchByName = "")
        {
            var users = await _service.GetAllAsync(count, page, searchByName, _token);
            if (users == null)
            {
                return NotFound();
            }
            return Ok(users);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<UserDto>> GetByIdAsync([FromRoute] int id)
        {
            if (id == 0)
            {
                return BadRequest();
            }

            var user = await _service.GetByIdAsync(id, _token);
            if (user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }

        [AllowAnonymous]
        [HttpPost("register")]
        public async Task<ActionResult<UserDto>> RegisterAsync([FromBody] AddUserRequest request)
        {
            if (string.IsNullOrEmpty(request.Username) || string.IsNullOrEmpty(request.Password))
            {
                return BadRequest(new { message = "Username and Password can't be empty" });
            }

            var user = await _service.AddAsync(request, _token);

            if (user == null)
            {
                return BadRequest(new { message = "Username is used or request is not valid" });
            }

            return Ok(user);
        }

        [HttpDelete("delete/{id}")]
        public async Task<ActionResult<bool>> DeleteAsync([FromRoute] int id)
        {
            if (await _service.DeleteByIdAsync(id, _token))
            {
                return Ok(true);
            }

            return NotFound();
        }

        [HttpPut("update")]
        public async Task<ActionResult<bool>> UpdateAsync([FromBody] UserDto dto)
        {
            if (await _service.UpdateAsync(dto, _token))
            {
                return Ok(true);
            }

            return NotFound(false);
        }

        [AllowAnonymous]
        [HttpPost("authenticate")]
        public async Task<ActionResult<TokenResponse>> AuthenticateAsync([FromQuery] string userName, string password)
        {
            if (string.IsNullOrWhiteSpace(userName) && string.IsNullOrEmpty(password))
            {
                return BadRequest();
            }

            var response = await _service.AuthenticateAsync(userName, password, _token);

            if (response is null)
            {
                return BadRequest(new { message = "Username or password is incorrect" });
            }

            SetTokenCookie(response.RefreshToken);

            return Ok(new TokenResponse { RefreshToken = response.RefreshToken, Token = response.AccessToken });
        }

        [AllowAnonymous]
        [HttpPost("refresh-token")]
        public async Task<ActionResult<TokenResponse>> RefreshAsync()
        {
            string oldToken = Request.Cookies["refreshToken"];

            if (string.IsNullOrWhiteSpace(oldToken))
            {
                return Unauthorized(new { message = "Invalid token" });
            }

            var newRefreshToken = await _service.RefreshToken(oldToken, _token);

            if (string.IsNullOrWhiteSpace(newRefreshToken?.RefreshToken))
            {
                return Unauthorized(new { message = "Invalid token" });
            }

            SetTokenCookie(newRefreshToken.RefreshToken);

            return Ok(new TokenResponse { RefreshToken = newRefreshToken.RefreshToken, Token = newRefreshToken.AccessToken });
        }

        private void SetTokenCookie(string refreshToken)
        {
            var cookieOptions = new CookieOptions
            {
                HttpOnly = true,
                Expires = DateTime.UtcNow.AddDays(7)
            };
            Response.Cookies.Append("refreshToken", refreshToken, cookieOptions);
        }
    }
}
