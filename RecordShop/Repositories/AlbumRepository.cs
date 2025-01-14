using Microsoft.EntityFrameworkCore;
using RecordShop.Common.Models;
using RecordShop.DataAccess.Models.Music;
using RecordShop.DataAccess.Repositories.IRepository;
using System;
using System.Collections.Generic;
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

        public OperationResult AssignArtistToAlbum(Artist artist, Album album)
        {
            throw new NotImplementedException();
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

        public async Task<OperationResult> RemoveArtistFromAlbum(int artistId, int albumId)
        {
            OperationResult result = new OperationResult();
            Album album = await GetByIdAsync(albumId);
            if (album != null) {
            return result;
            }
            return result;
        }
    }
}
