using Microsoft.AspNetCore.Mvc;
using RecordShop.Business.Services.IServices;
using RecordShop.DataAccess.Interfaces;

namespace RecordShop.Api.Controllers
{
    public class GenericController <T, ReadDTO, WriteDTO> : ControllerBase where T : class, IEntity where ReadDTO : class where WriteDTO : class
    {
        public IGenericService<T, ReadDTO, WriteDTO> _genericService;

        public GenericController(IGenericService<T, ReadDTO, WriteDTO> genericService)
        {
            _genericService = genericService;
        }

        [HttpPost]
        public virtual async Task<IActionResult> Create(WriteDTO dto)
        {
            if (ModelState.IsValid)
            {
                var result = await _genericService.CreateAsync(dto);
                if (result.IsSuccess)
                {
                    return Ok(dto);
                }
                else return BadRequest(result.Message);

            }
            return BadRequest("ModelState invalid");
        }
        [HttpPut("{id}")]
        public virtual async Task<IActionResult> Update(int id,[FromBody] WriteDTO dto)
        {
            if (ModelState.IsValid)
            {
                await _genericService.UpdateAsync(id, dto);
                return Ok(dto);
            }
            return BadRequest("ModelState invalid");
        }
        [HttpGet]
        public virtual async Task<IActionResult> GetAll()
        {
            var result = await _genericService.GetAllAsync();
            return Ok(result);
        }
        [HttpGet("{id}")]

        public virtual async Task<IActionResult> GetById(int id)
        {
            var result = await _genericService.GetByIdAsync(id);
            if (result != null)
            {
                return Ok(result);
            }
            return NotFound("No results matching Id");

        }
        [HttpDelete("{id}")]
        public virtual async Task<IActionResult> Delete(int id)
        {
            var result = await _genericService.DeleteAsync(id);
            if (result.IsSuccess)
            {
                return Ok(result);
            }
            return BadRequest("unable to delete entity matching id");
        }
    }
}
