using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Timesheets.BusinessLayer.Abstractions.Services;
using Timesheets.BusinessLayer.Dto;

namespace Timesheets.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PersonController : ControllerBase
    {
        private readonly IPersonService _service;
        private readonly CancellationToken _token;

        public PersonController(IPersonService service)
        {
            _service = service;
            _token = new CancellationToken();
        }

        [HttpGet]
        public async Task<IEnumerable<PersonDto>> GetAllAsync([FromQuery]int count = 5, [FromQuery]int page = 1, [FromQuery]string searchByName = "")
        {
            return await _service.GetAllAsync(count, page, searchByName, _token);
        }

        [HttpGet("id/{id}")]
        public async Task<PersonDto> GetByIdAsync([FromRoute] int id)
        {
            return await _service.GetByIdAsync(id, _token);
        }
    }
}
