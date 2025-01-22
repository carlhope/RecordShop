using Microsoft.EntityFrameworkCore;
using RecordShop.DataAccess.Models.Inventory;
using RecordShop.DataAccess.Repositories.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecordShop.DataAccess.Repositories
{
    public class InventoryRepository : GenericRepository<InventoryItem>, IInventoryRepository
    {
        private ApplicationDbContext _db;
        public InventoryRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public async Task<List<InventoryItem>> GetAllInStock()
        {

            return await _db.inventoryItems
                 .Where(x => x.Quantity > 0)
                 .Include(x => x.MusicProduct)
                 .ThenInclude(x => x.MusicAlbum)
                 .ThenInclude(x => x.ArtistJunction)
                 .ThenInclude(x=>x.Artist)
                 .ToListAsync();

        }
    }
}
