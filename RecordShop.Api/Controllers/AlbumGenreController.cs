using Microsoft.AspNetCore.Mvc;
using RecordShop.Business.Services.IServices;
using RecordShop.Common.Dto.Music;
using RecordShop.DataAccess.Models.Music;

namespace RecordShop.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AlbumGenreController : GenericController<AlbumGenre, AlbumGenreReadDto, AlbumGenreWriteDto>
    {
        private readonly IAlbumGenreService _genreService;
        private readonly ILogger<AlbumGenreController> _logger;

        public AlbumGenreController(IAlbumGenreService genreService, ILogger<AlbumGenreController> logger) : base(genreService)
        {
            _genreService = genreService;
            _logger = logger;
        }
        [HttpGet("name/{name}")]
        public async Task<IActionResult> GetGenreByName(string name)
        {
            var result = await _genreService.GetByName(name.Trim());
            if (result != null)
                return Ok(result);

            _logger.LogWarning($"Genre with name {name} not found.");
            return NotFound("Genre not found");
        }
    }
}
