using Microsoft.AspNetCore.Mvc;
using RecordShop.Business.Services;
using RecordShop.Business.Services.IServices;
using RecordShop.Common.Dto.Music;
using RecordShop.DataAccess.Models.Music;

namespace RecordShop.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ArtistController : GenericController<Artist, ArtistReadDto, ArtistWriteDto>
    {
        private readonly IArtistService _artistService;
        public ArtistController(IArtistService artistService) : base(artistService)
        {
            _artistService = artistService;
        }

        //add get by name endpoint
        [HttpGet("name/{name}")]
        public async Task<IActionResult> GetByArtistName(string name)
        {
            var result = await _artistService.GetByArtistName(name);
            if (result != null)
            {
                return Ok(result);
            }
            return NotFound("No results matching name");
        }
    }
}
