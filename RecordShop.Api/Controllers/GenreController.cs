using Microsoft.AspNetCore.Mvc;
using RecordShop.Business.Services.IServices;
using RecordShop.Common.Dto.Music;
using RecordShop.DataAccess.Models.Music;

namespace RecordShop.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GenreController : GenericController<AlbumGenre, AlbumGenreReadDto, AlbumGenreWriteDto>
    {
        public GenreController(IGenericService<AlbumGenre, AlbumGenreReadDto, AlbumGenreWriteDto> genreService) : base(genreService)
        {
        }
    }
}
