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
    public interface IAlbumService : IGenericService<Album, AlbumDto>
    {
        Task<List<AlbumDto>?> GetAllByArtist(int id);
        Task<List<AlbumDto>?> GetAllByGenre(Genre genre);
        Task<AlbumDto>? GetByAlbumName(string name);
    }
}
