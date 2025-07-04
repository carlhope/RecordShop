using Microsoft.EntityFrameworkCore;
using RecordShop.Common.Enums;
using RecordShop.DataAccess.Models.Music;
using RecordShop.DataAccess.Repositories.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecordShop.DataAccess.Repositories
{
    public class AlbumGenreRepository : GenericRepository<AlbumGenre>, IAlbumGenreRepository
    {
        private ApplicationDbContext _db;
        public AlbumGenreRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public async Task<AlbumGenre?> GetByGenreName(string name)
        {
            if ((Enum.TryParse<Genre>(name, true, out var genreEnum)))
            {
                return await _db.AlbumGenres
                .FirstOrDefaultAsync(g => g.Genre == genreEnum);


            }
            return null;
        }
    }
}
