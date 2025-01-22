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
        public override async Task<IActionResult> GetById(int id)
        {
            var result = await _albumService.GetByIdAsync(id);
            if (result != null)
            {
                return Ok(result);
            }
            return NotFound("No results matching Id");
        }

        //override getall
        public override Task<IActionResult> GetAll()
        {
            return base.GetAll();
        }
        [HttpGet("artist/{id}")]
        public async Task<IActionResult> GetAllByArtist(int id)
        {
            var result = await _albumService.GetAllByArtist(id);
            if (result != null)
            {
                return Ok(result);
            }
            return NotFound("No results matching artist id");
        }
        [HttpGet("genre/{genre}")]
        public async Task<IActionResult> GetAllByGenre(string genre)
        {
            var result = await _albumService.GetAllByGenre(genre);
            if (result != null)
            {
                return Ok(result);
            }
            return NotFound("No results matching genre");
        }
        [HttpGet("name/{name}")]
        public async Task<IActionResult> GetByAlbumName(string name)
        {
            var result = await _albumService.GetByAlbumName(name);
            if (result != null)
            {
                return Ok(result);
            }
            return NotFound("No results matching name");
        }
    }
}
