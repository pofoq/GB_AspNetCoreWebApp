using Microsoft.AspNetCore.Mvc;
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
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService _service;
        private readonly CancellationToken _token;

        public EmployeeController(IEmployeeService service)
        {
            _service = service;
            _token = new CancellationToken();
        }

        [HttpGet]
        public async Task<IEnumerable<EmployeeDto>> GetAllAsync([FromQuery] int count = 5, [FromQuery] int page = 1, [FromQuery] string searchByName = "")
        {
            return await _service.GetAllAsync(count, page, searchByName, _token);
        }

        [HttpGet("{id}")]
        public async Task<EmployeeDto> GetByIdAsync([FromRoute] int id)
        {
            return await _service.GetByIdAsync(id, _token);
        }

        [HttpPost]
        public async Task<EmployeeDto> AddAsync([FromBody] AddEmployeeRequest request)
        {
            return await _service.AddAsync(request, _token);
        }

        [HttpDelete]
        public async Task<bool> DeleteAsync([FromBody] int id)
        {
            return await _service.DeleteByIdAsync(id, _token);
        }

        [HttpPut]
        public async Task<bool> UpdateAsync([FromBody] EmployeeDto dto)
        {
            return await _service.UpdateAsync(dto, _token);
        }
    }
}
