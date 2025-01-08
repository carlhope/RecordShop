using Microsoft.AspNetCore.Mvc;
using RecordShop.Business.Services.IServices;
using RecordShop.DataAccess.Interfaces;

namespace RecordShop.Api.Controllers
{
    public class GenericController <T, DTO> : ControllerBase where T : class, IEntity where DTO : class
    {
        public IGenericService<T, DTO> _genericService;

        public GenericController(IGenericService<T, DTO> genericService)
        {
            _genericService = genericService;
        }

        [HttpPost]
        public virtual async Task<IActionResult> Create(DTO dto)
        {
            if (ModelState.IsValid)
            {
                var result = await _genericService.CreateAsync(dto);
                if (result.IsSuccess)
                {
                    return Ok(dto);
                }
                else return BadRequest("failed to create new entity");

            }
            return BadRequest("ModelState invalid");
        }
        [HttpPut("{id}")]
        public virtual async Task<IActionResult> Update(int id, DTO dto)
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
        [HttpDelete]
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
