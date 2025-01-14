using RecordShop.DataAccess.Models.Music;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecordShop.DataAccess.Repositories.IRepository
{
    public interface IMusicProductRepository : IGenericRepository<MusicProduct>
    {
        Task<Dictionary<Album, List<MusicProduct>>?> GetAllByReleaseYear(int year);
    }
}
