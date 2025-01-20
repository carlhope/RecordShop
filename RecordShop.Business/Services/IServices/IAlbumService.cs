using RecordShop.Common.Dto.Inventory;
using RecordShop.Common.Dto.Music;
using RecordShop.Common.Enums;
using RecordShop.DataAccess.Models.Inventory;
using RecordShop.DataAccess.Models.Music;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecordShop.Business.Services.IServices
{
    public interface IAlbumService : IGenericService<Album, AlbumReadDto>
    {
        Task<List<AlbumReadDto>?> GetAllByArtist(int id);
        Task<List<AlbumReadDto>?> GetAllByGenre(AlbumGenre genre);
        Task<AlbumReadDto>? GetByAlbumName(string name);
    }
}
