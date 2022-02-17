using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Timesheets.BusinessLayer.Abstractions.Services;
using Timesheets.BusinessLayer.Dto;
using Timesheets.BusinessLayer.Requests;

namespace Timesheets.Api.Controllers
{
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
        public async Task<IEnumerable<UserDto>> GetAllAsync([FromQuery] int count = 5, [FromQuery] int page = 1, [FromQuery] string searchByName = "")
        {
            return await _service.GetAllAsync(count, page, searchByName, _token);
        }

        [HttpGet("id/{id}")]
        public async Task<UserDto> GetByIdAsync([FromRoute] Guid id)
        {
            return await _service.GetByIdAsync(id, _token);
        }

        [HttpPost]
        public async Task<UserDto> AddAsync([FromBody] AddUserRequest request)
        {
            return await _service.AddAsync(request, _token);
        }

        [HttpDelete]
        public async Task<bool> DeleteAsync([FromBody] UserDto dto)
        {
            return await _service.DeleteAsync(dto, _token);
        }

        [HttpPut]
        public async Task<bool> UpdateAsync([FromBody] UserDto dto)
        {
            return await _service.UpdateAsync(dto, _token);
        }
    }
}
