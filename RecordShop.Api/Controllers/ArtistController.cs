using Microsoft.AspNetCore.Mvc;
using RecordShop.Business.Services.IServices;
using RecordShop.Common.Dto.Music;
using RecordShop.DataAccess.Models.Music;

namespace RecordShop.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ArtistController : GenericController<Artist, ArtistReadDto, ArtistWriteDto>
    {
        public ArtistController(IArtistService artistService) : base(artistService)
        {
        }
    }
}
