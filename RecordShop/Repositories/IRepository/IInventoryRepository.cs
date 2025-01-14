using RecordShop.DataAccess.Models.Inventory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecordShop.DataAccess.Repositories.IRepository
{
    public interface IInventoryRepository:IGenericRepository<InventoryItem>
    {
        Task<List<InventoryItem>> GetAllInStock();
    }
}
