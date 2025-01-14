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
    public class MusicProductRepository : GenericRepository<MusicProduct>, IMusicProductRepository
    {
        private readonly ApplicationDbContext _db;
        public MusicProductRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }
        public async Task<Dictionary<Album,List<MusicProduct>>?> GetAllByReleaseYear(int year)
        {
           return await _db.MusicProducts
                .Where(x => x.ReleaseDate.Year == year)
                .Include(x => x.MusicAlbum)
                .GroupBy(x => x.MusicAlbum)
                .ToDictionaryAsync(g => g.Key, g => g.ToList());
           
        }
        
    }
}
