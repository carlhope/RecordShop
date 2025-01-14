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
    public class ArtistRepository : GenericRepository<Artist>, IArtistRepository
    {
        private ApplicationDbContext _db;
        public ArtistRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }
    }
}
