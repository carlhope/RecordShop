using RecordShop.Common.Models;
using RecordShop.DataAccess.Models.Music;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecordShop.DataAccess.Repositories.IRepository
{
    public interface IArtistRepository : IGenericRepository<Artist>
    {
        Task<Artist?> GetByArtistName(string name);
    }
}
