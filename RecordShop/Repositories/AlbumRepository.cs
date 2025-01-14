using Microsoft.EntityFrameworkCore;
using RecordShop.Common.Enums;
using RecordShop.Common.Models;
using RecordShop.DataAccess.Models.Music;
using RecordShop.DataAccess.Repositories.IRepository;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecordShop.DataAccess.Repositories
{
    public class AlbumRepository : GenericRepository<Album>, IAlbumRepository
    {
        private ApplicationDbContext _db;
        public AlbumRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public override async Task<IEnumerable<Album>> GetAllAsync()
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
     public async Task<List<Album>?> GetAllByArtist(int id)
        {
            return await _db.Albums
                .Where(x=>x.Artist.Any(a=>a.ArtistId==id))
                .ToListAsync();
        }
        public async Task<List<Album>?> GetAllByGenre(Genre genre)
        {
            return await _db.Albums
                .Where(x => x.Genres.Contains(genre))
                .ToListAsync();
        }
        public async Task<Album>? GetByAlbumName(string name)
        {
            return await _db.Albums
                .Where(x => x.Title==name)
                .FirstOrDefaultAsync();
        }

    }
}
