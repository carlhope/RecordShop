using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;
using RecordShop.Business.Services.IServices;
using RecordShop.Common.Dto.Music;
using RecordShop.Common.Enums;
using RecordShop.DataAccess.Models.Music;

namespace RecordShop.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AlbumController : GenericController<Album, AlbumReadDto, AlbumWriteDto>
    {
        private readonly IAlbumService _albumService;
        public AlbumController(IAlbumService albumService) : base(albumService)
        {
            _albumService = albumService;

        }
        [HttpGet("artist/{id}")]
        public async Task<IActionResult> GetAllByArtist(int id)
        {
            var result = await _albumService.GetAllByArtist(id);
            if (result != null)
            {
                return Ok(result);
            }
            return NoContent();
        }
        [HttpGet("genre/{genre}")]
        public async Task<IActionResult> GetAllByGenre(string genre)
        {
            var result = await _albumService.GetAllByGenre(genre);
            if (result != null)
            {
                return Ok(result);
            }
            return NoContent();
        }
        [HttpGet("name/{name}")]
        public async Task<IActionResult> GetByAlbumName(string name)
        {
            var result = await _albumService.GetByAlbumName(name.Trim());
            if (result != null)
            {
                return Ok(result);
            }
            return NotFound("No results matching name");
        }
        [HttpPut("{id}")]
        public override async Task<IActionResult> Update(int id, [FromBody] AlbumWriteDto dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Invalid data provided.");
            }

            var result = await _albumService.UpdateAsync(id, dto);

            if (result.IsSuccess)
            {
                return Ok(new { message = result.Message });
            }
            else
            {
                return BadRequest(new { message = result.Message });
            }
        }

    }
}
