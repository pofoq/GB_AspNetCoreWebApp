using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
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
        public PersonController(IPersonService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IEnumerable<PersonDto>> GetAllAsync([FromQuery]int count = 5, [FromQuery]int page = 1, [FromQuery]string searchByName = "")
        {
            return await _service.GetAllAsync(count, page, searchByName);
        }

        [HttpGet("id/{id}")]
        public async Task<PersonDto> GetById([FromRoute] int id)
        {
            return await _service.GetByIdAsync(id);
        }

        [HttpDelete("id/{id}")]
        public async Task<bool> DeleteById([FromRoute] int id)
        {
            return await _service.DeleteByIdAsync(id);
        }

        [HttpPost]
        public async Task<PersonDto> PostAsync([FromBody]PersonDto dto)
        {
            return await _service.AddAsync(dto);
        }

        [HttpPut]
        public async Task<bool> PutAsync([FromBody]PersonDto dto)
        {
            return await _service.UpdateAsync(dto);
        }
    }
}
