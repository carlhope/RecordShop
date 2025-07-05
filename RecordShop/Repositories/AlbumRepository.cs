using Microsoft.EntityFrameworkCore;
using RecordShop.Common.Enums;
using RecordShop.Common.Models;
using RecordShop.DataAccess.Migrations;
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
                .Include(a => a.ArtistJunction)
                .ThenInclude(a => a.Artist)
                .Include(g=>g.Genres)
                .ToListAsync();
            return result;
        }
        public override async Task<Album?> GetByIdAsync(int id)
        {

            return await _db.Albums
                .Include(a => a.ArtistJunction)
                .ThenInclude(a => a.Artist)
                .Where(a => a.Id == id)
                .Include(g=>g.Genres)
                .FirstOrDefaultAsync();


        }
     public async Task<List<Album>?> GetAllByArtist(int id)
        {
            return await _db.Albums
                .Where(x=>x.ArtistJunction.Any(a=>a.ArtistId==id))
                .Include(x=>x.ArtistJunction)
                .Include(x=>x.Genres)
                .ToListAsync();
        }
        public async Task<List<Album>?> GetAllByGenre(string genre)
        {
            if (Enum.TryParse(genre, out Genre result))
            {
                return await _db.Albums
                    .Where(x => x.Genres.Any(g => g.Genre == result))
                    .Include(x => x.ArtistJunction)
                    .Include(x => x.Genres)
                    .ToListAsync();
            }
            else return new List<Album>();
        }
        public async Task<Album?> GetByAlbumName(string name)
        {
            return await _db.Albums
                .Where(x => EF.Functions.Like(x.Title, name))
                .Include(x => x.ArtistJunction)
                .ThenInclude(a=>a.Artist)
                .Include(x => x.Genres)
                .FirstOrDefaultAsync();
        }
        public override async Task<OperationResult> UpdateAsync(int id, Album updated)
        {
            _db.Albums.Update(updated);
            await _db.SaveChangesAsync();
            return new OperationResult { IsSuccess = true, Message = "Updated" };
        }

    }
}
