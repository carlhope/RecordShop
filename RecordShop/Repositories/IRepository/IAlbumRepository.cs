using RecordShop.Common.Enums;
using RecordShop.Common.Models;
using RecordShop.DataAccess.Models.Music;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecordShop.DataAccess.Repositories.IRepository
{
    public interface IAlbumRepository : IGenericRepository<Album>
    {
        Task<List<Album>?> GetAllByArtist(int id);
        Task<List<Album>?> GetAllByGenre(string genre);
        Task<Album?> GetByAlbumName(string name);
    }
}
