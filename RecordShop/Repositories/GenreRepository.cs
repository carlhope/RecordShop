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
    public class GenreRepository : GenericRepository<AlbumGenre>
    {
        private readonly ApplicationDbContext _db;
        public GenreRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }
        
    }
}
