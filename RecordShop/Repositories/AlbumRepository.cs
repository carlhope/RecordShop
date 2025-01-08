using Microsoft.EntityFrameworkCore;
using RecordShop.DataAccess.Models.Music;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecordShop.DataAccess.Repositories
{
    public class AlbumRepository : GenericRepository<Album>
    {
        private ApplicationDbContext _db;
        public AlbumRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }
        public override async Task<List<Album>> GetAllAsync()
        {
            var result = await _db.Albums
                .Include(a => a.Artist)
                .ThenInclude(a => a.Artist)
                .ToListAsync();
            return result;
        }
        public override Task<Album?> GetByIdAsync(int id)
        {

            return _db.Albums
                .Include(a => a.Artist)
                .ThenInclude(a => a.Artist)
                .Where(a => a.Id == id)
                .FirstOrDefaultAsync();


        }
    }
}
