using EgitimPortaliWebApi.Business.Services;
using EgitimPortaliWebApi.Data.Dtos.Field;
using EgitimPortaliWebApi.Data.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace EgitimPortaliWebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FieldController : ControllerBase
    {
        private readonly IFieldService _service;

        public FieldController(IFieldService service)
        {
            _service = service;
        }

        [HttpGet("GetByIdAsync/{id}")]
        public async Task<ActionResult<Field>> GetByIdAsync(int id)
        {
            var result = await _service.GetByIdAsync(id);

            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }

        [HttpGet("GetListAsync")]
        public async Task<ActionResult<IEnumerable<Field>>> GetListAsync()
        {
            var result = await _service.GetListAsync();

            if (result.IsNullOrEmpty()) { 
                return NotFound();
            }

            return Ok(result);
        }

        [HttpPost("CreateAsync")]
        public async Task<ActionResult<Field>> CreateAsync([FromForm] CreateFieldDto fieldDto)
        {
            var result = await _service.CreateAsync(fieldDto);

            if (result == null)
            {
                return BadRequest();
            }

            return Ok(result);
        }

        [HttpPost("DeleteAsync")]
        public async Task<ActionResult> DeleteAsync(int id)
        {
            Field? field = await _service.GetByIdAsync(id);

            if (field == null)
            {
                return NotFound(id);
            }

            await _service.DeleteAsync(field);
            return Ok();
        }
    }
}
